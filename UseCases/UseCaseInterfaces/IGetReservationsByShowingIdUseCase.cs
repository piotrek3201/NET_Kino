using CoreBusiness;

namespace UseCases
{
    public interface IGetReservationsByShowingIdUseCase
    {
        IEnumerable<Reservation> Execute(int showingId);
    }
}
