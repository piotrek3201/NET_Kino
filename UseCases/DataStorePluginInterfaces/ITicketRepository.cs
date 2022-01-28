using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreBusiness;

namespace UseCases.DataStorePluginInterfaces
{
    public interface ITicketRepository
    {
        IEnumerable<Ticket> GetTickets();
        void FinalizeTicket(Ticket ticket, List<Reservation> linkedReservations, Showing linkedShowing, Movie linkedMovie);
        void AddTicket(Ticket ticket);
        void DeleteTicketByIds(string clientMail, int ticketId);
        IEnumerable<Ticket> GetTicketsByMail(string clientMail);
    }
}
