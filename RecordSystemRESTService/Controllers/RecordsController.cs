using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Record?> Post([FromBody] RecordDTO recordDTO)
        {
            Record record = _repository.Add(RecordDTOHelper.DTOtoClass(recordDTO));
            if(_repository.GetById(record.Id) != null)
            {
                return Created($"/api/records/{record.Id}", record);
            }
            return BadRequest();
        }

        // PUT api/<RecordsController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize]
        public ActionResult<Record> Put(int id, [FromBody] RecordDTO dto)
        {
            try
            {
                var updatedRecord = _repository.Update(id, RecordDTOHelper.DTOtoClass(dto));
                if (updatedRecord != null)
                {
                    return Ok(updatedRecord);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (ArgumentException aex)
            {
                return BadRequest(aex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<RecordsController>/5
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Record?> Delete(int id)
        {
            Record? record = _repository.Delete(id);
            if(record != null)
            {
                return Ok(record);
            }
            return NotFound();
        }
    }
}
