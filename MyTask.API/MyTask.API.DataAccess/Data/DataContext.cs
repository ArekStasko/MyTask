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
        optionsBuilder.UseSqlServer();
    }

    public virtual DbSet<Project> Projects { get; set; }
    public virtual DbSet<Raport> Raports { get; set; }
    public virtual DbSet<_Task>  Tasks { get; set; }

}