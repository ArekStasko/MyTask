using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyTask.API.DataAccess.Data;

namespace MyTask.API.DataAccess;

public static class DataExtensions
{
    public static void AddDataContext(this IServiceCollection services)
    {
        services.AddDbContext<DataContext>(options =>
        {
            options.UseSqlServer(@"Server=172.26.192.1,1433;Database=MyTask_DB;User Id=sa;Password=Password.1234");
        });
    }

    public static void Migrate(IApplicationBuilder app) => DatabaseMigrationService.MigrationInitialization(app);
    
}