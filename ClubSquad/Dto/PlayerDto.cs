using ClubSquad.Models;

namespace ClubSquad.Dto
{
    public class PlayerDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Age { get; set; }
        public int? TeamId { get; set; }
    }
}