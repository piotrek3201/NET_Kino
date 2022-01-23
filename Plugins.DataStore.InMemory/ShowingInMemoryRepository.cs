using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases;

namespace Plugins.DataStore.InMemory
{
    public class ShowingInMemoryRepository : IShowingRepository
    {
        private List<Showing> showings;
        public ShowingInMemoryRepository()
        {
            showings = new List<Showing>()
            {
                new Showing()
                {
                    ShowingId = 1,
                    ScreeningRoomId = 1,
                    MovieId = 2,
                    Date = DateTime.Now,
                    TicketPrice = 20
                }
            };
        }
        public IEnumerable<Showing> GetShowings()
        {
            return showings;
        }
    }
}
