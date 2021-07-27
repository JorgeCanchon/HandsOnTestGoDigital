using HandsOnTestGoDigital.Core.Entities;
using HandsOnTestGoDigital.Core.Interfaces.Repositories;
using HandsOnTestGoDigital.Core.Models;
using HandsOnTestGoDigital.Core.UseCases.Movies;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace HandsOnTestGoDigital.Test
{
    [TestClass]
    public class MovieRepositoryTest
    {
        private readonly Mock<IRepositoryWrapper> movieRepo = new Mock<IRepositoryWrapper>();

        [TestMethod]//Mocks
        public void DebeRetornarEstado200()
        {
            var movies = new List<Movie>() { null, null };
            var movieResponse = new MovieResponse() { Results = movies };
            movieRepo.Setup(m => m.Movie.GetTopMovies()).Returns(movieResponse);
            var mockObject = movieRepo.Object;
            var movieInteractor = new MovieInteractor(mockObject);

            var status = movieInteractor.GetTopMovies().Status;
            Assert.IsTrue(status == 200);
        }

        [TestMethod]//Mocks
        public void DebeRetornarElDetalleDeLaPeliculaCorrespondiente()
        {
            var movie = new Movie { 
                Id = 500,
                Adult = false,
                Overview = "test"
            };

            movieRepo.Setup(m => m.Movie.GetMovieByDetail(1)).Returns(movie);
            var mockObject = movieRepo.Object;
            var movieInteractor = new MovieInteractor(mockObject);

            var movieDetail = movieInteractor.GetMovieByDetail(1).Payload;
            Assert.AreEqual(movie, movieDetail);
        }
    }
}
