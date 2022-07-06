using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKTFY.Models.ViewModels.User
{   /// <summary>
    ///  Creating a user VM
    /// </summary>
    public class UserVM
    {   /// <summary>
        /// Constructor for populating a new UserVM from a listing entity 
        /// </summary>
        /// <param name="src">Source</param>
        public UserVM(Entities.User src)
        {
            Id = src.Id;
            FristName = src.FirstName;
            LastName = src.LastName;
            Email = src.Email;
            Phone = src.Phone;
        }
        /// <summary>
        /// ID from AuthO
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// First name from the User 
        /// </summary>
        public string FristName { get; set; }

        /// <summary>
        /// Last name from the user
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Email form the user CANNOT be canged. 
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Phone number from user  
        /// </summary>
        public string Phone { get; set; }
    }
}
