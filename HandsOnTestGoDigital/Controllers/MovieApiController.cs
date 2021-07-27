using HandsOnTestGoDigital.Common;
using HandsOnTestGoDigital.Core.Entities;
using HandsOnTestGoDigital.Core.UseCases.Movies;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HandsOnTestGoDigital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieApiController : ApiController
    {
        private readonly IMovieInteractor _movieInteractor;

        public MovieApiController(IMovieInteractor movieInteractor)
        {
            _movieInteractor = movieInteractor ?? throw new ArgumentNullException(nameof(movieInteractor));
        }

        [HttpGet("moviesByName/{name}")]
        public IActionResult GetMoviesByName(string name)
        {
            Response response = _movieInteractor.GetMoviesByName(name);
            return GetStatus(response.Status, response);
        }

        [HttpGet("lastMovies")]
        public IActionResult GetLastMovies()
        {
            Response response = _movieInteractor.GetLastMovies();
            return GetStatus(response.Status, response);
        }

        [HttpGet("popular")]
        public IActionResult GetPopular()
        {
            Response response = _movieInteractor.GetTopMovies();
            return GetStatus(response.Status, response);
        }

        [HttpGet("bestMovies")]
        public IActionResult GetBestMovies()
        {
            Response response = _movieInteractor.GetBestMovies();
            return GetStatus(response.Status, response);
        }

        [HttpGet("movieByDetail/{id}")]
        public IActionResult GetMovieByDetail(int id)
        {
            Response response = _movieInteractor.GetMovieByDetail(id);
            return GetStatus(response.Status, response);
        }
    }
}
