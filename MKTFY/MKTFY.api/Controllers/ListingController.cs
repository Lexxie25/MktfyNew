using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MKTFY.api.Helpers;
using MKTFY.Models.ViewModels.Listing;
using MKTFY.Services.Services.Interfaces;
using MKTFY.Shared.Exceptions;

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

            var userId = User.GetId();
            if (userId == null)
                return BadRequest("Invalid user");

            // Have the service creat the new Listing 
            var result = await _listingService.Create(data, userId);

            // return a 200 response with the ListingVM
            return Ok(result);

        }
        /// <summary>
        /// Get all Listings 
        /// </summary>
        /// <returns>Get all Listings </returns>
        [HttpGet]  // need to add not by user that is currently logged in 

        public async Task<ActionResult<List<ListingVM>>> GetAll(string userId)
        {

            //Get the Listing entitiy from the srevice 
            var result = await _listingService.GetAll(string userId);

            // return a 200 response with the ListingVM
            return Ok(result);

        }
        // get a specific Listing By id
        [HttpGet("{id}")]

        public async Task<ActionResult<ListingVM>> Get([FromRoute] Guid id)
        {

            // get the requested Listing entity from the service 
            var results = await _listingService.GetById(id);

            // return a 200 response with the ListingVM
            return Ok(results);

        }

        //update the Listing
        [HttpPut]

        public async Task<ActionResult<ListingVM>> Update([FromBody] ListingUpdateVM data)
        {

            // Update a listing entity from the server 
            var result = await _listingService.Update(data);

            // return a 200 response with the ListingVM
            return Ok(result);

        }


        // delete a listing 
        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete([FromRoute] Guid id)
        {
            // tell the repository to delete the requested Listing 
            await _listingService.Delete(id);

            // return a 200 response with the ListingVM
            return Ok();

        }

    }
}
// Get listing all {city} filters all listings by city and not by user 
//Get listing all {category} filters all listing by category and not by user 
// Get Listing search/{searchstring} name and description fields nor user
// get listing/Filter/ for searching with city andor catefory  or search with no filters not user 
// get listing/deals 16 listings from lowest price to highest price and not from user
// put listing purchase making a listing that will set the user id as a buyers id and update the database 