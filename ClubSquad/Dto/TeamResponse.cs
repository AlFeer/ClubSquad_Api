﻿using ClubSquad.Models;

namespace ClubSquad.Dto
{
    public class TeamResponse
    {
        public string Name { get; set; }
        public int Salary { get; set; }
        public ICollection<PlayerResponse> Players { get; set; }
    }
}