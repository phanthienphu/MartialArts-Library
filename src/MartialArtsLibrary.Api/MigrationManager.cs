using MartialArtsLibrary.Data;
using Microsoft.EntityFrameworkCore;

namespace MartialArtsLibrary.Api
{
    public static class MigrationManager
    {
        public static WebApplication MigrationDatabase(this WebApplication app)
        {
            using(var scope=app.Services.CreateScope())
            {
                using(var context = scope.ServiceProvider.GetRequiredService<MartialArtsLibraryContext>())
                {
                    context.Database.Migrate();
                    new DataSeeder().SeedAsync(context).Wait();
                }
            }
            return app;
        }
    }
}
