using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MKTFY.Models.ViewModels.Upload;
using MKTFY.Services.Services.Interfaces;

namespace MKTFY.api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly IUploadService _uploadService;

        /// <summary>
        /// Constructor for Dependency Injection 
        /// </summary>
        /// <param name="uploadService"></param>
        public UploadController(IUploadService uploadService)
        {
            _uploadService = uploadService;
        }


        /// <summary>
        /// Upload 1 or more Files 
        /// </summary>
        /// <returns>Uploads Listing to AWS </returns>
        /// <response code = "200">Uploaded</response>
        /// <response code = "401">Not Currently Logged in</response>
        /// <response code = "500">Database issue</response>
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<List<UploadResultVM>>> UploadImage()
        {

            // validate the file types
            var supportedTypes = new[] { ".png", ".gif", ".jpg", ".jpeg" };
            var uploadedExtentions = Request.Form.Files.Select(i => System.IO.Path.GetExtension(i.FileName));
            var mismachedFound = uploadedExtentions.Any(i => !supportedTypes.Contains(i));
            if (mismachedFound)
                return BadRequest(new { message = "At least one Uploaded file is not a valid image type" });

            var results = await _uploadService.UploadFiles(Request.Form.Files.ToList());
            return Ok(results);

        }


    }
}
