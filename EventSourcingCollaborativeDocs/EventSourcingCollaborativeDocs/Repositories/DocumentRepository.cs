using EventSourcingCollaborativeDocs.Context;
using EventSourcingCollaborativeDocs.Models;
using Microsoft.EntityFrameworkCore;

namespace EventSourcingCollaborativeDocs.Repositories
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public DocumentRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task DeleteAsync(Guid id)
        {
            var documentToDelete = await GetByIdAsync(id);
            if (documentToDelete != null)
            {
                _dbContext.Documents.Remove(documentToDelete);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<Document> GetByIdAsync(Guid id)
        {
            return await _dbContext.Documents.FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<List<Document>> GetAllDocumentsAsync()
        {
            return await _dbContext.Documents.ToListAsync();
        }

        public async Task SaveAsync(Document document)
        {
            _dbContext.Documents.Add(document);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateDocumentAsync(Document document)
        {
            _dbContext.Documents.Update(document);
            await _dbContext.SaveChangesAsync();
        }
    }
}
