using Assan.Domain;

namespace Assan.Repository
{
    public interface IPlayerRepositories
    {
        Task<List<Player>> GetAllAsync();

        Task<Player> GetByIdAsync(Guid id);

        Task<Player> CreateAsync(Player client);
    }
}
