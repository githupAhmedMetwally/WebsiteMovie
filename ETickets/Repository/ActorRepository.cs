using ETickets.Data;
using ETickets.Models;
using ETickets.ModelView;
using ETickets.Repository.IRepository;

namespace ETickets.Repository
{
    public class ActorRepository : IActor
    {
        private readonly ApplicationDbContext context;
        public ActorRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public Actor Actor(int id)
        {
            var result = context.actors.Find(id);
            return result;
        }

        public List<Actor> Actors()
        {
            return context.actors.ToList();
        }

        public void Create(Actor actor)
        {
            context.actors.Add(actor);
            context.SaveChanges();
        }

        public void Delete(Actor actor)
        {
            context.actors.Remove(actor);
            context.SaveChanges();
        }

        public void Update(Actor actor)
        {
            context.actors.Update(actor);
            context.SaveChanges();
        }
    }
}
