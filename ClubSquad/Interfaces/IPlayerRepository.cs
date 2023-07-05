using ClubSquad.Models;

namespace ClubSquad.Interfaces
{
    public interface IPlayerRepository
    {
        Task<ICollection<Player>> GetPlayer();
        Task<Player> GetPlayers(int id);
        Task CreatePlayer(Player player);
        Task UpdatePlayer(Player player);
        Task DeletePlayer(Player player);
    }
}