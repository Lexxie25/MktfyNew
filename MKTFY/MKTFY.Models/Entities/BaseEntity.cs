using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKTFY.Models.Entities
{/// <summary>
/// Generaic base entity 
/// </summary>
/// <typeparam name="TId"></typeparam>
    public class BaseEntity<TId>
    {

        /// <summary>
        /// Generic ID param 
        /// </summary>
        [Key]
        public TId Id { get; set; }
    }
}
