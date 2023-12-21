using EventSourcingCollaborativeDocs.Models;

namespace EventSourcingCollaborativeDocs.Services
{
    public interface IDocumentService
    {
        Task<Document> GetByIdAsync(Guid id);
        Task SaveAsync(Document document);
        Task DeleteAsync(Guid id);
        Task<List<Document>> GetAllDocumentsAsync();
    }
}
