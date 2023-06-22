using ClubSquad.Data;
using ClubSquad.Interfaces;
using ClubSquad.Models;

namespace ClubSquad.Repository
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly DataContext _context;

        public PlayerRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Player> GetPlayer()
        {
            return _context.Players.ToList();
        }

        public Player GetPlayers(int id)
        {
            return _context.Players.Where(n => n.Id == id).FirstOrDefault();
        }

        public bool CreatePlayer(Player player)
        {
            _context.Players.Add(player);
            return Save();
        }
        public bool UpdatePlayer(Player player)
        {
            _context.Update(player);
            return Save();
        }
        public bool DeletePlayer(Player player)
        {
            _context.Players.Remove(player);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
