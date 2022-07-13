﻿using MKTFY.Models.ViewModels.Listing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKTFY.Models.Entities
{
    /// <summary>
    /// Listing Entity
    /// </summary>
    public class Listing
    {
        /// <summary>
        /// Default constructor to allow creation of an empty entity
        /// </summary>
        public Listing()
        {
        }

        /// <summary>
        /// constructor used to create a new listing from listingAddVM model
        /// </summary>
        /// <param name="src">Source</param>
        /// <param name="userId">Guid ID</param>
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
        /// <summary>
        /// Guid ID
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Title of Listing
        /// </summary>
        [Required]
        public string Title { get; set; } = String.Empty;

        /// <summary>
        /// Description of Listing 
        /// </summary>
        [Required]
        public string Description { get; set; } = String.Empty;

        /// <summary>
        /// Address of listing 
        /// </summary>
        [Required]
        public string Address { get; set; } = String.Empty;

        /// <summary>
        /// Ciry of Listing 
        /// </summary>
        [Required]
        public string City { get; set; } = String.Empty;

        /// <summary>
        /// Created date of listing never changes 
        /// </summary>
        [Required]
        public DateTime Created { get; set; }

        /// <summary>
        /// Price of listing 
        /// </summary>
        [Required]
        public decimal Price { get; set; }

        /// <summary>
        /// Condition of listing New or Used Only 
        /// </summary>
        [Required]
        public string Condition { get; set; } = String.Empty;

        /// <summary>
        /// Category of listing 4 Cats only 
        /// </summary>
        [Required]
        public string Category { get; set; } = String.Empty;

        /// <summary>
        /// Relationships
        /// </summary>
        [Required]
        public string UserId { get; set; } = String.Empty;
        /// <summary>
        /// gets the user Id on this table for the database 
        /// </summary>
        public User? User { get; set; }

        /// <summary>
        /// Buyer Id when the listing is purchased otherwize empty string 
        /// </summary>
        public string BuyerId { get; set; } = String.Empty;

        /// <summary>
        /// Purchased time seter
        /// </summary>
        public DateTime Purchase { get; set; }

        /// <summary>
        /// status for when it becomes Active or Sold
        /// </summary>

        public string Status { get; set; } = String.Empty;

        /// <summary>
        /// History of the search function 
        /// </summary>
        public string[] History = new string[3];
    }
}

