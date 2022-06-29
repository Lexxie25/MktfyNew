using MKTFY.Models.Entities;
using MKTFY.Models.ViewModels.User;
using MKTFY.Repositories;
using MKTFY.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKTFY.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _uow;

        public UserService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<UserVM> Create(UserAddVM src)
        {
            //create the new user entity
            var newEntity = new User(src);

            // have the repository creat the new user 
            _uow.Users.Create(newEntity);
            await _uow.SaveAsync();

            //Creat the UserVM we want to return to the client 
            var model = new UserVM(newEntity);

            //return a userVM
            return model;
        }
        public async Task<UserVM> GetById(string id)
        {
            // Get the requested user Entity from the repository 
            var result = await _uow.Users.GetById(id);

            // create the User vm we want to return to the client 
            var modle = new UserVM(result);

            //Return the UserVM
            return modle;

        }

        public async Task<UserVM> Update(UserUpdateVM src)
        {
            // get the existing entity 
            var entity = await _uow.Users.GetById(src.Id);

            //perform the update
            entity.FirstName = src.FirstName;
            entity.LastName = src.LastName;
            entity.Phone = src.Phone;

            // Have the repository update the user 
            _uow.Users.Update(entity);
            await _uow.SaveAsync();

            // create the UserVM we want to return to the client 
            var model = new UserVM(entity);

            //return a 200 response with the UserVM
            return model;


        }









    }
}
