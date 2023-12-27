using EventSourcingCollaborativeDocs.Events;
using EventSourcingCollaborativeDocs.Models;
using Microsoft.AspNetCore.SignalR;

namespace EventSourcingCollaborativeDocs.Hubs
{
    public class DocumentHub : Hub
    {
        private readonly DocumentUpdatedEventHandler _documentUpdatedEventHandler;

        public DocumentHub(DocumentUpdatedEventHandler documentUpdatedEventHandler)
        {
            _documentUpdatedEventHandler = documentUpdatedEventHandler;
        }

        // This method can be called by clients to broadcast changes to all connected clients
        public async Task UpdateDocument(string documentContent)
        {
            var documentUpdatedEvent = new DocumentUpdatedEvent
            {
                DocumentId = "Id number 1", // Identify the document
                NewContent = documentContent // Updated content
            };

            _documentUpdatedEventHandler.HandleDocumentUpdatedEvent(documentUpdatedEvent);

            await Clients.All.SendAsync("ReceiveUpdatedDocument", documentUpdatedEvent);
        }

        public override async Task OnConnectedAsync()
        {
            // Additional logic when a client connects
            // For example, sending initial document data to the connected client
            // This could involve fetching data from a database or other source
            // For illustration purposes, sending a sample initial document content

            var documentUpdatedEvent = new DocumentUpdatedEvent
            {
                DocumentId = "Id number 1", // Identify the document
                NewContent = "Initial document content..." // Updated content
            };

            await Clients.Caller.SendAsync("ReceiveUpdatedDocument", documentUpdatedEvent);
            await base.OnConnectedAsync();
        }
    }
}
