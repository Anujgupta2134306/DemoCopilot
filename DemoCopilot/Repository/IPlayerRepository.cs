using DemoCopilot.Model.Domain;

namespace DemoCopilot.Repository
{
    public interface IPlayerRepository
    {

        Task<List<Player>> GetAllPlayerAsync();

        Task<Player> AddPlayerAsync(Player player);
        Task<Player> GetPlayerByIdAsync(Guid id);
    }
}
