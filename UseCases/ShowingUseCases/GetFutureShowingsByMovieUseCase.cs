using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases
{
    public class GetFutureShowingsByMovieUseCase : IGetFutureShowingsByMovieUseCase
    {
        private readonly IShowingRepository showingRepository;

        public GetFutureShowingsByMovieUseCase(IShowingRepository showingRepository)
        {
            this.showingRepository = showingRepository;
        }

        public IEnumerable<Showing> Execute(Movie movie)
        {
            return showingRepository.GetFutureShowingsByMovie(movie);
        }
    }
}
