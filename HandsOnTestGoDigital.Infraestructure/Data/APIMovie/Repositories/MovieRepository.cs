using HandsOnTestGoDigital.Core.Entities;
using HandsOnTestGoDigital.Core.Interfaces.Repositories;
using HandsOnTestGoDigital.Core.Models;

namespace HandsOnTestGoDigital.Infraestructure.Data.APIMovie
{
    public class MovieRepository : IMovieRepository
    {
        private RequestMovie<MovieResponse> _requestMovieResponse;
        private RequestMovie<Movie> _requestMovie;

        public MovieRepository()
        {
            _requestMovieResponse = new RequestMovie<MovieResponse>();
            _requestMovie = new RequestMovie<Movie>();
        }
        
        public MovieResponse GetBestMovies()//mejores calificadas
        {
            return _requestMovieResponse.HttpGet("movie/top_rated", "&language=en-US&page=1");
        }

        public Movie GetLastMovies()//últimas películas
        {
            return _requestMovie.HttpGet("movie/latest", "&language=en-US&page=1");
        }

        public Movie GetMovieByDetail(int idMovie)//detalle de la película
        {
            return _requestMovie.HttpGet($"movie/{idMovie}");
        }

        public MovieResponse GetMoviesByName(string name)//obtener por nombre
        {
            return _requestMovieResponse.HttpGet("search/movie", $"&language=en-US&query={name}&page=1");
        }

        public MovieResponse GetTopMovies()// populares
        {
            return _requestMovieResponse.HttpGet("movie/popular", "&language=en-US&page=1");
        }
    }
}
