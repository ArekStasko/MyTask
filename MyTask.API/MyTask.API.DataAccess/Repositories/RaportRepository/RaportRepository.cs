using Microsoft.EntityFrameworkCore;
using MyTask.API.DataAccess.Data;
using MyTask.API.DataAccess.Data.Models.Raport;

namespace MyTask.API.DataAccess.Repositories.RaportRepository;

public class RaportRepository : IRaportRepository
{
    private DataContext _context;
    public RaportRepository(DataContext context)
    {
        _context = context;
    }
    
    public async Task<bool> Generate(IRaport raport)
    {
        try
        {
            await _context.Raports.AddAsync((Raport)raport);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public async Task<bool> Delete(int id)
    {
        try
        {
            var raport = await _context.Raports.SingleAsync(p => p.Id == id);
            _context.Raports.Remove(raport);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public async Task<List<IRaport>> Get()
    {
        try
        {
            var raports = await _context.Raports.ToListAsync<IRaport>();
            return raports;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public async Task<IRaport> Get(int id)
    {
        try
        {
            var raport = await _context.Raports.SingleAsync(r => r.Id == id);
            return raport;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}