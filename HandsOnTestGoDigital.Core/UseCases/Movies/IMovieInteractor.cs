using HandsOnTestGoDigital.Core.Entities;

namespace HandsOnTestGoDigital.Core.UseCases.Movies
{
    public interface IMovieInteractor
    {
        public Response GetLastMovies();
        public Response GetBestMovies();
        public Response GetTopMovies();
        public Response GetMoviesByName(string name);
        public Response GetMovieByDetail();
    }
}
