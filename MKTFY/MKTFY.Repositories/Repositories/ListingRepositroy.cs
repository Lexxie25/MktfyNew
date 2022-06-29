using Microsoft.EntityFrameworkCore;
using MKTFY.Models.Entities;
using MKTFY.Repositories.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKTFY.Repositories.Repositories
{
    public class ListingRepository : IListingRepository
    {

        private readonly ApplicationDbContext _context;

        public ListingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        //creating a new listing 
        public void Create(Listing entity)
        {
            //add the created date
            entity.Created = DateTime.UtcNow;

            // perform the add in memory
            _context.Add(entity);
        }
        // get a single existing listing by Id 

        public async Task<Listing> GetById(Guid id)
        {
            // get the entity 
            var result = await _context.Listings.FirstAsync(Listing => Listing.Id == id);

            // return the retrieved entity
            return result;
        }

        // get all the games 
        public async Task<List<Listing>> GetAll()
        {
            // get all the entities 
            var results = await _context.Listings.ToListAsync();

            // return the retrieved entities
            return results;
        }

        // Update the existing games 
        public void Update(Listing entity)
        {
            // Update the entity(entity passsed in has changes already applied)
            _context.Update(entity);
        }

        // Delete the listing

        public void Delete(Listing entity)
        {
            // deleting the entitiy 
            _context.Remove(entity);
        }
    }
}
