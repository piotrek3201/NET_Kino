using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases
{
    public interface IShowingRepository
    {
        IEnumerable<Showing> GetShowings();
        void AddShowing(Showing showing);
        Showing GetShowingById(int showingId);
        void UpdateShowing(Showing showing);
        void DeleteShowing(int showingId);
        IEnumerable<Showing> GetFutureShowings();
        IEnumerable<Showing> GetShowingsByDay(DateTime day);
        IEnumerable<Showing> GetFutureShowingsByMovie(Movie movie);
        IEnumerable<Showing> GetPastShowings();
    }
}
