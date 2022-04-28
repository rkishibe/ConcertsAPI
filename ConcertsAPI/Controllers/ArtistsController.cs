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
        // GET: api/<ArtistsController>
        [HttpGet]
        public IEnumerable<Artist> Get()
        {
            return ArtistsList;
        }

        // GET api/<ArtistsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var artist = ArtistsList.FirstOrDefault(v => v.Id == id);
            if (artist == null)
                return NotFound();
            else
                return Ok(artist);

        }

        // POST api/<ArtistsController>
        [HttpPost]
            public IActionResult Post([FromBody] Artist artist)
            {
                if (ArtistsList.Any(v => v.Id == artist.Id))
                    return BadRequest($"Venue with {artist.Id} already exissts");
                ArtistsList.Add(artist);
                return CreatedAtAction("Get", artist.Id);
            }


        // PUT api/<ArtistsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Artist newArtistData)
        {
            var artist = ArtistsList.FirstOrDefault(a => a.Id == id);
            if (artist == null)
                return NotFound();

            newArtistData.Id = id;
            ArtistsList[ArtistsList.IndexOf(artist)] = newArtistData;

            return Ok(ArtistsList[ArtistsList.IndexOf(artist)]);
        }

        // DELETE api/<ArtistsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var artist = ArtistsList.FirstOrDefault(a => a.Id == id);
            if (artist != null)
                ArtistsList.Remove(artist);
            return Ok();
        }
    }
}
