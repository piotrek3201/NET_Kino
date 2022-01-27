using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
    public class GetReservationsByTicketUseCase : IGetReservationsByTicketUseCase
    {
        private readonly IReservationRepository reservationRepository;

        public GetReservationsByTicketUseCase(IReservationRepository reservationRepository)
        {
            this.reservationRepository = reservationRepository;
        }
        public IEnumerable<Reservation> Execute(string clientMail, int ticketId)
        {
            return reservationRepository.GetReservationsByTicket(clientMail, ticketId);
        }
    }
}
