using EventSourcingCollaborativeDocs.Repositories;

namespace EventSourcingCollaborativeDocs.Infra
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastucture(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IDocumentRepository, DocumentRepository>();

            return services;
        }
    }
}
