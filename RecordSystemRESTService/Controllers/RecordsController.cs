using Microsoft.AspNetCore.Mvc;
using RecordLib;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RecordSystemRESTService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordsController : ControllerBase
    {
        private readonly IRecordRepository _repository;
        public RecordsController(IRecordRepository repository)
        {
            _repository = repository;
        }

        // GET: api/<RecordsController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<Record>> Get([FromQuery] int? id = null,
                                                     [FromQuery] string? title = null,
                                                     [FromQuery] string? artist = null,
                                                     [FromQuery] int? minDuration = null,
                                                     [FromQuery] int? maxDuration = null, 
                                                     [FromQuery] int? minPubYear = null, 
                                                     [FromQuery] int? maxPubYear = null)
        {
            List<Record> records = _repository.GetAll(id, title, artist, minDuration, maxDuration, minPubYear, maxPubYear);
            if (records.Count == 0)
            {
                return NotFound();
            }
            return Ok(records);

        }

        // GET api/<RecordsController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Record> Get(int id)
        {
            Record? foundRecord = _repository.GetById(id);
            if (foundRecord == null)
            {
                return NotFound();
            }
            return Ok(foundRecord);
        }

        // POST api/<RecordsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<RecordsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RecordsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
