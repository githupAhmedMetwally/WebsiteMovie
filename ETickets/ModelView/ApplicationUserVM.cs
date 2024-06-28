using System.ComponentModel.DataAnnotations;

namespace ETickets.ModelView
{
    public class ApplicationUserVM
    {
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; } = null!;
        public string Address { get; set; }

    }
}
