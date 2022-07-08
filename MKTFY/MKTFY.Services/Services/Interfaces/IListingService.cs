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

        Task<ListingVM> Deals(string userId);

    }
}
