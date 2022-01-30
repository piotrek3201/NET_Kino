using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
    public class ConfirmReservationUseCase : IConfirmReservationUseCase
    {
        private readonly IReservationRepository reservationRepository;

        public ConfirmReservationUseCase(IReservationRepository reservationRepository)
        {
            this.reservationRepository = reservationRepository;
        }
        public void Execute(Reservation reservation, bool payment)
        {
            reservationRepository.ConfirmReservation(reservation, payment);
        }
    }
}
