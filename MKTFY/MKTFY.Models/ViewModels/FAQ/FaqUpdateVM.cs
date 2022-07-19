using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKTFY.Models.ViewModels.FAQ
{
    /// <summary>
    /// View modle of the Update Faq
    /// </summary>
    public class FaqUpdateVM
    {
        /// <summary>
        /// guid ID to get the Faq to be able to update 
        /// </summary>
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Title of the Faq Needing to be updated 
        /// </summary>
        [Required]
        public string Title { get; set; } = String.Empty;


        /// <summary>
        /// description of the Faq needing to be updated 
        /// </summary>
        public string Description { get; set; } = String.Empty;

    }
}
