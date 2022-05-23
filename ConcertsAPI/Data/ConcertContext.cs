using ConcertsAPI.Data;
using ConcertsAPI.Models;
using Microsoft.EntityFrameworkCore;
namespace ConcertsAPI.Controllers.Data
{
    public class ConcertContext : DbContext
    {
        public ConcertContext(DbContextOptions<ConcertContext> dbContextOptions) : base(dbContextOptions)
        { }
        public DbSet<ArtistDTO> Artists { get; set; }
        public DbSet<ConcertDTO> Concerts { get; set; }    
    }
}
