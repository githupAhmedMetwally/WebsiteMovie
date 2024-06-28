using ETickets.Models;

namespace ETickets.Repository.IRepository
{
    public interface IMovie
    {
        List<Movie> Movies();
        Movie Movie(int id);
        void Create(Movie movie);
        void Update(Movie movie);
        void Delete(Movie movie);
        List<Movie> GetMoviesWithCinemasWithCategories();
        public List<Movie> Search(string temp);
        public List<Movie> GetAllMoviesWithCategories(int? id);
        public List<Movie> GetAllMoviesWithCinemas(int? id);
         

    }
}
