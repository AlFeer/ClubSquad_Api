﻿using ClubSquad.Models;

namespace ClubSquad.Dto
{
    public class PlayerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Age { get; set; }
        public int? TeamId { get; set; }
    }
}