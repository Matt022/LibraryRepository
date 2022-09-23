using Library.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Library.Infrastructure.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext() : base()
        {
            
        }

        public LibraryContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


        public DbSet<Book> Book { get; set; }

        public DbSet<Dvd> Dvds { get; set; }

        public DbSet<Member> Members { get; set; }

        public DbSet<RentalEntry> RentalEntries { get; set; }

        public DbSet<QueueItem> QueueItems { get; set; }

        public DbSet<Message> Messages { get; set; }

    }
}