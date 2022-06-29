using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MKTFY.Models.ViewModels.User;
using MKTFY.Services.Services.Interfaces;

namespace MKTFY.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        //create a new user/        /api/user this is the Postman route 
        [HttpPost]
        public async Task<ActionResult<UserVM>> Create([FromBody] UserAddVM data)
        {
            try
            {
                //Have the service Create the new user 
                var result = await _userService.Create(data);

                //Return a 200 responce with the UserVM
                return Ok(result);
            }
            catch (DbUpdateException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = " Unable to contact the database" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //get a specific user by Id
        [HttpGet("{id}")]
        public async Task<ActionResult<UserVM>> Get([FromRoute] string id)
        {
            try
            {
                //get the requested user entity from the service 
                var result = await _userService.GetById(id);

                // return a 200 responce with the UserVM
                return Ok(result);
            }
            catch
            {
                return BadRequest(new { message = "Unable to retrieve the requested user " });

            }
        }
        //Update a user
        [HttpPut]
        public async Task<ActionResult<UserVM>> Update([FromBody] UserUpdateVM data)
        {
            try
            {
                // Update user entity from the service 
                var result = await _userService.Update(data);

                //return a 200 respomce with the user VM 
                return Ok(result);
            }
            catch (DbUpdateException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "unable to contact the database" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
