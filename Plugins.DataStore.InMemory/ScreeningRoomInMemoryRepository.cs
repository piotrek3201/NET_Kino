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
                new ScreeningRoom(){ScreeningRoomID = 1, ScreeningRoomName = "1", ColumnCount = 10, RowCount = 5},
                new ScreeningRoom(){ScreeningRoomID = 2, ScreeningRoomName = "2", ColumnCount = 10, RowCount = 5},
                new ScreeningRoom(){ScreeningRoomID = 3, ScreeningRoomName = "3", ColumnCount = 15, RowCount = 7}
            };
        }

        public void AddScreeningRoom(ScreeningRoom screeningRoom)
        {
            if (screeningRooms.Any(x => x.ScreeningRoomName.Equals(screeningRoom.ScreeningRoomName, StringComparison.OrdinalIgnoreCase))) return;

            if(screeningRooms != null && screeningRooms.Count > 0)
            {
                var maxID = screeningRooms.Max(x => x.ScreeningRoomID);
                screeningRoom.ScreeningRoomID = maxID + 1;
            }
            else
            {
                screeningRoom.ScreeningRoomID = 1;
            }

            screeningRooms.Add(screeningRoom);
        }

        public IEnumerable<ScreeningRoom> GetScreeningRooms()
        {
            return screeningRooms;
        }

        public ScreeningRoom GetScreeningRoomById(int screeningRoomId)
        {
            return screeningRooms?.FirstOrDefault(x => x.ScreeningRoomID == screeningRoomId);
        }

        public void UpdateScreeningRoom(ScreeningRoom screeningRoom)
        {
            var screeningRoomToUpdate = GetScreeningRoomById(screeningRoom.ScreeningRoomID);
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