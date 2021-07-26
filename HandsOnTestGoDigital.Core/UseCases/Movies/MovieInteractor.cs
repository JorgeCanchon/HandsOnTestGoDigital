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
                var movie = _repositoryWrapper.Movie.FindByCondition(x => x.Equals("")).ToList();

                return movie.Any() ?
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
                var movie = _repositoryWrapper.Movie.FindByCondition(x => x.Equals("")).ToList();

                return movie.Any() ?
                    new Response() { Status = 200, Message = "Ok", Payload = movie } :
                    new Response() { Status = 204, Message = "No content", Payload = null };
            }
            catch (Exception e)
            {
                return new Response() { Status = 500, Message = e.Message, Payload = null };
            }
        }

        public Response GetMovieByDetail()
        {
            try
            {
                var movie = _repositoryWrapper.Movie.FindByCondition(x => x.Equals("")).ToList();

                return movie.Any() ?
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
                var movie = _repositoryWrapper.Movie.FindByCondition(x => x.Equals(name)).ToList();

                return movie.Any() ?
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
                var movie = _repositoryWrapper.Movie.FindByCondition(x => x.Equals("")).ToList();

                return movie.Any() ?
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
