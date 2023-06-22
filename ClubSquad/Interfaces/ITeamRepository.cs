using ClubSquad.Models;

namespace ClubSquad.Interfaces
{
    public interface ITeamRepository
    {
        ICollection<Team> GetTeams();
        Team GetTeam(int id);
        bool CreateTeam(Team team);
        bool UpdateTeam(Team team);
        bool DeleteTeam(Team team);
        bool Save();
    }
}
