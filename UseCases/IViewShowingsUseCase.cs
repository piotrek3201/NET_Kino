using CoreBusiness;

namespace UseCases
{
    public interface IViewShowingsUseCase
    {
        IEnumerable<Showing> Execute();
    }
}