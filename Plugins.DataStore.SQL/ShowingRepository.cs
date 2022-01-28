using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;
using CoreBusiness;
using UseCases;

namespace Plugins.DataStore.SQL
{
    public class ShowingRepository : IShowingRepository
    {
        private readonly CinemaContext db;
        public ShowingRepository(CinemaContext db)
        {
            this.db = db;
        }

        public void AddShowing(Showing showing)
        {
            db.Showings.Add(showing);
            db.SaveChanges();
        }

        public void DeleteShowing(int showingId)
        {
            db.Showings?.Remove(GetShowingById((int)showingId));
            db.SaveChanges();
        }

        public Showing GetShowingById(int showingId)
        {
            return db.Showings?.FirstOrDefault(x => x.ShowingId == showingId);
        }

        public IEnumerable<Showing> GetShowings()
        {
            return db.Showings.OrderBy(x => x.Date);
        }

        public void UpdateShowing(Showing showing)
        {
            var showingToUpdate = db.Showings.Find(showing.ShowingId);
            if (showingToUpdate != null)
            {
                showingToUpdate.ScreeningRoomId = showing.ScreeningRoomId;
                showingToUpdate.MovieId = showing.MovieId;
                showingToUpdate.Date = showing.Date;
                showingToUpdate.TicketPrice = showing.TicketPrice;
                showingToUpdate.Dubbing = showing.Dubbing;
            }
            db.SaveChanges();
        }

        public IEnumerable<Showing> GetFutureShowings()
        {
            return db.Showings.Where(x => x.Date >= DateTime.Now).OrderBy(x => x.Date);
        }

        public IEnumerable<Showing> GetFutureShowingsByMovie(Movie movie)
        {
            return db.Showings.Where(x => x.Date.Date >= DateTime.Today.Date &&
                                    x.MovieId == movie.MovieId).OrderBy(x => x.Date);
        }

        public IEnumerable<Showing> GetShowingsByDay(DateTime day)
        {
            return db.Showings.Where(x => x.Date.Date == day.Date);
        }

        public IEnumerable<Showing> GetPastShowings()
        {
            return db.Showings.Where(x => x.Date <= DateTime.Now).OrderByDescending(x => x.Date);
        }
    }
}
