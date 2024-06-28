using ETickets.Data;
using ETickets.Models;
using ETickets.Repository.IRepository;

namespace ETickets.Repository
{
    public class CinemaRepository : ICinema
    {
        private readonly ApplicationDbContext context;
        public CinemaRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public Cinema Cinema(int id)
        {
            var result = context.cinemas.Find(id);
            return result;
        }

        public List<Cinema> Cinemas()
        {
            return context.cinemas.ToList(); 
        }

        public void Create(Cinema cinema)
        {
            context.cinemas.Add(cinema);
            context.SaveChanges();
        }

        public void Delete(Cinema cinema)
        {
            context.cinemas.Remove(cinema);
            context.SaveChanges();
        }

        public void Update(Cinema cinema)
        {
            context.cinemas.Update(cinema);
            context.SaveChanges();
        }
    }
}
