using MKTFY.Models.ViewModels.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKTFY.Models.Entities
{
    public class User
    {
        // Default constructor to allow creation of an empty entity
        public User()
        {
        }

        //constructor used to create a new user from UserAddVM model
        public User(UserAddVM src)
        {
            Id = src.Id;
            Phone = src.Phone;
            FirstName = src.FirstName;
            LastName = src.LastName;
            Email = src.Email;

        }
        public User(UserUpdateVM src)
        {
            Id = src.Id;
            FirstName = src.FirstName;
            LastName = src.LastName;
            Phone = src.Phone;


        }

        [Required]
        [Key]
        public string Id { get; set; } = String.Empty;

        [Required]
        public string FirstName { get; set; } = String.Empty;

        [Required]
        public string LastName { get; set; } = String.Empty;

        [Required]
        public string Email { get; set; } = String.Empty;

        [Required]
        public string Phone { get; set; } = String.Empty;

        //Listing Listings user created 
        public ICollection<Listing> Listings { get; set; } = new List<Listing>();

    }
}
