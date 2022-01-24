using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
    public class AddMovieUseCase : IAddMovieUseCase
    {
        private readonly IMovieRepository movieRepository;

        public AddMovieUseCase(IMovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;
        }
        public void Execute(Movie movie)
        {
            movieRepository.AddMovie(movie);
        }
    }
}
