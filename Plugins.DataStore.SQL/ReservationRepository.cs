using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.SQL
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly CinemaContext db;

        public ReservationRepository(CinemaContext db)
        {
            this.db = db;
        }

        public IEnumerable<Reservation> GetReservations()
        {
            return db.Reservations;
        }

        public IEnumerable<Reservation> GetReservationsByTicket(string clientMail, int ticketId)
        {
            return db.Reservations.ToList().FindAll(x => x.ClientMail == clientMail && x.TicketId == ticketId);
        }

        public void AddReservation(Reservation reservation)
        {
            reservation.ReservationId = db.Reservations.Max(x => x.ReservationId) + 1;

            if (db.Reservations.Any(x => x.ShowingId == reservation.ShowingId &&
                                x.RowNumber == reservation.RowNumber &&
                                x.ColumnNumber == reservation.ColumnNumber)) return;

            db.Reservations.Add(reservation);
            db.SaveChanges();
        }

        public void ConfirmReservation(Reservation reservation)
        {
            Reservation? reservationToConfirm = db.Reservations.FirstOrDefault(x =>
                                x.ShowingId == reservation.ShowingId &&
                                x.RowNumber == reservation.RowNumber &&
                                x.ColumnNumber == reservation.ColumnNumber);

            if (reservationToConfirm != null) reservationToConfirm.ReservationExpirationDate = DateTime.Now.AddYears(5);
        }

        public IEnumerable<Reservation> GetReservationsByShowingId(int showingId)
        {
            return db.Reservations.ToList().FindAll(x => x.ShowingId == showingId);
        }

        public void DeleteReservationByPosition(int showingId, int seatRow, int seatColumn)
        {
            Reservation? reservationToDelete = db.Reservations.FirstOrDefault(x => x.ShowingId == showingId &&
                                x.RowNumber == seatRow &&
                                x.ColumnNumber == seatColumn);
            if (reservationToDelete != null)
            {
                db.Reservations.Remove(reservationToDelete);
                db.SaveChanges();
            }
        }
    }
}
