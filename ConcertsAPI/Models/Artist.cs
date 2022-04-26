﻿namespace ConcertsAPI.Models
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Genre Genre { get; set; }
        public IList<Concert> Concerts { get; set; }
        
    }
}
