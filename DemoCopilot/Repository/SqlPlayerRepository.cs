using DemoCopilot.Data;
using DemoCopilot.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace DemoCopilot.Repository
{
    public class SqlPlayerRepository : IPlayerRepository
    {
        private readonly PlayerDbcontext dbcontext;

        public SqlPlayerRepository(PlayerDbcontext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        public async Task<Player> AddPlayerAsync(Player player)
        {
            await dbcontext.Players.AddAsync(player);
            await dbcontext.SaveChangesAsync();
            return player;
            
        }

        public Task<List<Player>> GetAllPlayerAsync()
        {
            return dbcontext.Players.ToListAsync();
        }

        public async Task<Player> GetPlayerByIdAsync(Guid id)
        {
            return await dbcontext.Players.FirstOrDefaultAsync(p => p.Id == id);
            
        }

        public Task<Player> GetPlayerByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
