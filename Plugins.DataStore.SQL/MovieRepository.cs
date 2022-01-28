using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.SQL
{
    public class MovieRepository : IMovieRepository
    {
        private readonly CinemaContext db;

        public MovieRepository(CinemaContext db)
        {
            this.db = db;
        }

        public void AddMovie(Movie movie)
        {
            db.Movies.Add(movie);
            db.SaveChanges();
        }

        public void DeleteMovie(int movieId)
        {
            var movie = db.Movies.Find(movieId);
            if (movie == null) return;

            db.Movies.Remove(movie);
            db.SaveChanges();
        }

        public Movie GetMovieById(int movieId)
        {
            return db.Movies.Find(movieId);
        }

        public IEnumerable<Movie> GetMovies()
        {
            return db.Movies.ToList();
        }

        public void UpdateMovie(Movie movie)
        {
            var movieToUpdate = db.Movies.Find(movie.MovieId);
            if (movieToUpdate != null)
            {
                movieToUpdate.Title = movie.Title;
                movieToUpdate.Description = movie.Description;
                movieToUpdate.Year = movie.Year;
                movieToUpdate.Length = movie.Length;
                movieToUpdate.AgeRestriction = movie.AgeRestriction;
                movieToUpdate.ImageUrl = movie.ImageUrl;
            }
            db.SaveChanges();
        }
    }
}
