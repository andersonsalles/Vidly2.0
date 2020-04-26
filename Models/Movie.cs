﻿using System;
using System.ComponentModel.DataAnnotations;
using WebApplication1.Models;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Display (Name = "Release date")]
        public DateTime ReleaseDate { get; set; }

        [Display (Name = "Date added")]
        public DateTime DateAdded { get; set; }

        [Display (Name = "Number in stock")]
        [Range(1,20)]
        public int NumberInStock { get; set; }

        [Display (Name = "Genre")]
        public byte GenreId { get; set; }

        public Genre Genre { get; set; }

    }
}