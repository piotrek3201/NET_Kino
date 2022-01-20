using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
    public class EditScreeningRoomUseCase : IEditScreeningRoomUseCase
    {
        private readonly IScreeningRoomRepository screeningRoomRepository;

        public EditScreeningRoomUseCase(IScreeningRoomRepository screeningRoomRepository)
        {
            this.screeningRoomRepository = screeningRoomRepository;
        }

        public void Execute(ScreeningRoom screeningRoom)
        {
            screeningRoomRepository.UpdateScreeningRoom(screeningRoom);
        }
    }
}
