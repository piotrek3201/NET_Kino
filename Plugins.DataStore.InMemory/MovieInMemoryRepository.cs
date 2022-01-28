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
                },
                new Movie()
                {
                    MovieId = 4,
                    Title = "Diuna",
                    Description = "Szlachetny ród Atrydów przybywa na Diunę, będącą jedynym źródłem najcenniejszej substancji we wszechświecie.",
                    Length = 155,
                    Year = 2021,
                    AgeRestriction = 13,
                    ImageUrl = "https://i.ebayimg.com/images/g/wUkAAOSwpOxhHUrd/s-l400.jpg"
                },
                new Movie()
                {
                    MovieId = 5,
                    Title = "Spider-Man: Bez drogi do domu",
                    Description = "Kiedy cały świat dowiaduje się, że pod maską Spider Mana skrywa się Peter Parker, superbohater decyduje się zwrócić o pomoc do Doktora Strange'a.",
                    Length = 148,
                    Year = 2021,
                    AgeRestriction = 13,
                    ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQUFLWM-ZrmUUSs5kNkk6mdsST_eBVhcjwFCbLnbxt013rf7O9D"
                },
                new Movie()
                {
                    MovieId = 6,
                    Title = "Eternals",
                    Description = "Opowieść o Eternals - przedwiecznej rasie nieśmiertelnych istot, które zamieszkiwały Ziemię i ukształtowały jej historię.",
                    Length = 157,
                    Year = 2021,
                    AgeRestriction = 13,
                    ImageUrl = "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcTgjKTgI_15Qt9vy2Iuej0NniEIHAjFn_zqEqd12Ln-ep6jgO6e"
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

        public void AddMovie(Movie movie)
        {
            if (movies.Any(x => x.Title.Equals(movie.Title, StringComparison.OrdinalIgnoreCase))) return;

            if (movies != null && movies.Count > 0)
            {
                var maxID = movies.Max(x => x.MovieId);
                movie.MovieId = maxID + 1;
            }
            else
            {
                movie.MovieId = 1;
            }

            movies.Add(movie);
        }

        public void UpdateMovie(Movie movie)
        {
            var movieToUpdate = GetMovieById(movie.MovieId);
            if (movieToUpdate != null)
            {
                movieToUpdate.Title = movie.Title;
                movieToUpdate.Description = movie.Description;
                movieToUpdate.Year = movie.Year;
                movieToUpdate.Length = movie.Length;
                movieToUpdate.AgeRestriction = movie.AgeRestriction;
                movieToUpdate.ImageUrl = movie.ImageUrl;
            }
        }

        public void DeleteMovie(int movieId)
        {
            movies?.Remove(GetMovieById((int)movieId));
        }
    }
}
