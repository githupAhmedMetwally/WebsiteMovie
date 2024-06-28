using ETickets.Repository;
using ETickets.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace ETickets.Controllers
{
    public class CinemaController : Controller
    {
        private readonly ICinema cinema;
       public CinemaController(ICinema cinema)
        {

            this.cinema = cinema;
        }
        public IActionResult Index()
        {
           var result= cinema.Cinemas();
            return View(result);
        }
    }
}
