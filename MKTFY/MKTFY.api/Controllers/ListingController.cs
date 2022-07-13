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
    /// <summary>
    /// Listing Controllers 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ListingController : ControllerBase
    {
        private readonly IListingService _listingService;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="listingService"></param>
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
        [HttpGet]  // need to add not by user that is currently logged in userId/// string userId

        public async Task<ActionResult<List<ListingVM>>> GetAll()
        {

            //Get the Listing entitiy from the srevice 
            var result = await _listingService.GetAll();

            // return a 200 response with the ListingVM
            return Ok(result);

        }
        /// <summary>
        /// get a specific Listing By id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]

        public async Task<ActionResult<ListingVM>> Get([FromRoute] Guid id)
        {

            // get the requested Listing entity from the service 
            var results = await _listingService.GetById(id);

            // return a 200 response with the ListingVM
            return Ok(results);

        }

        /// <summary>
        /// update the Listing
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPut]

        public async Task<ActionResult<ListingVM>> Update([FromBody] ListingUpdateVM data)
        {

            // Update a listing entity from the server 
            var result = await _listingService.Update(data);

            // return a 200 response with the ListingVM
            return Ok(result);

        }


        /// <summary>
        /// delete a listing 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete([FromRoute] Guid id)
        {
            // tell the repository to delete the requested Listing 
            await _listingService.Delete(id);

            // return a 200 response with the ListingVM
            return Ok();

        }

        /// <summary>
        /// Search string 
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns></returns>
        [HttpGet("search/{searhString}")]
        public async Task<ActionResult<List<ListingVM>>> Search(string searchString)
        {
            var userId = User.GetId();
            if (userId == null)
                return BadRequest("Invalid user");

            var results = await _listingService.Search(searchString, userId);
            return Ok(results);
        }

        /// <summary>
        /// when purchesed listing is actavated will asing the user id tha tis logged into the buyer id 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPut("purchase")]
        public async Task<ActionResult<ListingVM>> Purchase([FromBody] ListingPurchaseVM data)
        {
            var buyerId = User.GetId();
            if (buyerId == null)
                return BadRequest("Invalad User");

            // Update the Listing 
            var result = await _listingService.Purchase(data, buyerId);
            return Ok(result);
        }


        /// <summary>
        /// city controller 
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        [HttpGet("all/{city}")]
        public async Task<ActionResult<ListingVM>> GetAllByCity(string city)
        {
            var userId = User.GetId();
            if (userId == null)
                return BadRequest("Invalad User");

            //Get the Listing entitiy from the srevice 
            var result = await _listingService.GetAllByCity(city, userId);

            // return a 200 response with the ListingVM
            return Ok(result);

        }


        /// <summary>
        /// category controller 
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        [HttpGet("all/{category}")]
        public async Task<ActionResult<ListingVM>> GetAllByCategory(string category)
        {
            var userId = User.GetId();
            if (userId == null)
                return BadRequest("Invalad User");

            //Get the Listing entitiy from the srevice 
            var result = await _listingService.GetAllByCategory(category, userId);

            // return a 200 response with the ListingVM
            return Ok(result);

        }
    }
}



// get listing/Filter/ for searching with city andor category  or search with no filters not user 

