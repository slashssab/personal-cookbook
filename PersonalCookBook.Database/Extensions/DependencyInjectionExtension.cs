using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace PersonalCookBook.Database.Extensions
{
    internal static class DependencyInjectionExtension
    {
        public static IServiceCollection AddPersonalCookBookDatabase(this IServiceCollection services, IConfiguration configuration, IHostEnvironment environment)
        {
            services.AddDbContext<PersonalCookBookDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("PersonalCookBookDatabase"));
                if (environment.IsDevelopment())
                {
                    options.EnableDetailedErrors();
                    options.EnableSensitiveDataLogging();
                }
            });
            return services;
        }

        public static IApplicationBuilder UsePersonalCookBookDatabaseMigration(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                using var context = serviceScope.ServiceProvider.GetRequiredService<PersonalCookBookDbContext>();
                context.Database.Migrate();
            }

            return app;
        }
    }
}
