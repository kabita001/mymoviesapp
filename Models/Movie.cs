﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations; //Using the directive

namespace MovieList.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        [Required(ErrorMessage = "Please enter a name.")]
        public string Name { get; set;}
        [Required(ErrorMessage = "Please enter a year.")]
        [Range(1889, 2999, ErrorMessage = "Year must be after 1889.")]
        public int? Year { get; set; }
        [Required(ErrorMessage = "Please enter a rating.")]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
        public int? Rating { get; set; }
        [ValidateNever]
        public Genre Genre { get; set; }
        [Required(ErrorMessage = "Please enter a genre.")]
        public string GenreId { get; set; }
        public string Slug => Name?.Replace(' ', '-').ToLower() + '-' + Year?.ToString();

        [Required(ErrorMessage = "Please enter release date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Required(ErrorMessage = "Please enter director")]
        public string Director { get; set; }

        [Required(ErrorMessage = "Enter movie duration")]
        [Range(1, 400, ErrorMessage = "Movie duration must be between 1 and 400 minutes")]
        public int Duration { get; set; }

        [Required(ErrorMessage = "Trivia is required to show users fun facts.")]
        public string Trivia { get; set; }

        public string AutoGeneratedQuote => GenerateQuote();

        private string GenerateQuote()
        {
            // Templates for quotes
            var templates = new List<string>
        {
            "\"{Name}\" directed by {Director} is a masterpiece from {Year}.",
            "In {Year}, {Director} gave us the unforgettable \"{Name}\".",
            "If you haven't watched \"{Name}\", you are missing a {GenreId} classic!",
            "With a duration of {Duration} minutes, \"{Name}\" keeps you on the edge of your seat!",
            "Rated {Rating} stars, \"{Name}\" is a must-watch movie from {Year}."
        };

            // Pick a random template
            var random = new Random();
            var template = templates[random.Next(templates.Count)];

            // Replace placeholders with movie details
            return template
                .Replace("{Name}", Name)
                .Replace("{Year}", Year?.ToString() ?? "Unknown Year")
                .Replace("{Director}", Director)
                .Replace("{GenreId}", GenreId)
                .Replace("{Duration}", Duration.ToString())
                .Replace("{Rating}", Rating?.ToString() ?? "Unrated");
        }
    }
}
