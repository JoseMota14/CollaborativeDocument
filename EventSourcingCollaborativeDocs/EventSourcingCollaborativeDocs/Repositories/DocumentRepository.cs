using EventSourcingCollaborativeDocs.Models;

namespace EventSourcingCollaborativeDocs.Repositories
{
    public class DocumentRepository : IDocumentRepository
    {


        public DocumentRepository() { }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Document> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Document>> GetAllDocumentsAsync()
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync(Document document)
        {
            throw new NotImplementedException();
        }
    }
}
