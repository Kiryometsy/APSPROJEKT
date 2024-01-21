using Data.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace ASPPROJEKT.ViewModels
{
    public class PhotoEntityViewModel
    {
        [MaxLength(50)]
        public string Camera { get; set; }

        [MaxLength(120)]
        public string Description { get; set; }

        [MaxLength(50)]
        public string Resolution { get; set; }

        [Required]
        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }

        [Required]
        public PhotoFormat Format { get; set; }

        [Required(ErrorMessage = "Please select an author.")]
        [Display(Name = "Author")]
        public int AuthorId { get; set; }
    }
}
