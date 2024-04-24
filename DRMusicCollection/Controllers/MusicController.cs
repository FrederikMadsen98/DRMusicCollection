using DRMusicCollection.Model;
using DRMusicCollection.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DRMusicCollection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicController : ControllerBase
    {
        private readonly MusicRepository _repo = new MusicRepository();


        // GET: api/<MusicController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IEnumerable<Music> Get([FromQuery] string title, [FromQuery] string sort_by)
        {
            return _repo.GetAll(title, sort_by);
        }

        // GET api/<MusicController>/5
        [HttpGet("{title}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Music> Get(string title)
        {
            Music music = _repo.GetByTitle(title);
            if (music == null) return NotFound("No such title" + title);
            return Ok(music);
        }

        // POST api/<MusicController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Music> Post([FromBody] Music value)
        {
            try
            {
                Music newMusic = _repo.Add(value);
                string uri = Url.RouteUrl(RouteData.Values) + "/" + newMusic.Title;
                return Created(uri, newMusic);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<MusicController>/5
        [HttpPut("{title}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Music> Put(string title, [FromBody] Music value)
        {
            try
            {
                Music updatedMusic = _repo.Update(title, value);
                if (updatedMusic == null) return NotFound("No such music, title" + title);
                return Ok(updatedMusic);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<MusicController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Music> Delete(string title)
        {
            Music deleteMusic = _repo.Delete(title);
            if (deleteMusic == null) return NotFound("No such music, title" + title);
            return Ok(deleteMusic);
        }
    }
}
