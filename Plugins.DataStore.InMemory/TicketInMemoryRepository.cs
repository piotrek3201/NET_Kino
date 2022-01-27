using CoreBusiness;
using UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;
using System.Net.Mail;

namespace Plugins.DataStore.InMemory
{
    public class TicketInMemoryRepository : ITicketRepository
    {
        private List<Ticket> tickets;

        public TicketInMemoryRepository()
        {
            tickets = new List<Ticket>()
            { 
                new Ticket()
                {
                    ClientMail = "dawid.leszczynski@student.wat.edu.pl",
                    TicketId = 1,
                    QRString = "test string"
                }
            };
        }

        public IEnumerable<Ticket> GetTickets()
        {
            return tickets; 
        }

        public void AddTicket(Ticket ticket, List<Reservation> linkedReservations, Showing linkedShowing, Movie linkedMovie)
        {
            // check if ticket like this already exists, if it does then RETURN
            if (tickets.Any(x => x.ClientMail == ticket.ClientMail &&
                               x.TicketId == ticket.TicketId)) return;

            // save ticket
            tickets.Add(ticket);

            // fill out mail
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
    }
}
