using EventSourcingCollaborativeDocs.Context;
using EventSourcingCollaborativeDocs.Repositories;
using EventSourcingCollaborativeDocs.Services;
using Microsoft.EntityFrameworkCore;

namespace EventSourcingCollaborativeDocs.Infra
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastucture(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IDocumentRepository, DocumentRepository>();
            services.AddScoped<IDocumentService, DocumentService>();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase(databaseName: "InMemoryDatabase"));

            return services;
        }
    }
}
