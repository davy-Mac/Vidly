using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context; // initializes the DbContext instance 

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET / api/movies
        public IEnumerable<MovieDto> GetMovies() // returns the Movies from the DB
        {
            return _context.Movies.ToList()
                .Select(Mapper.Map<Movie, MovieDto>); // maps out the object and selects it to return source "Movie" target "MovieDto"
        }

        // GET /api/movies/1
        public IHttpActionResult GetMovie(int id) // returns only a single Movie 
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        // POST /api/movies
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto) // to create a Movie remember! to explicitly decorate the method with [HttpPost]
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);

            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }

        // PUT /api/movies/1  //Example URL
        [HttpPut]
        public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)  // to update a Movie. Requires! [HttpPut]
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movieInDb == null)
                return NotFound();

            Mapper.Map(movieDto, movieInDb);


            _context.SaveChanges();

            return Ok();
        }

        // DELETE api/movies/1  //Example URL
        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id) // to Delete a Movie requires! [HttpDelete]
        {
            var moviedInDb = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (moviedInDb == null)
                return NotFound();

            _context.Movies.Remove(moviedInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
