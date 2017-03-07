using System;
using System.ComponentModel.DataAnnotations;

namespace AjaxWithAspNetMvc.Models
{
    public class Movie
    {
        public Movie()
        {
            this.Id = Guid.NewGuid();
        }
        
        public Guid Id { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Title { get; set; }
        
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Director { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Year { get; set; }
        
        [Required]
        [StringLength(30, MinimumLength = 3)]
        [Display(Name = "Leading Male Role")]
        public string LeadingMaleRole { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        [Display(Name = "Leading Female Role")]
        public string LeadingFemaleRole { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Studio { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        [Display(Name = "Studio Address")]
        public string StudioAddress { get; set; }
    }
}
