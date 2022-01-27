using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
    public class GetTicketsByMailUseCase : IGetTicketsByMailUseCase
    {
        private readonly ITicketRepository ticketRepository;

        public GetTicketsByMailUseCase(ITicketRepository ticketRepository)
        {
            this.ticketRepository = ticketRepository;
        }
        public IEnumerable<Ticket> Execute(string clientMail)
        {
            return ticketRepository.GetTicketsByMail(clientMail);
        }
    }
}
