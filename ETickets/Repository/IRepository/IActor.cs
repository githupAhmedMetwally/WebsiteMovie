using ETickets.Models;

namespace ETickets.Repository.IRepository
{
    public interface IActor
    {
        List<Actor> Actors();
        Actor Actor(int id);
        void Create(Actor actor);
        void Update(Actor actor);
        void Delete(Actor actor);
    }
}
