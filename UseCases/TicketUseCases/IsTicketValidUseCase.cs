using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
    public class IsTicketValidUseCase : IIsTicketValidUseCase
    {
        private readonly ITicketRepository ticketRepository;

        public IsTicketValidUseCase(ITicketRepository ticketRepository)
        {
            this.ticketRepository = ticketRepository;
        }
        public bool Execute(Ticket ticket)
        {
            return ticketRepository.IsTicketValid(ticket);
        }
    }
}
