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

        [HttpGet("{name}")]
        public IActionResult GetMoviesByName(string name)
        {
            Response response = _movieInteractor.GetMoviesByName(name);
            return GetStatus(response.Status, response);
        }
    }
}
