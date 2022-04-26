namespace ConcertsAPI.Models
{
    public class Concert
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string Name { get; set; }
        public City City { get; set; }
        public Venue Venue { get; set; }
        public IList<Artist> Artists { get; set; }
        public int TicketPrice { get; set; }
    }
}
