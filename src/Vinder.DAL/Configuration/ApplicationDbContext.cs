using Microsoft.EntityFrameworkCore;
using Vinder.DAL.Domain;

namespace Vinder.DAL.Configuration
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
#if DEBUG
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=VinderDb;Trusted_Connection=True;");
#endif
#if !DEBUG
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=VinderDb;Trusted_Connection=True;");
#endif
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Emotion> Emotions { get; set; }
    }
}