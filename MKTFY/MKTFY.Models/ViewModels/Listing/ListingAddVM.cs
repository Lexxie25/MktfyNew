using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKTFY.Models.ViewModels.Listing
{   /// <summary>
    /// ViewModel for creating a new Listing 
    /// </summary>
    public class ListingAddVM
    {
        /// <summary>
        /// Title of Listing 
        /// </summary>
        [Required]
        public string Title { get; set; } = String.Empty;

        /// <summary>
        /// Description of Listing 
        /// </summary>
        [Required]
        public string Description { get; set; } = String.Empty;

        /// <summary>
        /// Price of Listing 
        /// </summary>
        [Required]
        public decimal Price { get; set; }

        /// <summary>
        /// Address of seller where Item is being sold from
        /// </summary>
        [Required]
        public string Address { get; set; } = String.Empty;

        /// <summary>
        /// City of where the Listing is being sold from 
        /// </summary>
        [Required]
        public string City { get; set; } = String.Empty;

        /// <summary>
        /// Condition of Listing Only Used or New
        /// </summary>
        [Required]
        public string Condition { get; set; } = String.Empty;

        /// <summary>
        /// Category of listing only 4  Fur Ele Real Cars
        /// </summary>
        [Required]
        public string Category { get; set; } = String.Empty;



    }
}
