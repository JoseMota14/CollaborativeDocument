using EventSourcingCollaborativeDocs.Models;
using EventSourcingCollaborativeDocs.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EventSourcingCollaborativeDocs.Controllers
{
    [ApiController]
    [Route("api/documents")]
    public class DocumentsController : ControllerBase
    {
        private readonly DocumentRepository _documentRepository;

        public DocumentsController(DocumentRepository documentRepository)
        {
            _documentRepository = documentRepository ?? throw new ArgumentNullException(nameof(documentRepository));
        }

        [HttpGet]
        public async Task<ActionResult<List<Document>>> GetAllDocumentsAsync()
        {
            var documents = await _documentRepository.GetAllDocumentsAsync();
            return Ok(documents);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Document>> GetDocumentByIdAsync(Guid id)
        {
            var document = await _documentRepository.GetByIdAsync(id);
            if (document == null)
            {
                return NotFound();
            }
            return Ok(document);
        }

        [HttpPost]
        public async Task<ActionResult<Document>> CreateDocumentAsync(Document document)
        {
            await _documentRepository.SaveAsync(document);
            return CreatedAtAction(nameof(GetDocumentByIdAsync), new { id = document.Id }, document);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDocumentAsync(Guid id, Document document)
        {
            if (id != document.Id)
            {
                return BadRequest();
            }

            var existingDocument = await _documentRepository.GetByIdAsync(id);
            if (existingDocument == null)
            {
                return NotFound();
            }

            await _documentRepository.SaveAsync(document);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocumentAsync(Guid id)
        {
            var document = await _documentRepository.GetByIdAsync(id);
            if (document == null)
            {
                return NotFound();
            }

            await _documentRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
