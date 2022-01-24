using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory
{
    public class MovieInMemoryRepository : IMovieRepository
    {
        private List<Movie> movies;

        public MovieInMemoryRepository()
        {
            movies = new List<Movie>()
            {
                new Movie()
                {
                    MovieId = 1, 
                    Title = "Matrix Zmartwychwstania", 
                    Description = "Podążaj za Neo, który prowadzi zwyczajne życie w San Francisco, gdzie jego terapeuta przepisuje mu niebieskie pigułki. Jednak Morfeusz oferuje mu czerwoną pigułkę i ponownie otwiera jego umysł na świat Matrix.",
                    Length = 148,
                    Year = 2021,
                    AgeRestriction = 15,
                    ImageUrl = "https://fwcdn.pl/fpo/85/24/838524/7983979.6.jpg"
                },
                new Movie()
                {
                    MovieId = 2,
                    Title = "Nie czas umierać",
                    Description = "Na prośbę swojego starego przyjaciela, Felixa Leitera z CIA, James Bond bierze udział w misji odbicia porwanego naukowca. Trop prowadzi do niebezpiecznego złoczyńcy.",
                    Length = 163,
                    Year = 2021,
                    AgeRestriction = 15,
                    ImageUrl = "https://fwcdn.pl/fpo/77/78/757778/7966011.6.jpg"
                },
                new Movie()
                {
                    MovieId = 3,
                    Title = "Free Guy",
                    Description = "Pracownik banku odkrywa, że jest postacią niezależną w brutalnej przygodowej grze akcji.",
                    Length = 115,
                    Year = 2021,
                    AgeRestriction = 12,
                    ImageUrl = "https://fwcdn.pl/fpo/82/06/828206/7969398.6.jpg"
                }
            };
        }

        public IEnumerable<Movie> GetMovies()
        {
            return movies;
        }

        public Movie GetMovieById(int movieId)
        {
            return movies?.FirstOrDefault(x => x.MovieId == movieId);
        }
    }
}
