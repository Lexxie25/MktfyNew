using MKTFY.Models.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKTFY.Services.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserVM> Create(UserAddVM src);  //Create a new User
        Task<UserVM> GetById(string id);  // Get a single existing user by Id
        Task<UserVM> Update(UserUpdateVM src);  // Update an existing user 
    }
}
