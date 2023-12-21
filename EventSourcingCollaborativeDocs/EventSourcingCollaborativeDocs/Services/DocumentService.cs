using EventSourcingCollaborativeDocs.Models;
using EventSourcingCollaborativeDocs.Repositories;

namespace EventSourcingCollaborativeDocs.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IDocumentRepository _documentRepository;
        public DocumentService(IDocumentRepository documentRepository)
        {
            _documentRepository = documentRepository ?? throw new ArgumentNullException(nameof(documentRepository));
        }

        public async Task DeleteAsync(Guid id)
        {
            await _documentRepository.DeleteAsync(id);
        }

        public async Task<Document> GetByIdAsync(Guid id)
        {
            return await _documentRepository.GetByIdAsync(id);
        }

        public async Task<List<Document>> GetAllDocumentsAsync()
        {
            return await _documentRepository.GetAllDocumentsAsync();
        }

        public async Task SaveAsync(Document document)
        {
            var ret = await GetByIdAsync(document.Id);
            if (ret != null)
            {
                throw new Exception("File already exists");
            }
            await _documentRepository.SaveAsync(document);
        }
    }
}
