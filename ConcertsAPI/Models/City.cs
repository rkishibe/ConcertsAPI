namespace ConcertsAPI.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Coordinate? Coordinate { get; set; }
        public IList<Venue> VenueList { get; set; }
    }
}
