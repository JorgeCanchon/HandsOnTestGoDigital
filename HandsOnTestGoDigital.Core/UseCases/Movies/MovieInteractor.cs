using HandsOnTestGoDigital.Core.Entities;
using HandsOnTestGoDigital.Core.Interfaces.Repositories;
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

        public Response GetBestMovies()
        {
            try
            {
                var movie = _repositoryWrapper.Movie.GetBestMovies();

                return movie != null && movie.Results.Any() ?
                    new Response() { Status = 200, Message = "Ok", Payload = movie } :
                    new Response() { Status = 204, Message = "No content", Payload = null };
            }
            catch (Exception e)
            {
                return new Response() { Status = 500, Message = e.Message, Payload = null };
            }
        }

        public Response GetLastMovies()
        {
            try
            {
                var movie = _repositoryWrapper.Movie.GetLastMovies();

                return movie != null ?
                    new Response() { Status = 200, Message = "Ok", Payload = movie } :
                    new Response() { Status = 204, Message = "No content", Payload = null };
            }
            catch (Exception e)
            {
                return new Response() { Status = 500, Message = e.Message, Payload = null };
            }
        }

        public Response GetMovieByDetail(int idMovie)
        {
            try
            {
                var movie = _repositoryWrapper.Movie.GetMovieByDetail(idMovie);

                return movie != null ?
                    new Response() { Status = 200, Message = "Ok", Payload = movie } :
                    new Response() { Status = 204, Message = "No content", Payload = null };
            }
            catch (Exception e)
            {
                return new Response() { Status = 500, Message = e.Message, Payload = null };
            }
        }

        public Response GetMoviesByName(string name)
        {
            try
            {
                var movie = _repositoryWrapper.Movie.GetMoviesByName(name);

                return movie != null && movie.Results.Any() ?
                    new Response() { Status = 200, Message = "Ok", Payload = movie } :
                    new Response() { Status = 204, Message = "No content", Payload = null };
            }
            catch (Exception e)
            {
                return new Response() { Status = 500, Message = e.Message, Payload = null };
            }
        }

        public Response GetTopMovies()
        {
            try
            {
                var movie = _repositoryWrapper.Movie.GetTopMovies();

                return movie != null && movie.Results.Any() ?
                    new Response() { Status = 200, Message = "Ok", Payload = movie } :
                    new Response() { Status = 204, Message = "No content", Payload = null };
            }
            catch (Exception e)
            {
                return new Response() { Status = 500, Message = e.Message, Payload = null };
            }
        }
    }
}
