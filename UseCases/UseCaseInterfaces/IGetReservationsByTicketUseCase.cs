using CoreBusiness;

namespace UseCases
{
    public interface IGetReservationsByTicketUseCase
    {
        IEnumerable<Reservation> Execute(string clientMail, int ticketId);
    }
}
