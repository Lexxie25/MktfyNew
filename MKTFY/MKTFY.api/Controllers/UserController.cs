using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MKTFY.Models.ViewModels.User;
using MKTFY.Services.Services.Interfaces;

namespace MKTFY.api.Controllers
{/// <summary>
/// 
/// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userService"></param>
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// create a new user       
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<UserVM>> Create([FromBody] UserAddVM data)
        {

            //Have the service Create the new user 
            var result = await _userService.Create(data);

            //Return a 200 responce with the UserVM
            return Ok(result);

        }
        /// <summary>
        /// get a specific user by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<UserVM>> Get([FromRoute] string id)
        {

            //get the requested user entity from the service 
            var result = await _userService.GetById(id);

            // return a 200 responce with the UserVM
            return Ok(result);

        }
        /// <summary>
        /// Update a user
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<UserVM>> Update([FromBody] UserUpdateVM data)
        {

            // Update user entity from the service 
            var result = await _userService.Update(data);

            //return a 200 respomce with the user VM 
            return Ok(result);


        }
    }
}

