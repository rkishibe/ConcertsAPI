﻿namespace ConcertsAPI.Models
{
    public class Venue
    {
        public int Id { get; set; }
        public string Name { get; set; }
		public City City {get; set;}
        //public Coordinate? Coordinate { get; set; }
        public int? Capacity { get; set; }
        public bool? IsOutdoor { get; set; }

    }
}
