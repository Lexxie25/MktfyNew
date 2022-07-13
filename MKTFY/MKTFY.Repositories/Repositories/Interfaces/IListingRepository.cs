using MKTFY.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKTFY.Repositories.Repositories.Interfaces
{
    public interface IListingRepository
    {
        void Create(Listing entity);  // create a new listing
        Task<Listing> GetById(Guid id);  // get a single existinglisting by Id
        Task<List<Listing>> GetAll(string userId);   // get all of the listings
        void Update(Listing entity);  // update the listing 
        void Delete(Listing entity);  // delete a litsing
        Task<List<Listing>> Search(string searchString, string userId);
        void Purchase(Listing entity); // updates the listing to purchased 
        Task<List<Listing>> GetAllByCity(string city, string userId);
        Task<List<Listing>> GetAllByCategory(string category, string userId);
        Task<List<Listing>> Deals(string userId);

    }
}
