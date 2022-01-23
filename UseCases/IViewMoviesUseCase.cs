using CoreBusiness;

namespace UseCases
{
    public interface IViewMoviesUseCase
    {
        IEnumerable<Movie> Execute();
    }
}