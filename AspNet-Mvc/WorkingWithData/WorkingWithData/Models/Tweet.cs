using System;
using System.ComponentModel.DataAnnotations;

namespace WorkingWithData.Models
{
    public class Tweet
    {
        public Tweet()
        {
            this.Id = Guid.NewGuid();
            this.CreatedOn = DateTime.Now;
        }

        public Guid Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Content { get; set; }
        
        [Display(Name = "Created On")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy HH:mm}")]
        public DateTime CreatedOn { get; set; }
        
        public string UserId { get; set; } 
        
        public virtual User User { get; set; }
    }
}