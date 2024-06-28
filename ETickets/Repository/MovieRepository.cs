using ETickets.Data;
using ETickets.Models;
using ETickets.ModelView;
using ETickets.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ETickets.Repository
{
    public class MovieRepository:IMovie
    {
        private readonly ApplicationDbContext context;
        public MovieRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public List<Movie> GetAllMoviesWithCategories(int? id)
        {
            var result = context.movies.Where(e => e.CategoryId == id)
                .Include(e=>e.Category).Include(e=>e.Cinema).ToList();
            return result;
        }
        public List<Movie> GetAllMoviesWithCinemas(int? id)
        {
            var result = context.movies.Where(e => e.CinemaId == id)
                .Include(e => e.Category).Include(e => e.Cinema).ToList();
            return result;
        }
       
        public void Create(Movie movie)
        {
            context.movies.Add(movie);
            context.SaveChanges();
        }

        public void Delete(Movie movie)
        {
            context.movies.Remove(movie);
            context.SaveChanges();
        }

        public List<Movie> GetMoviesWithCinemasWithCategories()
        {
           var result= context.movies.Include(e => e.Cinema).Include(e=>e.Category).ToList();
            return result;
        }
        public List<Movie> Search(string temp)
        {
            var result = context.movies.Where(e => e.Name.Contains(temp)).Include(e => e.Category).Include(e => e.Cinema).ToList();   
            return result; 
        }

        public Movie Movie(int id)
        {
            var result = context.movies.Include(e => e.Actors)
                     .FirstOrDefault(e => e.Id == id);
            return result;
        }
         

        public List<Movie> Movies()
        {
            return context.movies.ToList();
        }

        public void Update(Movie movie)
        {
            context.movies.Update(movie);
            context.SaveChanges();
        }
    }
}
