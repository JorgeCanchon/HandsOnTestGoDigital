using HandsOnTestGoDigital.Core.Entities;
using HandsOnTestGoDigital.Core.Models;

namespace HandsOnTestGoDigital.Core.Interfaces.Repositories
{
    public interface IMovieRepository
    {
        public Movie GetLastMovies();
        public MovieResponse GetBestMovies();
        public MovieResponse GetTopMovies();
        public MovieResponse GetMoviesByName(string name);
        public Movie GetMovieByDetail(int idMovie);
    }
}
