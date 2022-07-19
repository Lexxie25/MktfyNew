using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MKTFY.Models.ViewModels.FAQ;
using MKTFY.Services.Services.Interfaces;

namespace MKTFY.api.Controllers
{
    /// <summary>
    /// Faq Controllers 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class FaqController : ControllerBase
    {
        private readonly IFaqService _faqService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="faqService"></param>
        public FaqController(IFaqService faqService)
        {
            _faqService = faqService;
        }
        /// <summary>
        /// Creating a Faq
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Returns a Faq </returns>
        /// <response code = "200">Created A Faq Admin Only</response>
        /// <response code = "401">Not Currently Logged in</response>
        /// <response code = "500">Database issue</response>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<FaqVM>> Create([FromBody] FaqAddVM data)
        {
            var result = await _faqService.Create(data);
            return Ok(result);
        }

        /// <summary>
        /// Get all the Faqs
        /// </summary>
        /// <returns>all the Faqs in system </returns>
        /// <response code = "200">Get all Faq</response>
        /// <response code = "401">Not Currently Logged in</response>
        /// <response code = "500">Database issue</response>
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<FaqVM>>> GetAll()
        {
            var result = await _faqService.GetAll();

            return Ok(result);
        }

        /// <summary>
        /// Get Faq By ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Specific Faq Id </returns>
        /// <response code = "200">Get Faq by Id </response>
        /// <response code = "401">Not Currently Logged in</response>
        /// <response code = "500">Database issue</response>
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<FaqVM>> Get([FromRoute] Guid id)
        {
            var results = await _faqService.GetById(id);
            return Ok(results);
        }

        /// <summary>
        /// Updates the Faq 
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Updates a faq </returns>
        /// <response code = "200">Updates the Faq </response>
        /// <response code = "401">Not Currently Logged in</response>
        /// <response code = "500">Database issue</response>
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<FaqVM>> Update([FromBody] FaqUpdateVM data)
        {
            var result = await _faqService.Update(data);
            return Ok(result);
        }


        /// <summary>
        /// Deletes a Faq
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Deleted a Faq</returns>
        /// <response code = "200">Deleted a Faq</response>
        /// <response code = "401">Not Currently Logged in</response>
        /// <response code = "500">Database issue</response>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete([FromRoute] Guid id)
        {
            await _faqService.Delete(id);
            return Ok();
        }

    }
}
