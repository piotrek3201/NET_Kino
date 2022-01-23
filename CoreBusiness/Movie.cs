using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusiness
{
    public class Movie
    {
        [Required]
        public int MovieId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Length { get; set; }
        [Required]
        public int Year { get; set; }
        public int AgeRestriction { get; set; }
        public string ImageUrl { get; set; }
    }
}
