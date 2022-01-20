using CoreBusiness;

namespace UseCases
{
    public interface IViewScreeningRoomsUseCase
    {
        IEnumerable<ScreeningRoom> Execute();
    }
}