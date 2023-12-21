namespace EventSourcingCollaborativeDocs.Models
{
    public class Document
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string AuthorId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastModifiedAt { get; set; }

        public List<User> Writters { get; set; }
    }
}
