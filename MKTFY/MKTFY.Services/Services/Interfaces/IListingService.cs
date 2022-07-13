using MKTFY.Models.ViewModels.Listing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKTFY.Services.Services.Interfaces
{
    public interface IListingService
    {
        Task<ListingVM> Create(ListingAddVM src, string userId); // create a new listing 

        Task<ListingVM> GetById(Guid id);        // get a single listing by id

        Task<List<ListingVM>> GetAll(string userId);         // get all of the listings

        Task<ListingVM> Update(ListingUpdateVM src); // Update an existing Lising 

        Task Delete(Guid id);               // delete a game 

        Task<List<ListingVM>> Deals(string userId);

        Task<List<ListingVM>> Search(string searchString, string userId);

        Task<ListingVM> Purchase(ListingPurchaseVM src, string buyerId);

        Task<List<ListingVM>> GetAllByCity(string city, string userId);

        Task<List<ListingVM>> GetAllByCategory(string category, string userId);

    }
}
