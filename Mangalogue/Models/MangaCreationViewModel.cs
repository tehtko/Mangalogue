using Mangalogue.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Mangalogue.Models
{
    public class MangaCreationViewModel
    {
        [Required(ErrorMessage = "Please add a title")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Please add a thumbnail")]
        public IFormFile? Thumbnail { get; set; }

        [Required(ErrorMessage = "Please add brief description")]
        public string? Description { get; set; }

        [BindProperty]
        [CheckBoxRequired(ErrorMessage = "Please select at least one genre")]
        public ICollection<Genres>? Genres { get; set; }
    }
}
