using EventSourcingCollaborativeDocs.Models;
using EventSourcingCollaborativeDocs.Services;

namespace EventSourcingCollaborativeDocs.Events
{
    public class DocumentUpdatedEventHandler
    {
        private readonly IDocumentService _documentService;

        public DocumentUpdatedEventHandler(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        public void HandleDocumentUpdatedEvent(DocumentUpdatedEvent @event)
        {
            // Perform actions in response to the document updated event
            // For instance, update a repository or trigger further processes
            // You might apply the event to your domain model or update the document state
            // Example: UpdateDocumentContent(@event.DocumentId, @event.NewContent);
        }
    }
}
