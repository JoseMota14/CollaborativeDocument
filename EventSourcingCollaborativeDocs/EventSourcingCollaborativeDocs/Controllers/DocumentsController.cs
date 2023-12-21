using EventSourcingCollaborativeDocs.Models;
using EventSourcingCollaborativeDocs.Services;
using Microsoft.AspNetCore.Mvc;

namespace EventSourcingCollaborativeDocs.Controllers
{
    [ApiController]
    [Route("api/documents")]
    public class DocumentsController : ControllerBase
    {
        private readonly IDocumentService _documentService;

        public DocumentsController(IDocumentService documentService)
        {
            _documentService = documentService ?? throw new ArgumentNullException(nameof(documentService));
        }

        [HttpGet]
        public async Task<ActionResult<List<Document>>> GetAllDocumentsAsync()
        {
            var documents = await _documentService.GetAllDocumentsAsync();
            return Ok(documents);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Document>> GetDocumentByIdAsync(Guid id)
        {
            var document = await _documentService.GetByIdAsync(id);
            if (document == null)
            {
                return NotFound();
            }
            return Ok(document);
        }

        [HttpPost]
        public async Task<ActionResult<Document>> CreateDocumentAsync(Document document)
        {
            try
            {
                await _documentService.SaveAsync(document);
                return CreatedAtAction(nameof(GetDocumentByIdAsync), new { id = document.Id }, document);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDocumentAsync(Guid id, Document document)
        {
            if (id != document.Id)
            {
                return BadRequest();
            }

            var existingDocument = await _documentService.GetByIdAsync(id);
            if (existingDocument == null)
            {
                return NotFound();
            }

            await _documentService.SaveAsync(document);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocumentAsync(Guid id)
        {
            var document = await _documentService.GetByIdAsync(id);
            if (document == null)
            {
                return NotFound();
            }

            await _documentService.DeleteAsync(id);
            return NoContent();
        }
    }
}
