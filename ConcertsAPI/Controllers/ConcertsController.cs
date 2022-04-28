using ConcertsAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ConcertsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConcertsController : ControllerBase
    {
        private static IList<Concert> ConcertsList = new List<Concert>();
        // GET: api/<ConcertsController>
        [HttpGet]
        public IEnumerable<Concert> Get()
        {
            return ConcertsList;
        }

        // GET api/<ConcertsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var concert = ConcertsList.FirstOrDefault(v => v.Id == id);
            if (concert == null)
                return NotFound();
            else
                return Ok(concert);

        }

        // POST api/<ConcertsController>
        [HttpPost]
        public IActionResult Post([FromBody] Concert concert)
        {
            if (ConcertsList.Any(v => v.Id == concert.Id))
                return BadRequest($"Venue with {concert.Id} already exissts");
            ConcertsList.Add(concert);
            return CreatedAtAction("Get", concert.Id);
        }


        // PUT api/<ConcertsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Concert newConcertData)
        {
            var concert = ConcertsList.FirstOrDefault(c => c.Id == id);
            if (concert == null)
                return NotFound();

            newConcertData.Id = id;
            ConcertsList[ConcertsList.IndexOf(concert)] = newConcertData;

            return Ok(ConcertsList[ConcertsList.IndexOf(concert)]);
        }

        // DELETE api/<ConcertsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var concert = ConcertsList.FirstOrDefault(c => c.Id == id);
            if (concert != null)
                ConcertsList.Remove(concert);
            return Ok();
        }
    }
}
