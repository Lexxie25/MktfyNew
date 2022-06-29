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
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        //creat a new user 
        public void Create(User entity)
        {
            //perform the add in memory 
            _context.Add(entity);
        }

        //Get a single User By Id
        //NOTE Will return null if user doesn't exist
        public async Task<User> GetById(string id)
        {
            //get the entoty 
            var result = await _context.Users.FirstAsync(user => user.Id == id);

            //return the retrieved entity
            return result;
        }

        //update an existing user 
        public void Update(User entity)
        {
            //update the entity 
            _context.Update(entity);
        }
    }
}
