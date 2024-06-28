
using Microsoft.AspNetCore.Mvc;
using ETickets.Repository;
using ETickets.Models;
using ETickets.Repository.IRepository;
using ETickets.ModelView;
using ETickets.Enums;
using System.Data;
using Microsoft.AspNetCore.Authorization;
namespace ETickets.Controllers
{
     
    public class MovieController : Controller
    {

        DateTime dateTimeNow = DateTime.Now;
        private readonly ICinema cinema;

        private readonly IMovie movie;
        private readonly ICategory category;

        public  MovieController(ICinema cinema,IMovie movie,ICategory category)
        {
            this.movie=movie;
            this.category = category;
            this.cinema = cinema;
        }
         
        public IActionResult Index()
        {
            ViewData["dateTimeNow"] = DateTime.Now;
            var result= movie.GetMoviesWithCinemasWithCategories(); 
            return View(result);
        }
        public IActionResult Movie(int id)
        {
            var result = movie.Movie(id);
           ViewData["Goin"] = movie.GetMoviesWithCinemasWithCategories();
             
            return View(result);
        }
        public IActionResult Create()
        {
            ViewData["ListOfCategory"]= category.Categories();
            ViewData["ListOfCinemas"] = cinema.Cinemas();
            
            return View();
        }
        [HttpPost]
        public IActionResult Create(MovieVM movieVM)
        {
           
            if (ModelState.IsValid)
            {
                Movie movie = new Movie()
                {
                    Name = movieVM.Name,
                    Description = movieVM.Description,
                    Price = movieVM.Price,
                    ImgUrl = movieVM.ImgUrl,
                    TrailerUrl = movieVM.TrailerUrl,
                    CinemaId = movieVM.CinemaId,
                    StartDate = movieVM.StartDate,
                    EndDate = movieVM.EndDate, 
                    CategoryId = movieVM.CategoryId,
                   
                };
                if (dateTimeNow.CompareTo(movie.StartDate) == -1)
                {
                    movie.MovieStatus = MovieStatus.UpComing;
                }
                else if (dateTimeNow.CompareTo(movie.StartDate) == 1 &&
                    dateTimeNow.CompareTo(movie.EndDate) == -1)
                {
                    movie.MovieStatus = MovieStatus.Availavle;
                }
                else
                {
                    movie.MovieStatus = MovieStatus.Expired;
                }
                this.movie.Create(movie);
                return RedirectToAction("Index", "Movie");
            }
            return View();
        }
        public IActionResult Search(string temp)
        {
            var result = movie.Search(temp);
            return View("GetCinemas", result);
        }
        public IActionResult GetDetails(int id)
        {
            var result = movie.GetAllMoviesWithCategories(id);

            return View(result);
        }
        public IActionResult GetCinemas(int id)
        {
            var result = movie.GetAllMoviesWithCinemas(id);

            return View(result);
        }

        public IActionResult Edit(int id)
        {
            ViewData["Edit"] = movie.GetMoviesWithCinemasWithCategories();
            ViewData["ListOfCategory"] = category.Categories();
            ViewData["ListOfCinemas"] = cinema.Cinemas();
            var result= movie.Movie(id);
            return View(result);
        }
        [HttpPost]
        public IActionResult Edit(MovieVM movieVM)
        {
            if (ModelState.IsValid)
            {
                Movie movie = new Movie()
                {
                    Id=movieVM.Id,
                    Name = movieVM.Name,
                    Description = movieVM.Description,
                    Price = movieVM.Price,
                    ImgUrl = movieVM.ImgUrl,
                    TrailerUrl = movieVM.TrailerUrl,
                    CinemaId = movieVM.CinemaId,
                    StartDate = movieVM.StartDate,
                    EndDate = movieVM.EndDate,
                    CategoryId = movieVM.CategoryId,
                };
              
                this.movie.Update(movie);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
