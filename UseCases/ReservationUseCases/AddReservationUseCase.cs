using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
    public class AddReservationUseCase : IAddReservationUseCase
    {
        private readonly IReservationRepository reservationRepository;

        public AddReservationUseCase(IReservationRepository reservationRepository)
        {
            this.reservationRepository = reservationRepository;
        }
        public void Execute(Reservation reservation)
        {
            reservationRepository.AddReservation(reservation);
        }
    }
}
