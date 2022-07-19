using MKTFY.Models.ViewModels.FAQ;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKTFY.Models.Entities
{
    /// <summary>
    /// Faq entity 
    /// </summary>
    public class Faq : BaseEntity<Guid>
    {
        /// <summary>
        /// Empty constructor for Faq default entity 
        /// </summary>
        public Faq()
        {
            //Empty constructor
        }

        /// <summary>
        /// constructor used to allow creation of an new entity 
        /// </summary>
        /// <param name="src"></param>
        public Faq(FaqAddVM src)
        {
            Title = src.Title;
            Description = src.Description;

        }
        /// <summary>
        /// Title of the Faq 
        /// </summary>
        [Required]
        public string Title { get; set; } = String.Empty;

        /// <summary>
        /// Description of the Faq
        /// </summary>
        [Required]
        public string Description { get; set; } = String.Empty;




    }
}
