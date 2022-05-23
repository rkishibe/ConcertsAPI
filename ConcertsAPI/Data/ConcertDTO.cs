using ConcertsAPI.Models;

namespace ConcertsAPI.Data
{
    public class ConcertDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateTime { get; set; }
        public City City { get; set; }
        public Venue Venue { get; set; }
        public List<Artist> Artists { get; set; }
        public int TicketPrice { get; set; }
    }
}
