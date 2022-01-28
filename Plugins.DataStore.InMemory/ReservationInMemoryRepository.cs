using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

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
                    ShowingId = 1,
                    RowNumber = 4,
                    ColumnNumber = 6,
                    ReservationExpirationDate = DateTime.MaxValue
                },
                new Reservation()
                {
                    ShowingId = 1,
                    RowNumber = 4,
                    ColumnNumber = 7,
                    ReservationExpirationDate = DateTime.MaxValue
                },
                new Reservation()
                {
                    ShowingId = 1,
                    RowNumber = 3,
                    ColumnNumber = 2,
                    ReservationExpirationDate = DateTime.Now.AddMinutes(5)
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
            if (reservations.Any(x => x.ShowingId == reservation.ShowingId &&
                                x.RowNumber == reservation.RowNumber &&
                                x.ColumnNumber == reservation.ColumnNumber)) return;

            reservations.Add(reservation);
        }

        public void ConfirmReservation(Reservation reservation)
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
    }
}
