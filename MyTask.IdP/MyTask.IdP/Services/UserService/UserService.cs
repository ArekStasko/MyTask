using System.Security.Cryptography;
using MyTask.IdP.Data;
using MyTask.IdP.Data.DTO;
using MyTask.IdP.Data.Models;
using MyTask.IdP.Services.TokenService;

namespace MyTask.IdP.Services.UserService;

public class UserService : IUserService
{
    private DataContext _context;
    private ITokenService _tokenService;

    public UserService(DataContext dataContext, ITokenService tokenService)
    {
        _context = dataContext;
        _tokenService = tokenService;
    }
    public string Register(UserDTO userDto)
    {
        try
        {
            if(_context.Users.Any(u => u.UserName == userDto.UserName)) throw new Exception("User with this username already exists");

            Tuple<byte[], byte[]> hash = CreatePasswordHash(userDto.Password);

            User user = new User()
            {
                UserName = userDto.UserName,
                PasswordHash = hash.Item1,
                PasswordSalt = hash.Item2
            };
            _context.Users.Add(user);
            _context.SaveChanges();
            var createdUser = _context.Users.First(u => u.UserName == userDto.UserName);
            Console.WriteLine("CREATED USER:");
            Console.WriteLine(createdUser);
            string token = _tokenService.GenerateToke(createdUser);
                
            return token;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public string Login(UserDTO userDto)
    {
        try
            {
                var user = _context.Users.First(u => u.UserName == userDto.UserName);

                if (user == null) throw new Exception($"There is no user with {userDto.UserName} Username");
                if (!VerifyPasswordHash(userDto.Password, user)) throw new Exception("Wrong Password or Username");    

                string token = _tokenService.GenerateToke(user);

                return token;
            }
            catch (Exception ex)
            {
                throw ex;
            }
    }
    
    private Tuple<byte[], byte[]> CreatePasswordHash(string password)
    {
        try
        {
            byte[] passwordSalt;
            byte[] passwordHash;

            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }

            return new Tuple<byte[], byte[]>(passwordHash, passwordSalt);
        }
        catch(Exception ex)
        {
            throw ex;
        }
    }
    
    private bool VerifyPasswordHash(string password, User user)
    {
        using (var hmac = new HMACSHA512(user.PasswordSalt))
        {
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return computedHash.SequenceEqual(user.PasswordHash);
        }
    }
}