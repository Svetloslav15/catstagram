namespace Catstagram.Server.Infrastructure
{
    using Catstagram.Server.Data;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseSwaggerUi(this IApplicationBuilder app)
        => app
                    .UseSwagger()
                    .UseSwaggerUI(options =>
                    {
                        options.SwaggerEndpoint("/swagger/v1/swagger.json", "My Catstagram v1");
                        options.RoutePrefix = string.Empty;
                    });

        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using var services = app.ApplicationServices.CreateScope();

            CatstagramDbContext dbContext = services.ServiceProvider.GetService<CatstagramDbContext>();
            dbContext.Database.Migrate();
        }
    }
}