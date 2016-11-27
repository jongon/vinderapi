using Microsoft.EntityFrameworkCore;
using Vinder.DAL.Domain;

namespace Vinder.DAL.Configuration
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
            
        }

        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
#if DEBUG
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=VinderDb;Trusted_Connection=True;");
#endif
#if !DEBUG
            optionsBuilder.UseSqlServer(@"Server=tcp:vinderdb.database.windows.net,1433;Initial Catalog=VinderDb;Persist Security Info=False;User ID=vinderadmin;Password=p4$$w0rd;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
#endif
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Emotion> Emotions { get; set; }
    }
}