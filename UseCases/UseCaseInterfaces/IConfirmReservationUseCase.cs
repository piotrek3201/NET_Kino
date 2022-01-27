using CoreBusiness;

namespace UseCases
{
    public interface IConfirmReservationUseCase
    {
        void Execute(Reservation reservation);
    }
}
