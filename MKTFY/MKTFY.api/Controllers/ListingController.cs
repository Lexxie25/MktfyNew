using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MKTFY.api.Helpers;
using MKTFY.Models.ViewModels.Listing;
using MKTFY.Services.Services.Interfaces;

namespace MKTFY.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ListingController : ControllerBase
    {
        private readonly IListingService _listingService;

        public ListingController(IListingService listingService)
        {
            _listingService = listingService;
        }


        /// <summary>
        /// Creating a New Listing 
        /// </summary>
        /// <param name="data">Listing Data</param>
        /// <returns>Returns a Listing with ID </returns>
        /// <response code = "200">Created A Listing</response>
        /// <response code = "401">Not Currently Logged in</response>
        /// <response code = "500">Database issue</response>
        [HttpPost]

        public async Task<ActionResult<ListingVM>> Create([FromBody] ListingAddVM data)
        {
            try
            {
                var userId = User.GetId();
                if (userId == null)
                    return BadRequest("Invalid user");

                // Have the service creat the new Listing 
                var result = await _listingService.Create(data, userId);

                // return a 200 response with the ListingVM
                return Ok(result);
            }
            catch (DbUpdateException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Unable to contact the database" });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Get all Listings 
        /// </summary>
        /// <returns>Get all Listings </returns>
        [HttpGet]

        public async Task<ActionResult<List<ListingVM>>> GetAll()
        {
            try
            {
                //Get the Listing entitiy from the srevice 
                var result = await _listingService.GetAll();

                // return a 200 response with the ListingVM
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }
        // get a specific Listing By id
        [HttpGet("{id}")]

        public async Task<ActionResult<ListingVM>> Get([FromRoute] Guid id)
        {
            try
            {
                // get the requested Listing entity from the service 
                var results = await _listingService.GetById(id);

                // return a 200 response with the ListingVM
                return Ok(results);
            }
            catch
            {
                return BadRequest(new { messasge = "Unable to retreve the requested Listing" });
            }
        }

        //update the Listing
        [HttpPut]

        public async Task<ActionResult<ListingVM>> Update([FromBody] ListingUpdateVM data)
        {
            try
            {
                // Update a listing entity from the server 
                var result = await _listingService.Update(data);

                // return a 200 response with the ListingVM
                return Ok(result);
            }
            catch (DbUpdateException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Unable to contact the database" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // delete a listing 
        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete([FromRoute] Guid id)
        {
            try
            {
                // tell the repository to delete the requested Listing 
                await _listingService.Delete(id);

                // return a 200 response with the ListingVM
                return Ok();
            }
            catch (DbUpdateException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Unable to contact the database" });
            }
            catch
            {
                return BadRequest(new { message = "Unable to delete the reequested Listing " });
            }
        }

    }
}
