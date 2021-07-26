using HandsOnTestGoDigital.Core.Interfaces.Repositories;

namespace HandsOnTestGoDigital.Infraestructure.Data.APIMovie
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private IMovieRepository movie;
        public RepositoryWrapper()
        {

        }

        public IMovieRepository Movie
        {
            get
            {
                if (movie == null)
                    movie = new MovieRepository();
                return movie;
            }
        }

        public void Save()
        {
            
        }
    }
}
