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
        public string Category { get; set; } //make these atomic
        public string Title { get; set; }
        public byte Year { get; set; }
        public string Director { get; set; }
        public string Rating { get; set; }
        public bool Edited { get; set; }
    }
}
