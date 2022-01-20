using CoreBusiness;

namespace UseCases
{
    public interface IGetScreeningRoomByIdUseCase
    {
        ScreeningRoom Execute(int screeningRoomId);
    }
}