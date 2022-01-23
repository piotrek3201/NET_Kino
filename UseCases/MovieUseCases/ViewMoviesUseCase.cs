using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
    public class ViewMoviesUseCase : IViewMoviesUseCase
    {
        private readonly IMovieRepository movieRepository;

        public ViewMoviesUseCase(IMovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;
        }

        public IEnumerable<Movie> Execute()
        {
            return movieRepository.GetMovies();
        }
    }
}
