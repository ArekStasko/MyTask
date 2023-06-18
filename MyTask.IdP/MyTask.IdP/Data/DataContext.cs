using Microsoft.EntityFrameworkCore;
using MyTask.IdP.Data.Models;

namespace MyTask.IdP.Data;

public class DataContext : DbContext
{
    public DataContext(){}
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    public virtual DbSet<User> Users { get; set; }
}