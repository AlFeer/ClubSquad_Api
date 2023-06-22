namespace ClubSquad.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Age { get; set; }
        public int? TeamId { get; set; }
        public Team? Team { get; set; }
    }
}