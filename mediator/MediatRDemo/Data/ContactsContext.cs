
using Microsoft.EntityFrameworkCore;

namespace MediatRDemo.Data
{
    public class ContactsContext : DbContext
    {
        public ContactsContext(DbContextOptions<ContactsContext> options) : base(options)
        {

        }

        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>().HasData(
                 new Contact { Id = 1, FirstName = "Steva", LastName = "Stevic" },
                 new Contact { Id = 2, FirstName = "Pera", LastName = "Peric" },
                 new Contact { Id = 3, FirstName = "Mita", LastName = "Mitic" }
                );
        }
    }
}
