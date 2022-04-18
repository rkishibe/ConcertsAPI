﻿using ConcertsAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ConcertsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VenuesController : ControllerBase
    {
        private static IList<Venue> VenuesList=new List<Venue>();
        // GET: api/<VenuesController>
        [HttpGet]
        public IEnumerable<Venue> Get()
        {
            return VenuesList;
        }

        // GET api/<VenuesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var venue=VenuesList.FirstOrDefault(v=> v.Id==id);
            if (venue == null)
                return NotFound();
            else
                return Ok(venue);
         
        }

        // POST api/<VenuesController>
        [HttpPost]
        public IActionResult Post([FromBody] Venue venue)
        {
            if(VenuesList.Any(v => v.Id == venue.Id))
                return BadRequest($"Venue with {venue.Id} already exissts");
            VenuesList.Add(venue);
            return CreatedAtAction("Get", venue.Id);
        }

        // PUT api/<VenuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Venue newVenueData)
        {
            newVenueData.Id = id;
            VenuesList[id] = newVenueData;

        }

        // DELETE api/<VenuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            //VenuesList.Remove(Get(id));
        }
    }
}
