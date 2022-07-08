using Microsoft.EntityFrameworkCore;
using MKTFY.Models.Entities;
using MKTFY.Repositories.Repositories.Interfaces;
using MKTFY.Shared.Exceptions;
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
            var result = await _context.Listings.FirstOrDefaultAsync(Listing => Listing.Id == id);
            if (result == null)
                throw new NotFoundException("The requested listing could not be found");

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

        //Deals 
        public async Task<List<Listing>> Deals(string userId)
        {
            var results = await _context.Listings.Where(i => i.UserId != userId).OrderBy(i => i.Price).Take(16)
                .ToListAsync();
            return results;
        }
    }
}
