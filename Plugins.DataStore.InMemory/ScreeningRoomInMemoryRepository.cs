using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory
{
    public class ScreeningRoomInMemoryRepository : IScreeningRoomRepository
    {
        private List<ScreeningRoom> screeningRooms;

        public ScreeningRoomInMemoryRepository()
        {
            screeningRooms = new List<ScreeningRoom>()
            {
                new ScreeningRoom(){ScreeningRoomId = 1, ScreeningRoomName = "1", ColumnCount = 10, RowCount = 5},
                new ScreeningRoom(){ScreeningRoomId = 2, ScreeningRoomName = "2", ColumnCount = 10, RowCount = 5},
                new ScreeningRoom(){ScreeningRoomId = 3, ScreeningRoomName = "3", ColumnCount = 15, RowCount = 7}
            };
        }

        public void AddScreeningRoom(ScreeningRoom screeningRoom)
        {
            if (screeningRooms.Any(x => x.ScreeningRoomName.Equals(screeningRoom.ScreeningRoomName, StringComparison.OrdinalIgnoreCase))) return;

            if(screeningRooms != null && screeningRooms.Count > 0)
            {
                var maxID = screeningRooms.Max(x => x.ScreeningRoomId);
                screeningRoom.ScreeningRoomId = maxID + 1;
            }
            else
            {
                screeningRoom.ScreeningRoomId = 1;
            }

            screeningRooms.Add(screeningRoom);
        }

        public IEnumerable<ScreeningRoom> GetScreeningRooms()
        {
            return screeningRooms;
        }

        public ScreeningRoom GetScreeningRoomById(int screeningRoomId)
        {
            return screeningRooms?.FirstOrDefault(x => x.ScreeningRoomId == screeningRoomId);
        }

        public void UpdateScreeningRoom(ScreeningRoom screeningRoom)
        {
            var screeningRoomToUpdate = GetScreeningRoomById(screeningRoom.ScreeningRoomId);
            if(screeningRoomToUpdate != null)
            {
                screeningRoomToUpdate.ScreeningRoomName = screeningRoom.ScreeningRoomName;
                screeningRoomToUpdate.ColumnCount = screeningRoom.ColumnCount;
                screeningRoomToUpdate.RowCount = screeningRoom.RowCount;
            }
        }

        public void DeleteScreeningRoom(int screeningRoomId)
        {
            screeningRooms?.Remove(GetScreeningRoomById((int)screeningRoomId));
        }
    }
}