namespace ClubSquad.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public ICollection<Player> Players { get; }
    }
}