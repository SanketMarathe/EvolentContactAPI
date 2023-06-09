using EvolentContact.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EvolentContact.Data
{
    public class EvolentDBContext : DbContext
    {
        public EvolentDBContext(DbContextOptions<EvolentDBContext> options) : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}