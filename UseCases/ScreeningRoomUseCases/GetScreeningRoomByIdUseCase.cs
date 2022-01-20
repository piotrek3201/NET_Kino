using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
    public class GetScreeningRoomByIdUseCase : IGetScreeningRoomByIdUseCase
    {
        private readonly IScreeningRoomRepository screeningRoomRepository;

        public GetScreeningRoomByIdUseCase(IScreeningRoomRepository screeningRoomRepository)
        {
            this.screeningRoomRepository = screeningRoomRepository;
        }

        public ScreeningRoom Execute(int screeningRoomId)
        {
            return screeningRoomRepository.GetScreeningRoomById(screeningRoomId);
        }
    }
}
