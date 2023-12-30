using EventSourcingCollaborativeDocs.Context;
using EventSourcingCollaborativeDocs.Events;
using EventSourcingCollaborativeDocs.Repositories;
using EventSourcingCollaborativeDocs.Services;
using Microsoft.EntityFrameworkCore;

namespace EventSourcingCollaborativeDocs.Infra
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastucture(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSignalR();

            services.AddScoped<IDocumentRepository, DocumentRepository>();
            services.AddScoped<IDocumentService, DocumentService>();
            services.AddScoped<DocumentUpdatedEventHandler>();

            string[] urls = configuration["AllowedUrl"].Split(";");

            /*services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder.WithOrigins(urls)
                                      .AllowAnyMethod()
                                      .AllowAnyHeader()
                                      .AllowCredentials());
            });*/

            services.AddHealthChecks();

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins(urls)
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                });
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase(databaseName: "InMemoryDatabase"));

            return services;
        }
    }
}
