using HandsOnTestGoDigital.Core.Interfaces.Repositories;
using HandsOnTestGoDigital.Core.Models;
using HandsOnTestGoDigital.Infraestructure.Data.APIMovie.Repositories;

namespace HandsOnTestGoDigital.Infraestructure.Data.APIMovie
{
    public class MovieRepository : RepositoryBase<Movie>, IMovieRepository
    {
    }
}
