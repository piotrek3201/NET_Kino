using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
    public class DeleteReservationByPositionUseCase : IDeleteReservationByPositionUseCase
    {
        private readonly IReservationRepository reservationRepository;

        public DeleteReservationByPositionUseCase(IReservationRepository reservationRepository)
        {
            this.reservationRepository = reservationRepository;
        }
        public void Execute(int showingId, int seatRow, int seatColumn)
        {
            reservationRepository.DeleteReservationByPosition(showingId, seatRow, seatColumn);
        }
    }
}
