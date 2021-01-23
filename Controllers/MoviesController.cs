using Microsoft.AspNetCore.Mvc;
using RankMoviesAPI.Data;
using RankMoviesAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RankMoviesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {

        private readonly MoviesRepository _movies;

        public MoviesController(MoviesRepository movies)
        {
            _movies = movies;
        }

        // GET: api/Movies
        [HttpGet(Name = "GetMovies")]
        public ActionResult<IEnumerable<Movie>> Get()
        {
            var movies = _movies.Get();

            return movies;
        }

        // GET api/Movies/abcd      
        [HttpGet("{id:length(24)}", Name = "GetMovie")]
        public ActionResult<Movie> Get(string id)
        {
            var movie =  _movies.Get(id);

            if (movie is null) return NotFound();

            // ASP.NET Core automatically serializes the object to JSON and writes the JSON into the body of 
            // the response message. The response code for this return type is 200 OK, 
            // assuming there are no unhandled exceptions.
            return movie;
        }

        // POST api/Movies
        [HttpPost]
        public ActionResult<Movie> Post([FromBody] Movie movie)
        {
            _movies.Create(movie);

            return CreatedAtRoute("GetMovie", new { id = movie.ID.ToString() }, movie);
        }

        // PUT api/Movies/abcd
        [HttpPut("{id:length(24)}")]
        public IActionResult Put(string id, Movie movieIn)
        {
            var movie = _movies.Get(id);

            if (movie == null)
            {
                return NotFound();
            }

            _movies.Update(id, movieIn);

            return RedirectToRoute("GetMovie", new { id = movie.ID.ToString() });
        }

        // DELETE api/Movies/5
        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var movie = _movies.Get(id);

            if (movie == null)
            {
                return NotFound();
            }

            _movies.Remove(movie.ID);

            return RedirectToRoute("GetMovies");
        }

       
    }
}
