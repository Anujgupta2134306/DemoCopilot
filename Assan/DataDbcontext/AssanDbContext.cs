using Assan.Domain;
using Microsoft.EntityFrameworkCore;

namespace Assan.DataDbcontext
{
    public class AssanDbContext : DbContext 
    {
        public AssanDbContext(DbContextOptions<AssanDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Player> Player { get; set; }

    }
}
