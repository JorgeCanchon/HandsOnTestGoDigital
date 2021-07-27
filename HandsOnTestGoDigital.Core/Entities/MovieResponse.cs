using HandsOnTestGoDigital.Core.Models;
using System.Collections.Generic;

namespace HandsOnTestGoDigital.Core.Entities
{
    public class MovieResponse
    {
        public int Page { get; set; }
        public List<Movie> Results { get; set; }
        public int Total_pages { get; set; }
        public int Total_results { get; set; }
    }
}
