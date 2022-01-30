using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
    public class FinalizeTicketUseCase : IFinalizeTicketUseCase
    {
        private readonly ITicketRepository ticketRepository;

        public FinalizeTicketUseCase(ITicketRepository ticketRepository)
        {
            this.ticketRepository = ticketRepository;
        }
        public void Execute(Ticket ticket, List<Reservation> linkedReservations, Showing linkedShowing, 
            Movie linkedMovie, string localhost, bool isCashier)
        {
            ticketRepository.FinalizeTicket(ticket, linkedReservations, linkedShowing, linkedMovie, localhost, isCashier);
        }
    }
}
