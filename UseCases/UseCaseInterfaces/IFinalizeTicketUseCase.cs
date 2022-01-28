using CoreBusiness;

namespace UseCases
{
    public interface IFinalizeTicketUseCase
    {
        void Execute(Ticket ticket, List<Reservation> linkedReservations, Showing linkedShowing, Movie linkedMovie);
    }
}