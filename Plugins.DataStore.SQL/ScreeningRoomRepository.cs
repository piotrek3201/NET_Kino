using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.SQL
{
    public class ScreeningRoomRepository : IScreeningRoomRepository
    {
        private readonly CinemaContext db;

        public ScreeningRoomRepository(CinemaContext db)
        {
            this.db = db;
        }

        public void AddScreeningRoom(ScreeningRoom screeningRoom)
        {
            db.ScreeningRooms.Add(screeningRoom);
        }

        public void DeleteScreeningRoom(int screeningRoomId)
        {
            var screeningRoom = db.ScreeningRooms.Find(screeningRoomId);
            if (screeningRoomId == null) return;

            db.ScreeningRooms.Remove(screeningRoom);
            db.SaveChanges();
        }

        public ScreeningRoom GetScreeningRoomById(int screeningRoomId)
        {
            return db.ScreeningRooms.Find(screeningRoomId);
        }

        public IEnumerable<ScreeningRoom> GetScreeningRooms()
        {
            return db.ScreeningRooms.ToList();
        }

        public void UpdateScreeningRoom(ScreeningRoom screeningRoom)
        {
            var screeningRoomToUpdate = db.ScreeningRooms.Find(screeningRoom.ScreeningRoomId);
            if (screeningRoomToUpdate != null)
            {
                screeningRoomToUpdate.ScreeningRoomName = screeningRoom.ScreeningRoomName;
                screeningRoomToUpdate.ColumnCount = screeningRoom.ColumnCount;
                screeningRoomToUpdate.RowCount = screeningRoom.RowCount;
            }
            db.SaveChanges();
        }
    }
}
