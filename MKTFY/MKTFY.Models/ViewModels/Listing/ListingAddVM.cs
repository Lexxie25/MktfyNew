using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKTFY.Models.ViewModels.Listing
{
    public class ListingAddVM
    {
        [Required]
        public string Title { get; set; } = String.Empty;

        [Required]
        public string Description { get; set; } = String.Empty;

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string Address { get; set; } = String.Empty;

        [Required]
        public string City { get; set; } = String.Empty;

        [Required]
        public string Condition { get; set; } = String.Empty;

        [Required]
        public string Category { get; set; } = String.Empty;



    }
}
