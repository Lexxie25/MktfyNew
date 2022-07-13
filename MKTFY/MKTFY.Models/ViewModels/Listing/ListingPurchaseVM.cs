using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKTFY.Models.ViewModels.Listing
{
    /// <summary>
    /// ViewModel for just the listing Purchase 
    /// </summary>
    public class ListingPurchaseVM
    {
        // when the listing is updated the user id will switch to buyer Id. 
        /// <summary>
        /// Id of the purchase user 
        /// </summary>
        [Key]
        public Guid Id { get; set; }
    }
}
