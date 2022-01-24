using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
    public class GetMovieByIdUseCase : IGetMovieByIdUseCase
    {
        private readonly IMovieRepository movieRepository;

        public GetMovieByIdUseCase(IMovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;
        }

        public Movie Execute(int movieId)
        {
            return movieRepository.GetMovieById(movieId);
        }
    }
}
