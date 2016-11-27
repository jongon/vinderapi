using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Vinder.DAL.Configuration
{
    public class DbContextFactory : IDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext Create()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
#if DEBUG
            builder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=vinder;Trusted_Connection=True;MultipleActiveResultSets=true");
#endif
#if !DEBUG
            builder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=vinder;Trusted_Connection=True;MultipleActiveResultSets=true");
#endif
            return new ApplicationDbContext(builder.Options);
        }

        public ApplicationDbContext Create(DbContextFactoryOptions options)
        {
            throw new System.NotImplementedException();
        }
    }
}
