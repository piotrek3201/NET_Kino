using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
    public class AddTicketUseCase : IAddTicketUseCase
    {
        private readonly ITicketRepository ticketRepository;

        public AddTicketUseCase(ITicketRepository ticketRepository)
        {
            this.ticketRepository = ticketRepository;
        }
        public void Execute(Ticket ticket)
        {
            ticketRepository.AddTicket(ticket);
        }
    }
}
