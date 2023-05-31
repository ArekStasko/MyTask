using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MyTask.API.DataAccess.Data;

public class DatabaseMigrationService
{
    internal static void MigrationInitialization(IApplicationBuilder app)
    {
        using (var serviceScope = app.ApplicationServices.CreateScope())
        {
            serviceScope.ServiceProvider.GetService<DataContext>().Database.Migrate();
        }
    }
}