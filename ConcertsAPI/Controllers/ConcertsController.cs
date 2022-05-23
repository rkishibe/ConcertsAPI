using ConcertsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using ConcertsAPI.Controllers.Data;
using AutoMapper;
using ConcertsAPI.Data;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ConcertsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConcertsController : ControllerBase
    {
        private static IList<Concert> ConcertsList = new List<Concert>();

        private readonly ConcertContext _dataContext;
        private readonly IMapper _mapper;


        public ConcertsController(ConcertContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        // GET: api/<ConcertsController>
        [HttpGet(Name ="AllStations")]
        public IEnumerable<Concert> AllStations(int page=1, int pageSize=10, string? name="")
        {
            var skip=(page - 1)*pageSize;
            List<ConcertDTO> concertDTOs;

          
            if (string.IsNullOrEmpty(name))
            {
                concertDTOs = _dataContext.Concerts.
                    Skip(skip)
                   .Take(pageSize)
                   .ToList();
            }
            else
            {
                concertDTOs = _dataContext.Concerts
                    .Where(concert => concert.Name.Contains(name))
                    .Skip(skip)
                    .Take(pageSize)
                    .ToList();

            }

                var count=_dataContext.Concerts.Count();
                var concerts=_mapper.Map<List<Concert>>(concertDTOs);

            #region paginatie intr-un singur header
            // informatia despre paginatie este trimisa intr-un singur header
            //var paginationResult = new PaginationResult
           // {
           //     Page = page,
           //     PageSize = pageSize,
           //     TotalResults = count,
            //    TotalPages = (int)Math.Ceiling(count / (decimal)pageSize)
           // };

          //  Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(paginationResult));
            #endregion

            #region paginatie ca headere multiple
            // informatia despre paginatie e transmisa in mai multe headere
            Response.Headers.Add("X-Page", page.ToString());
            Response.Headers.Add("X-PageSize", pageSize.ToString());
            Response.Headers.Add("X-TotalResults", count.ToString());
            Response.Headers.Add("X-TotalPages", Math.Ceiling(count / (decimal)pageSize).ToString());
            #endregion

            return concerts;
        }

        // GET api/<ConcertsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var concertDto = ConcertsList.FirstOrDefault(v => v.Id == id);
            if (concertDto == null)
                return NotFound();
            
            var concert = _mapper.Map<Concert>(concertDto);
                return Ok(concertDto);

        }

        // POST api/<ConcertsController>
        [HttpPost(Name = "CreateStation")]
        public IActionResult CreateStation([FromBody] Concert concert)
        {
            var concertDto = new ConcertDTO
            {
                Name = concert.Name,
            };
               
            var newConcert =_dataContext.Concerts.Add(concertDto);
            _dataContext.SaveChanges();

            return Ok();
        }


        // PUT api/<ConcertsController>/5
        [HttpPut("{id}", Name = "UpdateConcert")]
        public IActionResult UpdateConcert(int id, [FromBody] Concert newConcertData)
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
        public IActionResult DeleteStation(int id)
        {
            var concert = ConcertsList.FirstOrDefault(c => c.Id == id);
            if (concert != null)
                ConcertsList.Remove(concert);
            return Ok();
        }
    }
}
