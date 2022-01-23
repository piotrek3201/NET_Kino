using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
    public class DeleteScreeningRoomUseCase : IDeleteScreeningRoomUseCase
    {
        private readonly IScreeningRoomRepository screeningRoomRepository;

        public DeleteScreeningRoomUseCase(IScreeningRoomRepository screeningRoomRepository)
        {
            this.screeningRoomRepository = screeningRoomRepository;
        }

        public void Delete(int screeningRoomId)
        {
            screeningRoomRepository.DeleteScreeningRoom(screeningRoomId);
        }
    }
}
