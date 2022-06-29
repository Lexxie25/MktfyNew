using MKTFY.Models.Entities;
using MKTFY.Models.ViewModels.Listing;
using MKTFY.Repositories;
using MKTFY.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKTFY.Services.Services
{
    public class ListingService : IListingService
    {
        private readonly IUnitOfWork _uow;

        public ListingService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<ListingVM> Create(ListingAddVM src, string userId)
        {
            //creating a new listing entity 
            var newEntity = new Listing(src, userId);

            // have the repository create the new listing
            _uow.Listings.Create(newEntity);
            await _uow.SaveAsync();

            // creat the Listingvm we want to return to the client 
            var model = new ListingVM(newEntity);

            // return the ListingVMs
            return model;


        }
        public async Task<List<ListingVM>> GetAll()
        {
            // get the listing entities from the repository 
            var results = await _uow.Listings.GetAll();

            //Build the ListingVM viwe models to return to the client 
            var models = results.Select(listing => new ListingVM(listing)).ToList();

            // return the listingVMs
            return models;
        }

        public async Task<ListingVM> GetById(Guid id)
        {
            // Get the requested listing entity from the repository 
            var result = await _uow.Listings.GetById(id);

            // Creat the ListingVM we want to return to the client
            var model = new ListingVM(result);

            // Return a 200 responce with the ListingVM
            return model;

        }
        public async Task<ListingVM> Update(ListingUpdateVM src)
        {
            //get the existing entity 
            var entity = await _uow.Listings.GetById(src.Id);

            // perform the update may need more fields for the update 
            entity.Title = src.Title;
            entity.Description = src.Description;
            entity.Price = src.Price;
            entity.Address = src.Address;
            entity.City = src.City;
            entity.Category = src.Category;
            entity.Condition = src.Condition;

            //Have the repository update the game 
            _uow.Listings.Update(entity);
            await _uow.SaveAsync();

            //create the ListingVM we want to return to the client 
            var model = new ListingVM(entity);

            //return a 200 responce with the Listing VM 
            return model;
        }

        public async Task Delete(Guid id)
        {
            // get the existing entity
            var entity = await _uow.Listings.GetById(id);

            // tell  the repository to delete the requested listing entity (admin only) 
            _uow.Listings.Delete(entity);
            await _uow.SaveAsync();
        }

    }
}
