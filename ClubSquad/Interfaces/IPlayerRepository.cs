using ClubSquad.Models;

namespace ClubSquad.Interfaces
{
    public interface IPlayerRepository
    {
        ICollection<Player> GetPlayer();
        Player GetPlayers(int id);
        bool CreatePlayer(Player player);
        bool UpdatePlayer(Player player);
        bool DeletePlayer(Player player);
        bool Save();
    }
}
