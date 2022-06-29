using MKTFY.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKTFY.Repositories.Repositories.Interfaces
{
    public interface IUserRepository
    {
        void Create(User enitiy);   // Create a new User 

        Task<User> GetById(string id);  // get a single User by Id

        void Update(User entity);    // Update an existing user 
    }
}
