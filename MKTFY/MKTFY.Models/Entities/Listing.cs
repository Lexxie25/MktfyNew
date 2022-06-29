using MKTFY.Models.ViewModels.Listing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKTFY.Models.Entities
{
    public class Listing
    {
        // Default constructor to allow creation of an empty entity
        public Listing()
        {
        }

        //constructor used to creat a new listing from listingAddVM model
        public Listing(ListingAddVM src, string userId)
        {
            Title = src.Title;
            Description = src.Description;
            Price = src.Price;
            Address = src.Address;
            City = src.City;
            Condition = src.Condition;
            Category = src.Category;
            UserId = userId;

        }
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; } = String.Empty;

        [Required]
        public string Description { get; set; } = String.Empty;


        [Required]
        public string Address { get; set; } = String.Empty;


        [Required]
        public string City { get; set; } = String.Empty;


        [Required]
        public DateTime Created { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string Condition { get; set; } = String.Empty;

        [Required]
        public string Category { get; set; } = String.Empty;

        //Relationships
        [Required]
        public string UserId { get; set; } = String.Empty;

        public User? User { get; set; }
    }
}

