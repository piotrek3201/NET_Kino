using CoreBusiness;
using UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;
using System.Net.Mail;
using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Plugins.DataStore.InMemory
{
    public class TicketInMemoryRepository : ITicketRepository
    {
        private List<Ticket> tickets;
        private static Random random = new Random();

        public TicketInMemoryRepository()
        {
            tickets = new List<Ticket>()
            { 
                new Ticket()
                {
                    ClientMail = "dawid.leszczynski@student.wat.edu.pl",
                    TicketId = 1,
                    QRString = "QWERTYUIO"
                },
                new Ticket()
                {
                    ClientMail = "piotr.kaluzinski@student.wat.edu.pl",
                    TicketId = 2,
                    QRString = "ASDFGHJKL"
                }
            };
        }

        public IEnumerable<Ticket> GetTickets()
        {
            return tickets; 
        }

        public void FinalizeTicket(Ticket ticket, List<Reservation> linkedReservations, Showing linkedShowing, Movie linkedMovie, string localhost)
        {
            // check if ticket like this already exists, if it does then RETURN
            if (tickets.Any(x => x.ClientMail == ticket.ClientMail &&
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
            tickets.Add(ticket);

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
            ticket.TicketId = tickets.Max(x => x.TicketId) + 1;
        }

        public void DeleteTicketByIds(string clientMail, int ticketId)
        {
            Ticket? ticketToDelete = tickets.FirstOrDefault(x => 
                                x.ClientMail == clientMail && x.TicketId == ticketId);

            if (ticketToDelete != null) tickets.Remove(ticketToDelete);
        }

        public IEnumerable<Ticket> GetTicketsByMail(string clientMail)
        {
            return tickets.FindAll(x => x.ClientMail == clientMail);
        }

        public Ticket GetTicketByQRString(string pQRString)
        {
            return tickets.FirstOrDefault(x => x.QRString == pQRString);
        }
    }
}
