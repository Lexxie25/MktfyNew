using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKTFY.Models.Entities
{
    /// <summary>
    /// Entity for tracking uploaded files
    /// </summary>
    public class Upload
    {
        /// <summary>
        /// upload Id
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Url of the file on s3
        /// </summary>
        [Required]
        public string Url { get; set; } = String.Empty;
    }
}
