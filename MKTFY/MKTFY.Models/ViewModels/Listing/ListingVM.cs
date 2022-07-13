using MKTFY.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKTFY.Models.ViewModels.Listing
{   /// <summary>
    /// ViewModel for the listing 
    /// </summary>
    public class ListingVM
    {
        /// <summary>
        /// Default constructor to allow creation of an empty ListingVM 
        /// </summary>
        public ListingVM()
        {
        }

        /// <summary>
        /// Constroctor for populating a new ListingVM from a listing entity
        /// </summary>
        /// <param name="src">Source</param>
        public ListingVM(Entities.Listing src)
        {
            Id = src.Id;
            Title = src.Title;
            Description = src.Description;
            Created = src.Created;
            Price = src.Price;
            Address = src.Address;
            City = src.City;
            Condition = src.Condition;
            Category = src.Category;
            UserId = src.UserId;
            BuyerId = src.BuyerId;

        }

        /// <summary>
        /// Id for Listing created by a GUID 
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Title for the listing 
        /// </summary>
        public string Title { get; set; } = String.Empty;

        /// <summary>
        /// Description for the Listing 
        /// </summary>
        public string Description { get; set; } = String.Empty;

        /// <summary>
        /// Date and time created originally for the Listing NEVER updates. 
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// The Price for the Listing 
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Address for the listing being sold 
        /// </summary>
        public string Address { get; set; } = String.Empty;

        /// <summary>
        /// condition of the listing only can be Used or New
        /// </summary>
        public string Condition { get; set; } = String.Empty;

        /// <summary>
        /// Category for the listing 4 categories only 
        /// </summary>
        public string Category { get; set; } = String.Empty;

        /// <summary>
        /// the city for the listing being sold 
        /// </summary>
        public string City { get; set; } = String.Empty;

        /// <summary>
        /// Pulls from the user Id as they have to be logged in to make a listing 
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Buyer Id when the listing is purchased otherwize empty string 
        /// </summary>
        public string BuyerId { get; set; } = String.Empty;


    }
}
