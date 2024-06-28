using ETickets.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using ETickets.ModelView;

namespace ETickets.Data
{
    public class ApplicationDbContext: IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
       : base(options)
        {
        }
         
        public DbSet<Movie> movies { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Cinema> cinemas { get; set; }
        public DbSet<Actor> actors { get; set; }
         

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);  
        }
        public DbSet<ETickets.ModelView.ApplicationUserVM> ApplicationUserVM { get; set; } = default!;
        public DbSet<ETickets.ModelView.LoginUsreVM> LoginUsreVM { get; set; } = default!;
        public DbSet<ETickets.ModelView.MovieVM> MovieVM { get; set; } = default!;
        public DbSet<ETickets.ModelView.RoleVM> RoleVM { get; set; } = default!;
         
    }
}
