namespace ConcertsAPI.Models
{
    public class Genre
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public IList<Concert> Concerts { get; set; }
    }
}
