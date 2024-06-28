using ETickets.Models;

namespace ETickets.Repository.IRepository
{
    public interface ICinema
    {
        List<Cinema> Cinemas();
        Cinema Cinema(int id);
        void Create(Cinema cinema);
        void Update(Cinema cinema);
        void Delete(Cinema cinema);
    }
}
