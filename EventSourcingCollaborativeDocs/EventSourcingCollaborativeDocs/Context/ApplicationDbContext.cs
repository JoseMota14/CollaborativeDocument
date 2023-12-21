using EventSourcingCollaborativeDocs.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace EventSourcingCollaborativeDocs.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options){ }

        public DbSet<Document> Documents { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Document>()
                .HasKey(e => e.Id);
                //.HasOne<User>(d => d.Author)
                //.WithMany(u => u.DocumentsAuthored)
                //.HasForeignKey(d => d.AuthorId)
                //.OnDelete(DeleteBehavior.Restrict);
        }
    }
}
