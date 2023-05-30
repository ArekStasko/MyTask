using Microsoft.EntityFrameworkCore;

namespace MyTask.API.DataAccess.Data;

public class DatabaseMigrationService
{
    public static void MigrationInitialization(DataContext context) => context.Database.Migrate();
}