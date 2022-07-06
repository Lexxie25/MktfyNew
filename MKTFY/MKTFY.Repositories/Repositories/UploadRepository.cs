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
    internal class UploadRepository : IUploadRepository
    {
        private readonly ApplicationDbContext _context;

        public UploadRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Create(Upload entity)
        {
            // preform the add in memory
            _context.Add(entity);
        }

        // get a single existing upload by ID 
        public async Task<Upload> GetById(Guid id)
        {
            //ge teh entity 
            var result = await _context.Uploads.FirstAsync(i => i.Id == id);

            //return the retreved entity 
            return result;
        }

        // get all of the Uploads 
        public async Task<List<Upload>> GetAll()
        {
            // get all the entities 
            var results = await _context.Uploads.ToListAsync();

            // return the retreved entities
            return results;
        }

        // update the Entity. the changes have been passed in already / applied before this is called 
        public void Update(Upload entity)
        {
            // Update the entity 
            _context.Update(entity);

        }
        // delete the entity 
        public void Delete(Upload entity)
        {
            // Delete the entity 
            _context.Remove(entity);

        }

    }
}
