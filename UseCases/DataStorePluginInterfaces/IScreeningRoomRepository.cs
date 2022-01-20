using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.DataStorePluginInterfaces
{
    public interface IScreeningRoomRepository
    {
        IEnumerable<ScreeningRoom> GetScreeningRooms();
        void AddScreeningRoom(ScreeningRoom screeningRoom);
        ScreeningRoom GetScreeningRoomById(int screeningRoomId);
        void UpdateScreeningRoom(ScreeningRoom screeningRoom);
        void DeleteScreeningRoom(int screeningRoomId);
    }
}
