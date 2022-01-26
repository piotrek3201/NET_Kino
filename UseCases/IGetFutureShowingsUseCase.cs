using CoreBusiness;

namespace UseCases
{
    public interface IGetFutureShowingsUseCase
    {
        IEnumerable<Showing> Execute();
    }
}