﻿namespace ETickets.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        List<Movie> movies { get; set; }

    }
}
