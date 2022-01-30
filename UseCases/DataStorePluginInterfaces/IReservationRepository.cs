using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreBusiness;

namespace UseCases.DataStorePluginInterfaces
{
    public interface IReservationRepository
    {
        IEnumerable<Reservation> GetReservations();
        IEnumerable<Reservation> GetReservationsByTicket(string clientMail, int ticketId);
        void AddReservation(Reservation reservation);
        void ConfirmReservation(Reservation reservation, bool payment);
        IEnumerable<Reservation> GetReservationsByShowingId(int showingId);
        void DeleteReservationByPosition(int showingId, int seatRow, int seatColumn);
        void DeleteExpiredReservationsByShowingId(int showingId);
    }
}
