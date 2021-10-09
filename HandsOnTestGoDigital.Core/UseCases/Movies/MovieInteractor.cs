using HandsOnTestGoDigital.Core.Entities;
using HandsOnTestGoDigital.Core.Interfaces.Repositories;
using HandsOnTestGoDigital.Core.Models;
using System;
using System.Linq;

namespace HandsOnTestGoDigital.Core.UseCases.Movies
{
    public class MovieInteractor : IMovieInteractor
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public MovieInteractor(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper ?? throw new ArgumentNullException(nameof(repositoryWrapper));
        }

        public Response GetBestMovies() =>
            GetResponseMovies(_repositoryWrapper.Movie.GetBestMovies());

        public Response GetLastMovies() =>
            GetResponseMovie(_repositoryWrapper.Movie.GetLastMovies());

        public Response GetMovieByDetail(int idMovie) =>
            GetResponseMovie(_repositoryWrapper.Movie.GetMovieByDetail(idMovie));

        public Response GetMoviesByName(string name) =>
            GetResponseMovies(_repositoryWrapper.Movie.GetMoviesByName(name));

        public Response GetTopMovies() => 
            GetResponseMovies(_repositoryWrapper.Movie.GetTopMovies());

        public Response GetResponseMovies(MovieResponse payload) =>
            GetStatus(() => payload != null && payload.Results.Any() != null, payload);

        public Response GetResponseMovie(Movie payload) =>
            GetStatus(() => payload != null, payload);

        public Response GetStatus(Func<bool> condition, object payload = null)
        {
            try
            {
                return condition() ? new Response() { Status = 200, Message = "Ok", Payload = payload } :
                new Response() { Status = 204, Message = "No content", Payload = null };
            }
            catch (Exception e)
            {
                return new Response() { Status = 500, Message = e.Message, Payload = null };
            }
        }
    }
}
