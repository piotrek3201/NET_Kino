using CoreBusiness;

namespace UseCases
{
    public interface IGetFutureShowingsByMovieUseCase
    {
        IEnumerable<Showing> Execute(Movie movie);
    }
}