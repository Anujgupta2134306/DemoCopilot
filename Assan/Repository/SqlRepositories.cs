using Assan.Controllers;
using Assan.DataDbcontext;
using Assan.Domain;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Assan.Repository
{
    public class SqlRepositories : IPlayerRepositories
    {
        private readonly AssanDbContext dbContext;

        public SqlRepositories(AssanDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public async Task<Player> CreateAsync(Player players )
        {
            await dbContext.Player.AddAsync(players);
            await dbContext.SaveChangesAsync();
            return players;
        }

        public async Task<List<Player>> GetAllAsync()
        {
            return await dbContext.Player.ToListAsync();
        }


        public async Task<Player> GetByIdAsync(Guid id)
        {
            return await dbContext.Player.FirstOrDefaultAsync(x => x.Id == id);
        }

      
    }
}
