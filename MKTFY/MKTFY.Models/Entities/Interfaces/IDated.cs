using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKTFY.Models.Entities.Interfaces
{
    /// <summary>
    /// Date time interface 
    /// </summary>
    public interface IDated
    {

        /// <summary>
        /// when the item is created date stamp 
        /// </summary>
        public DateTime Created { get; set; }
    }
}
