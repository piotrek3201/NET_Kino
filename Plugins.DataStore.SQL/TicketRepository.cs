using CoreBusiness;
using System.Net.Mail;
using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;
using UseCases.DataStorePluginInterfaces;
using System.Net;

namespace Plugins.DataStore.SQL
{
    public class TicketRepository : ITicketRepository
    {
        private readonly CinemaContext db;
        private static Random random = new Random();

        public TicketRepository(CinemaContext db)
        {
            this.db = db;
        }

        public IEnumerable<Ticket> GetTickets()
        {
            return db.Tickets;
        }

        public void FinalizeTicket(Ticket ticket, List<Reservation> linkedReservations, Showing linkedShowing, 
            Movie linkedMovie, string localhost, bool isCashier)
        {
            // link reservations
            ticket.Reservations.Clear();
            foreach (Reservation lr in linkedReservations) ticket.Reservations.Add(lr);

            // generate qr code for ticket and db
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            //TODO: append a unique string of characters (random + ticketId)
            ticket.QRString = new string(Enumerable.Repeat(chars, 9)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            ticket.QRString = ticket.QRString + ticket.TicketId.ToString();

            using (MemoryStream ms = new MemoryStream())
            {
                QRCodeGenerator oQRCodeGenerator = new QRCodeGenerator();
                QRCodeData oQRCodeData = oQRCodeGenerator.CreateQrCode(ticket.QRString, QRCodeGenerator.ECCLevel.Q);
                QRCode oQRCode = new QRCode(oQRCodeData);

                using (Bitmap bitmap = oQRCode.GetGraphic(20))
                {
                    bitmap.Save(ms, ImageFormat.Png);
                    ticket.QRStringImage = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
                }
            }

            // save ticket
            db.SaveChanges();

            if (!isCashier) // fill out mail and send ticket
            {
                string Subject;
                if (IsTicketValid(ticket)) Subject = "Twój bilet do Kina NET na film \"" + linkedMovie.Title + "\"!";
                else Subject = "Twoja rezerwacja do Kina NET na film \"" + linkedMovie.Title + "\"!";         

                string Body = "<h1 style=\"text-align:center\">Witaj w naszym kinie!" +
                    "<br/>W linku poniżej znajdziesz swój bilet.</h1>" +
                    "<div style=\"text-align:center;font-size:x-large\"><a href=\"" + localhost
                    + "ticket/" + ticket.QRString +
                    "\">Kliknij tutaj, aby obejrzeć bilet.</a></div>" +
                    "<br/><p style=\"text-align:center;font-size:larger\">Film: " + linkedMovie.Title +
                    "<br/>Numer Twojej sali: " + linkedShowing.ScreeningRoomId +
                    "<br/>Data: " + linkedShowing.Date.ToShortTimeString()
                    + " " + linkedShowing.Date.ToShortDateString() +
                    "<br/>Twoje miejsca: ";

                foreach (Reservation lr in linkedReservations)
                {
                    char rLetter = (char)(lr.RowNumber + 64);
                    Body += rLetter.ToString() + lr.ColumnNumber.ToString() + " ";
                }

                Body += "<br/><br/>Kod Twojego biletu: " + ticket.QRString;

                Body += "</p><h2 style=\"text-align:center\">Życzymy udanego seansu!<br/>Zespół Kino NET</h2>";

                try // send mail
                {
                    using (MailMessage mail = new MailMessage())
                    {
                        mail.From = new MailAddress("kino.net.projekt@gmail.com");
                        mail.To.Add(ticket.ClientMail);
                        mail.Subject = Subject;
                        mail.Body = Body;
                        mail.IsBodyHtml = true;

                        using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                        {
                            smtp.Credentials = new System.Net.NetworkCredential("kino.net.projekt@gmail.com", "Comand94");
                            smtp.EnableSsl = true;
                            smtp.Send(mail);
                        }
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public void AddTicket(Ticket ticket)
        {
            db.Tickets.Add(ticket);
            db.SaveChanges();
        }

        public void DeleteTicketByIds(string clientMail, int ticketId)
        {
            Ticket? ticketToDelete = db.Tickets.FirstOrDefault(x =>
                                x.ClientMail == clientMail && x.TicketId == ticketId);

            if (ticketToDelete != null)
            {
                db.Tickets.Remove(ticketToDelete);
                db.SaveChanges();
            }
        }

        public IEnumerable<Ticket> GetTicketsByMail(string clientMail)
        {
            return db.Tickets.ToList().FindAll(x => x.ClientMail == clientMail);
        }

        public Ticket GetTicketByQRString(string pQRString)
        {
            return db.Tickets.FirstOrDefault(x =>
                                x.QRString == pQRString);
        }

        public bool IsTicketValid(Ticket ticket)
        {
            Reservation r = db.Reservations.FirstOrDefault(x => x.TicketId == ticket.TicketId);
            Showing s = db.Showings.FirstOrDefault(x => x.ShowingId == r.ShowingId);
            if (r != null && s != null && r.ReservationExpirationDate > s.Date) return true;
            else return false;
        }
    }
}
