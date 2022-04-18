using ConcertsAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ConcertsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private static IList<Artist> ArtistsList = new List<Artist>();
        // GET: api/<ArtistController>
        [HttpGet]
        public IEnumerable<Artist> Get()
        {
            return ArtistsList;
        }

        // GET api/<ArtistController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var artist = ArtistsList.FirstOrDefault(v => v.Id == id);
            if (artist == null)
                return NotFound();
            else
                return Ok(artist);

        }

        // POST api/<ArtistController>
        [HttpPost]
            public IActionResult Post([FromBody] Artist artist)
            {
                if (ArtistsList.Any(v => v.Id == artist.Id))
                    return BadRequest($"Venue with {artist.Id} already exissts");
                ArtistsList.Add(artist);
                return CreatedAtAction("Get", artist.Id);
            }
        

        // PUT api/<ArtistController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Artist newArtistData)
        {
            newArtistData.Id = id;
            ArtistsList[id] = newArtistData;
        }

        // DELETE api/<ArtistController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
