using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }

        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }


        [Required]
        [Display(Name = "Genre")]
        public byte? GenreId { get; set; }


        [Display(Name = "Release Date")]
        [Required]
        public DateTime? ReleaseDate { get; set; }


        [Display(Name = "Number in Stock")]
        [Range(1, 20)]
        [Required]
        public byte? NumberInStock { get; set; }

        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Movie" : "New Movie";    // ternary operator (return expression)
            }
        }

        public MovieFormViewModel() // Constructor that only sets the HiddenForId that we pass to the MovieForm
        {
            Id = 0;
        }

        public MovieFormViewModel(Movie movie) // Constructor that takes the movie object and its attributes 
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
            GenreId = movie.GenreId;
        }
    }
}
