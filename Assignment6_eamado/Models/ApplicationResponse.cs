using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
//Getters and setter allow you to get information and modify it (set)
namespace Assignment6_eamado.Models
{
    public class ApplicationResponse
    {
        [Key]
        [Required]
        public int MovieId { get; set; }
        [Required(ErrorMessage ="Title Required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Year Required")]
        public byte Year { get; set; }
        [Required(ErrorMessage = "Director Required")]
        public string Director { get; set; }
        [Required(ErrorMessage = "Rating Required")]
        public string Rating { get; set; }
        [Required(ErrorMessage = "Edited Required")]
        public bool Edited { get; set; }

        //build a foreign key relationsgio
        public int CategoryID { get; set; } //This is a foregin key
        public Category Category { get; set; }

    }
}
