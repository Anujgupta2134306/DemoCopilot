using DemoCopilot.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace DemoCopilot.Data
{
    public class PlayerDbcontext : DbContext
    {
    public PlayerDbcontext(DbContextOptions<PlayerDbcontext> dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<Player> Players { get; set; }
    }
}
