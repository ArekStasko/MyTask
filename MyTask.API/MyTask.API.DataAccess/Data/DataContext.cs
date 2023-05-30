using Microsoft.EntityFrameworkCore;
using MyTask.API.DataAccess.Data.Models.Project;
using MyTask.API.DataAccess.Data.Models.Raport;
using MyTask.API.DataAccess.Data.Models.Task;

namespace MyTask.API.DataAccess.Data;

public class DataContext : DbContext
{
    public DataContext(){}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=172.26.192.1,1433;Database=MyTask_DB;User Id=sa;Password=Password.1234");
    }

    public virtual DbSet<IProject> Projects { get; set; }
    public virtual DbSet<IRaport> Raports { get; set; }
    public virtual DbSet<ITask>  Tasks { get; set; }

}