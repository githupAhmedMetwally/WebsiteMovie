using ETickets.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ETickets.Enums;
namespace ETickets.ModelView
{
    public class MovieVM
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string ImgUrl { get; set; } = null!;
        public string TrailerUrl { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public MovieStatus MovieStatus { get; set; }
        [DisplayName("CinemasName")]
        public int CinemaId { get; set; }
        [DisplayName("CategoryName")]
        public int CategoryId { get; set; }
       
       
    }
}
