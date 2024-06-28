using ETickets.Models;

namespace ETickets.Repository.IRepository
{
    public interface ICategory
    {
        List<Category> Categories();
        Category Category(int id);
        void Create(Category category);
        void Update(Category category);
        void Delete(Category category);


    }
}
