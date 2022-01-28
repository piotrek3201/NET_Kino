using CoreBusiness;
using System.Net.Mail;
using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;
using UseCases.DataStorePluginInterfaces;

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

        public void FinalizeTicket(Ticket ticket, List<Reservation> linkedReservations, Showing linkedShowing, Movie linkedMovie)
        {
            // check if ticket like this already exists, if it does then RETURN
            if (db.Tickets.Any(x => x.ClientMail == ticket.ClientMail &&
                               x.TicketId == ticket.TicketId)) return;

            // generate qr code for ticket and db
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            //TODO: append a unique string of characters (user id + ticket id I reckon)
            ticket.QRString = new string(Enumerable.Repeat(chars, 9)
                .Select(s => s[random.Next(s.Length)]).ToArray());

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
            db.Tickets.Add(ticket);
            db.SavedChanges();

            // fill out mail and send ticket
            string Subject = "Twój bilet do Kina NET na film \"" + linkedMovie.Title + "\"!";

            string Body = "Witaj w naszym kinie! Poniżej znajdziesz swój bilet." +
                "\n\nFilm: " + linkedMovie.Title + "\nData: " + linkedShowing.Date +
                "\nTwoja sala: " + linkedShowing.ScreeningRoomId +
                "\nTwoje miejsca: ";

            foreach (Reservation lr in linkedReservations)
            {
                char rLetter = (char)(lr.RowNumber + 64);
                Body += rLetter.ToString() + lr.ColumnNumber.ToString() + " ";
            }

            Body += "\n\n Kod twojego biletu: " + ticket.QRString;

            try // send mail
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress("kino.net.projekt@gmail.com");
                    mail.To.Add(ticket.ClientMail);
                    mail.Subject = Subject;
                    mail.Body = Body;

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

        public void AddTicket(Ticket ticket)
        {
            ticket.TicketId = db.Tickets.Max(x => x.TicketId) + 1;
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
    }
}
