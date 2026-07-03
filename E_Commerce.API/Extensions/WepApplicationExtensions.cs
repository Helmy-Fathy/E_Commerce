using E_Commerce.Domain.Contracts;
using Microsoft.AspNetCore.Builder;

namespace E_Commerce.API.Extensions
{
    public static class WepApplicationExtensions
    {
        public static async Task<WebApplication> SeedAndMigrateDataAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var seeder = scope.ServiceProvider.GetRequiredKeyedService<IDataSeeder>("Catalog");
            await seeder.SeedDataAsync();
            return app;
        }
    }
}
