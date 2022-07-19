using Microsoft.EntityFrameworkCore;
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
        //creating a new listing 
        //entity.Status = "Active";  move this to Service layer ? 
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

        // GET ALL --- Move this to Service layer logic  the Listings string userId .Where(i => i.UserId ! = userId && i.BuyerId == null).OrderByDescending(i => i.Created).
        public async Task<List<ListingVM>> GetAll()
        {
            // get the listing entities from the repository 
            var results = await _uow.Listings.GetAll(items => items.Include(listing => listing.User));

            //Build the ListingVM view models to return to the client 
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

        /////////////////////////////////////////////////////////////////////////////////Search String  doesnt show user 
        //Service Logic 
        //public async Task<List<ListingVM>> Search(string searchString, string userId)
        //{
        //    //get the existing entity and search
        //    var results = await _uow.Listings.Search(searchString, userId);

        //    var models = results.Select(listing => new ListingVM(listing)).ToList();
        //    return models;
        //}
        //Repo Logic 
        //public async Task<List<Listing>> Search(string searchString, string userId)//string[] history)
        //{

        //    var results = await _context.Listings.Where(i => i.UserId != userId && i.BuyerId == null && (
        //     i.Title.ToLower().Contains(searchString.ToLower()) || i.Description.ToLower().Contains(searchString.ToLower()))).OrderByDescending(i => i.Created).ToListAsync();
        //    return results;

        //}

        ////////////////////////////////////////////////////////////// search by city 
        //Service logic
        //public async Task<List<Listing>> GetAllByCity(string city, string userId)
        //{
        //    var results = await _context.Listings.Where(i => i.UserId != userId && i.BuyerId == null &&
        //    i.City == city).OrderByDescending(i => i.Created).ToListAsync();
        //    return results;

        //Repo Logic
        //public async Task<List<ListingVM>> GetAllByCity(string city, string userId)
        //{
        //    //get the existing entites by city 
        //    var results = await _uow.Listings.GetAllByCity(city, userId);

        //    //Build the ListingVM viwe models to return to the client 
        //    var models = results.Select(listing => new ListingVM(listing)).ToList();

        //    // return the listingVMs
        //    return models;
        //}

        ///////////////////////////////////////////////////////search by category 
        //service logic
        //public async Task<List<Listing>> GetAllByCategory(string category, string userId)
        //{
        //    var results = await _context.Listings.Where(i => i.UserId != userId && i.BuyerId == null &&
        //    i.Category == category).OrderByDescending(i => i.Created).ToListAsync();
        //    return results;

        //}
        //Repo logic
        ////search by catagory doesnt show user 
        //public async Task<List<ListingVM>> GetAllByCategory(string category, string userId)
        //{
        //    //get the existing entites by city 
        //    var results = await _uow.Listings.GetAllByCity(category, userId);

        //    //Build the ListingVM viwe models to return to the client 
        //    var models = results.Select(listing => new ListingVM(listing)).ToList();

        //    // return the listingVMs
        //    return models;
        //}

        ////////////////////////////////////////////////////////////////////////////Search with All filtering catgory price city condition doesnt show user  

        //public async Task<List<Listing>>SearchFilter(string searchString, string userId, string city, string condition, string category, decimal price)
        //{
        //    var result = await _context.Listings.Where(i => i.UserId != userId && i.BuyerId == null).ToListAsync();
        //        switch ("result")
        //    {
        //        case "searchSrting": if (searchString != null && i.Title.ToLower().Contains(searchString.ToLower()) || i.Description.ToLower().Contains(searchString.ToLower()))))

        //}


        ////////////////////////////////////////////////////////////////////// Purchase 
        //Repo logic 
        //public async Task<ListingVM> Purchase(ListingPurchaseVM src, string buyerId)
        //{
        //    var entity = await _uow.Listings.GetById(src.Id);

        //    entity.BuyerId = buyerId;

        //    _uow.Listings.Purchase(entity);
        //    await _uow.SaveAsync();

        //    var models = new ListingVM(entity);
        //    return models;
        //}
        //Service Logic 
        //public void Purchase(Listing entity)
        //{
        //    entity.Purchase = DateTime.UtcNow;

        //    _context.Update(entity);
        //}
        // MY LISTINGS ACTIVE AND SOLD 
        // MY History 



        ////////////////////////////////////////////////////////////////////////Deals 
        //need to make a user spot for a list of history that saves Listing Id ect to make up the logic for this 
        //Logic from service
        //public async Task<List<ListingVM>> Deals(string userId)
        //{
        //    var results = await _uow.Listings.Deals(userId);
        //    var models = results.Select(listing => new ListingVM(listing)).ToList();
        //    return models;
        //}
        ////Logic from Repository 
        //public async Task<List<Listing>> Deals(string userId)
        //{
        //    var results = await _context.Listings.Where(i => i.UserId != userId).OrderBy(i => i.Price).Take(16)
        //        .ToListAsync();
        //    return results;
        //}



    }


}
