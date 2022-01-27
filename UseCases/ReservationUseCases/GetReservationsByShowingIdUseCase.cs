using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
    public class GetReservationsByShowingIdUseCase : IGetReservationsByShowingIdUseCase
    {
        private readonly IReservationRepository reservationRepository;

        public GetReservationsByShowingIdUseCase(IReservationRepository reservationRepository)
        {
            this.reservationRepository = reservationRepository;
        }
        public IEnumerable<Reservation> Execute(int showingID)
        {
            return reservationRepository.GetReservationsByShowingId(showingID);
        }
    }
}
