using ETickets.Models;
using ETickets.Repository;
using ETickets.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace ETickets.Controllers
{
    public class CategoryController : Controller
    {
       private readonly ICategory category;

        private readonly IMovie movie;
        public  CategoryController(ICategory category, IMovie movie) 
        {
            this.movie = movie;
            this.category=category;
        }
        public IActionResult Index()
        {
           var result= category.Categories();
            return View(result);
        }

      
    }
}
