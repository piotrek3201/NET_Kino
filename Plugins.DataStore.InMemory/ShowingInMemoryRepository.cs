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
                    Date = DateTime.Today,
                    TicketPrice = 20
                },
                new Showing()
                {
                    ShowingId = 2,
                    ScreeningRoomId = 1,
                    MovieId = 2,
                    Date = DateTime.Today.AddDays(1),
                    TicketPrice = 20
                },
                new Showing()
                {
                    ShowingId = 3,
                    ScreeningRoomId = 2,
                    MovieId = 1,
                    Date = DateTime.Today.AddDays(1),
                    TicketPrice = 20
                },
                new Showing()
                {
                    ShowingId = 4,
                    ScreeningRoomId = 3,
                    MovieId = 1,
                    Date = DateTime.Today.AddDays(2),
                    TicketPrice = 20
                }
            };
        }

        public void AddShowing(Showing showing)
        {
            //TODO: sprawdzanie
            //if (showings.Any(x => x.ScreeningRoomName.Equals(showings.ScreeningRoomName, StringComparison.OrdinalIgnoreCase))) return;

            if (showings != null && showings.Count > 0)
            {
                var maxID = showings.Max(x => x.ShowingId);
                showing.ShowingId = maxID + 1;
            }
            else
            {
                showing.ShowingId = 1;
            }

            showings.Add(showing);
        }

        public void DeleteShowing(int showingId)
        {
            showings?.Remove(GetShowingById((int)showingId));
        }

        public Showing GetShowingById(int showingId)
        {
            return showings?.FirstOrDefault(x => x.ShowingId == showingId);
        }

        public IEnumerable<Showing> GetShowings()
        {
            return showings;
        }

        public void UpdateShowing(Showing showing)
        {
            var showingToUpdate = GetShowingById(showing.ShowingId);
            if (showingToUpdate != null)
            {
                showingToUpdate.ScreeningRoomId = showing.ScreeningRoomId;
                showingToUpdate.MovieId = showing.MovieId;
                showingToUpdate.Date = showing.Date;
                showingToUpdate.TicketPrice = showing.TicketPrice;
            }
        }

        public IEnumerable<Showing> GetFutureShowings()
        {
            return showings.Where(x => x.Date >= DateTime.Today);
        }
    }
}
