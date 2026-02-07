using Microsoft.AspNetCore.Mvc;
using FSbackend.Data;
using FSbackend.Entities;

namespace FSbackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilmSeriesController : ControllerBase
    {
        private readonly film_db _context;

        public FilmSeriesController(film_db context)
        {
            _context = context;
        }

        
        [HttpGet("films")]
        public List<films> GetAllFilms()
        {
            var films = _context.films.Where(a => a.id < 15).ToList();
            return films;
        }

        
        [HttpGet("series")]
        public IActionResult GetAllSeries()
        {
            return Ok(_context.series.ToList());
        }

        
        [HttpPost("films")]
        public IActionResult AddFilm([FromBody] films film)
        {
            _context.films.Add(film);
            _context.SaveChanges();
            return Ok(film);
        }

        
        [HttpPost("series")]
        public IActionResult AddSeries([FromBody] series serie)
        {
            _context.series.Add(serie);
            _context.SaveChanges();
            return Ok(serie);
        }

        
        [HttpDelete("films/{id}")]
        public IActionResult DeleteFilm(int id)
        {
            var film = _context.films.Find(id);
            if (film == null) return NotFound();
            _context.films.Remove(film);
            _context.SaveChanges();
            return Ok();
        }

        
        [HttpDelete("series/{id}")]
        public IActionResult DeleteSeries(int id)
        {
            var serie = _context.series.Find(id);
            if (serie == null) return NotFound();
            _context.series.Remove(serie);
            _context.SaveChanges();
            return Ok();
        }
    }
}
