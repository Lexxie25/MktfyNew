using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKTFY.Models.ViewModels.FAQ
{
    /// <summary>
    /// VM for the FAQ
    /// </summary>
    public class FaqVM
    {
        /// <summary>
        /// Empty VM for FAQ 
        /// </summary>
        public FaqVM()
        {
        }
        /// <summary>
        /// VM for the FAQ 
        /// </summary>
        /// <param name="src"></param>
        public FaqVM(Entities.Faq src)
        {
            Title = src.Title;
            Description = src.Description;
            Id = src.Id;
        }
        /// <summary>
        /// Id for Faq created by Guid from base entity 
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Title of the faq 
        /// </summary>
        public string Title { get; set; } = String.Empty;
        /// <summary>
        /// Description of the Faq
        /// </summary>
        public string Description { get; set; } = String.Empty;



    }

}
