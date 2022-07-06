using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKTFY.Models.ViewModels.User
{
    public class UserUpdateVM
    {
        /// <summary>
        /// ID from AuthO
        /// </summary>
        [Required]
        public string Id { get; set; } = String.Empty;

        /// <summary>
        /// First name from the User 
        /// </summary>
        [Required]
        public string FirstName { get; set; } = String.Empty;

        /// <summary>
        /// Last name from the user
        /// </summary>
        [Required]
        public string LastName { get; set; } = String.Empty;

        /// <summary>
        /// Phone number from user  
        /// </summary>
        [Required]
        public string Phone { get; set; } = String.Empty;


    }
}
