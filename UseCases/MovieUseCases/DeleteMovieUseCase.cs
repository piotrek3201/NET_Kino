using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
    public class DeleteMovieUseCase : IDeleteMovieUseCase
    {
        private readonly IMovieRepository movieRepository;

        public DeleteMovieUseCase(IMovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;
        }
        public void Delete(int movieId)
        {
            movieRepository.DeleteMovie(movieId);
        }
    }
}
