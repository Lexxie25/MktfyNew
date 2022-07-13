using MKTFY.Models.ViewModels.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKTFY.Models.Entities
{

    /// <summary>
    /// User entity 
    /// </summary>
    public class User
    {
        /// <summary>
        /// Default constructor to allow creation of an empty entity
        /// </summary>
        public User()
        {
        }

        /// <summary>
        /// constructor used to create a new user from UserAddVM model
        /// </summary>
        /// <param name="src">Source</param>
        public User(UserAddVM src)
        {
            Id = src.Id;
            Phone = src.Phone;
            FirstName = src.FirstName;
            LastName = src.LastName;
            Email = src.Email;

        }
        /// <summary>
        /// User Update fields 
        /// </summary>
        /// <param name="src"></param>
        public User(UserUpdateVM src)
        {
            Id = src.Id;
            FirstName = src.FirstName;
            LastName = src.LastName;
            Phone = src.Phone;


        }
        /// <summary>
        /// Id set from Auth0
        /// </summary>
        [Required]
        [Key]
        public string Id { get; set; } = String.Empty;

        /// <summary>
        /// First name
        /// </summary>
        [Required]
        public string FirstName { get; set; } = String.Empty;


        /// <summary>
        /// Last Name 
        /// </summary>
        [Required]
        public string LastName { get; set; } = String.Empty;

        /// <summary>
        /// Email Cannot be changed By user 
        /// </summary>
        [Required]
        public string Email { get; set; } = String.Empty;

        /// <summary>
        /// Phone number of user 
        /// </summary>
        [Required]
        public string Phone { get; set; } = String.Empty;

        /// <summary>
        /// Listing Listings user created 
        /// </summary>
        public ICollection<Listing> Listings { get; set; } = new List<Listing>();

    }
}
