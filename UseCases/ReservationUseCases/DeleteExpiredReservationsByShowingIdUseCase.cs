using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
    public class DeleteExpiredReservationsByShowingIdUseCase : IDeleteExpiredReservationsByShowingIdUseCase
    {
        private readonly IReservationRepository reservationRepository;

        public DeleteExpiredReservationsByShowingIdUseCase(IReservationRepository reservationRepository)
        {
            this.reservationRepository = reservationRepository;
        }
        public void Execute(int showingId)
        {
            reservationRepository.DeleteExpiredReservationsByShowingId(showingId);
        }
    }
}
