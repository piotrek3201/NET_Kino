using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
    public class GetTicketByQRStringUseCase : IGetTicketByQRStringUseCase
    {
        private readonly ITicketRepository ticketRepository;

        public GetTicketByQRStringUseCase(ITicketRepository ticketRepository)
        {
            this.ticketRepository = ticketRepository;
        }
        public Ticket Execute(string pQRString)
        {
            return ticketRepository.GetTicketByQRString(pQRString);
        }
    }
}
