namespace EventSourcingCollaborativeDocs.Models
{
    public class DocumentUpdatedEvent
    {
        public string DocumentId { get; set; }
        public string NewContent { get; set; }
    }
}
