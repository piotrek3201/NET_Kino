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
            if (db.Reservations.Any(x => x.ShowingId == reservation.ShowingId &&
                                x.RowNumber == reservation.RowNumber &&
                                x.ColumnNumber == reservation.ColumnNumber)) return;

            reservation.ReservationExpirationDate = DateTime.Now.AddMinutes(5);

            db.Reservations.Add(reservation);
            db.SaveChanges();
        }

        public void ConfirmReservation(Reservation reservation, bool purchase)
        {
            Reservation? reservationToConfirm = db.Reservations.FirstOrDefault(x =>
                                x.ShowingId == reservation.ShowingId &&
                                x.RowNumber == reservation.RowNumber &&
                                x.ColumnNumber == reservation.ColumnNumber);

            if (reservationToConfirm != null)
            {
                // reservation is paid for
                if (purchase) reservationToConfirm.ReservationExpirationDate = reservation.Showing.Date.AddYears(2);

                // reservation was made, but was not paid for
                else reservationToConfirm.ReservationExpirationDate = reservation.Showing.Date.AddMinutes(-20);

                db.SaveChanges();
            }
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

        public void DeleteExpiredReservationsByShowingId(int showingId)
        {
            IEnumerable<Reservation> reservations = GetReservationsByShowingId(showingId);
            reservations = reservations.ToList().FindAll(x => x.ReservationExpirationDate < DateTime.Now);
            foreach (Reservation r in reservations)
            {
                db.Reservations.Remove(r);
            }
            
            db.SaveChanges();
        }
    }
}
