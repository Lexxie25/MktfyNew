using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKTFY.Models.ViewModels.FAQ
{
    /// <summary>
    /// VM for adding a FAQ
    /// </summary>
    public class FaqAddVM
    {

        /// <summary>
        /// title for addign VM faq
        /// </summary>
        public string Title { get; set; } = String.Empty;

        /// <summary>
        /// description for adding a Vm Faq
        /// </summary>
        public string Description { get; set; } = String.Empty;

    }
}
