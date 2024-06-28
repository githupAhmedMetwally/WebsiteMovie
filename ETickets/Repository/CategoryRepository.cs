using ETickets.Data;
using ETickets.Models;
using ETickets.ModelView;
using ETickets.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace ETickets.Repository
{
    public class CategoryRepository:ICategory
    {
       private readonly ApplicationDbContext context;
       public  CategoryRepository(ApplicationDbContext context)
        {
             this.context=context;
        }

        public List<Category> Categories()
        {

            return context.categories.ToList();
        }
         
         
        public Category Category(int id)
        {
            var result = context.categories.Find(id);
            return result;
        }


        public void Create(Category category)
        {
            context.categories.Add(category);
            context.SaveChanges();
        }

         

        public void Delete(Category category)
        {
            context.categories.Remove(category);
            context.SaveChanges();
        }
         

        public void Update(Category category)
        {
            context.categories.Update(category);
            context.SaveChanges();
        }
    }
}
