using CoreBusiness;

namespace UseCases
{
    public interface IAddTicketUseCase
    {
        void Execute(Ticket ticket, List<Reservation> linkedReservations, Showing linkedShowing, Movie linkedMovie);
    }
}