using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKTFY.Models.ViewModels.Listing
{
    /// <summary>
    /// ViewModel for updating the Listing 
    /// </summary>
    public class ListingUpdateVM
    {
        /// <summary>
        /// Id Created for the listing 
        /// </summary>
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Title for the listing 
        /// </summary>
        [Required]
        public string Title { get; set; } = String.Empty;

        /// <summary>
        /// Description for the Listing 
        /// </summary>
        [Required]
        public string Description { get; set; } = String.Empty;

        /// <summary>
        /// The Price for the Listing 
        /// </summary>
        [Required]
        public decimal Price { get; set; }

        /// <summary>
        /// Address for the listing being sold 
        /// </summary>
        [Required]
        public string Address { get; set; } = String.Empty;

        /// <summary>
        /// the city for the listing being sold 
        /// </summary>
        [Required]
        public string City { get; set; } = String.Empty;

        /// <summary>
        /// condition of the listing only can be Used or New
        /// </summary>
        [Required]
        public string Condition { get; set; } = String.Empty;

        /// <summary>
        /// Category for the listing 4 categories only 
        /// </summary>
        [Required]
        public string Category { get; set; } = String.Empty;

        /// <summary>
        /// Buyer Id when the listing is purchased otherwize empty string 
        /// </summary>
        public string BuyerId { get; set; } = String.Empty;
    }
}
