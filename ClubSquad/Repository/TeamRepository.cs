using ClubSquad.Data;
using ClubSquad.Interfaces;
using ClubSquad.Models;
using Microsoft.EntityFrameworkCore;

namespace ClubSquad.Repository
{
    public class TeamRepository : ITeamRepository
    {
        private readonly DataContext _context;

        public TeamRepository(DataContext context)
        {
            _context = context;
        }
        public ICollection<Team> GetTeams()
        {
            return _context.Teams.Include(n => n.Players).ToList();
        }

        public Team GetTeam(int id)
        {
            return _context.Teams.Include(_n => _n.Players).Where(n => n.Id == id).FirstOrDefault();
        }

        public bool CreateTeam(Team team)
        {
            _context.Add(team);
            return Save();
        }
        public bool UpdateTeam(Team team)
        {
            _context.Update(team);
            return Save();
        }

        public bool DeleteTeam(Team team)
        {
            _context.Remove(team);
            return Save();
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

    }
}
