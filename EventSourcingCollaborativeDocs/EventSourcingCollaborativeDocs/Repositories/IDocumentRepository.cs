using EventSourcingCollaborativeDocs.Models;

namespace EventSourcingCollaborativeDocs.Repositories
{
    public interface IDocumentRepository
    {
        Task<Document> GetByIdAsync(Guid id);
        Task SaveAsync(Document document);
        Task DeleteAsync(Guid id);
        Task<List<Document>> GetAllDocumentsAsync();
    }
}
