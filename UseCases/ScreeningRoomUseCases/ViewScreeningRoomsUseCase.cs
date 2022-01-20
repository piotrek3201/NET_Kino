using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
    public class ViewScreeningRoomsUseCase : IViewScreeningRoomsUseCase
    {
        private readonly IScreeningRoomRepository screeningRoomRepository;

        public ViewScreeningRoomsUseCase(IScreeningRoomRepository screeningRoomRepository)
        {
            this.screeningRoomRepository = screeningRoomRepository;
        }

        public IEnumerable<ScreeningRoom> Execute()
        {
            return screeningRoomRepository.GetScreeningRooms();
        }
    }
}
