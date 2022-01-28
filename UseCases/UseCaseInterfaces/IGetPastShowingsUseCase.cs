using CoreBusiness;

namespace UseCases
{
    public interface IGetPastShowingsUseCase
    {
        IEnumerable<Showing> Execute();
    }
}