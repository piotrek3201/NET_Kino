using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
    public class DeleteTicketByIdsUseCase : IDeleteTicketByIdsUseCase
    {
        private readonly ITicketRepository ticketRepository;

        public DeleteTicketByIdsUseCase(ITicketRepository ticketRepository)
        {
            this.ticketRepository = ticketRepository;
        }
        public void Execute(string clientMail, int ticketId)
        {
            ticketRepository.DeleteTicketByIds(clientMail, ticketId);
        }
    }
}
