using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
    public class AddScreeningRoomUseCase : IAddScreeningRoomUseCase
    {
        private readonly IScreeningRoomRepository screeningRoomRepository;

        public AddScreeningRoomUseCase(IScreeningRoomRepository screeningRoomRepository)
        {
            this.screeningRoomRepository = screeningRoomRepository;
        }
        public void Execute(ScreeningRoom screeningRoom)
        {
            screeningRoomRepository.AddScreeningRoom(screeningRoom);
        }
    }
}
