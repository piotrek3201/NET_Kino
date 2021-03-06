using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

// THIS IS NOT UP TO DATE - SQL DATABASE IS NOW IN USE
namespace Plugins.DataStore.InMemory
{
    public class ReservationInMemoryRepository : IReservationRepository
    {
        private List<Reservation> reservations;

        public ReservationInMemoryRepository()
        {
            reservations = new List<Reservation>()
            {
                new Reservation()
                {
                    ReservationId = 1,
                    ShowingId = 1,
                    RowNumber = 4,
                    ColumnNumber = 6,
                    ReservationExpirationDate = DateTime.MaxValue,
                    TicketId = 1
                },
                new Reservation()
                {
                    ReservationId = 2,
                    ShowingId = 1,
                    RowNumber = 4,
                    ColumnNumber = 7,
                    ReservationExpirationDate = DateTime.MaxValue,
                    TicketId = 1
                },
                new Reservation()
                {
                    ReservationId = 3,
                    ShowingId = 1,
                    RowNumber = 3,
                    ColumnNumber = 2,
                    ReservationExpirationDate = DateTime.Now.AddMinutes(5),
                    TicketId = 2
                },
            };
        }

        public IEnumerable<Reservation> GetReservations()
        {
            return reservations;
        }

        public IEnumerable<Reservation> GetReservationsByTicket(string clientMail, int ticketId)
        {
            return reservations.FindAll(x => x.ClientMail == clientMail && x.TicketId == ticketId);
        }

        public void AddReservation(Reservation reservation)
        {
            //reservation.ReservationId = reservations.Max(x => x.ReservationId) + 1;

            if (reservations.Any(x => x.ShowingId == reservation.ShowingId &&
                                x.RowNumber == reservation.RowNumber &&
                                x.ColumnNumber == reservation.ColumnNumber)) return;

            reservations.Add(reservation);
        }

        public void ConfirmReservation(Reservation reservation, bool payment)
        {
            Reservation? reservationToConfirm = reservations.FirstOrDefault(x => 
                                x.ShowingId == reservation.ShowingId &&
                                x.RowNumber == reservation.RowNumber &&
                                x.ColumnNumber == reservation.ColumnNumber);

            if (reservationToConfirm != null) reservationToConfirm.ReservationExpirationDate = DateTime.Now.AddYears(5);
        }
        
        public IEnumerable<Reservation> GetReservationsByShowingId(int showingId)
        {
            return reservations.FindAll(x => x.ShowingId == showingId);
        }

        public void DeleteReservationByPosition(int showingId, int seatRow, int seatColumn)
        {
            Reservation? reservationToDelete = reservations.FirstOrDefault(x => x.ShowingId == showingId &&
                                x.RowNumber == seatRow &&
                                x.ColumnNumber == seatColumn);
            if (reservationToDelete != null) reservations.Remove(reservationToDelete);
        }

        public void DeleteExpiredReservationsByShowingId(int showingId)
        {
            IEnumerable<Reservation> reservationsToDelete = GetReservationsByShowingId(showingId);
            reservations = reservations.ToList().FindAll(x => x.ReservationExpirationDate < DateTime.Now);
            foreach (Reservation r in reservationsToDelete)
            {
                reservations.Remove(r);
            }
        }
    }
}
