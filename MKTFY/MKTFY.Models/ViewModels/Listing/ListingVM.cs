using MKTFY.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKTFY.Models.ViewModels.Listing
{
    public class ListingVM
    {
        //Default constructor to allow creation of an empty ListingVM
        public ListingVM()
        {
        }
        //Constroctor for populating a new ListingVM from a listing entity 
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

        }
        public Guid Id { get; set; }

        public string Title { get; set; } = String.Empty;

        public string Description { get; set; } = String.Empty;

        public DateTime Created { get; set; }

        public decimal Price { get; set; }

        public string Address { get; set; } = String.Empty;

        public string Condition { get; set; } = String.Empty;

        public string Category { get; set; } = String.Empty;

        public string City { get; set; } = String.Empty;

        public string UserId { get; set; } = String.Empty;

    }
}
