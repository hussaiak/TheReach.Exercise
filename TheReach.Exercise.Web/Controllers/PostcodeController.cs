using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheReach.Exercise.Web.Services;

namespace TheReach.Exercise.Web.Controllers
{
    [Route("api/Postcode")]
    [ApiController]
    public class PostcodeController : ControllerBase
    { 
        private readonly IPostcodeService _postService;

        public PostcodeController( IPostcodeService postService)
        { 
            this._postService = postService;
        }
         
        [HttpGet]
        public IActionResult GetPostcodes()
        {
            var response = _postService.GetPostcodes();
            //Successful
            if (response != null)
            {
                return StatusCode((int)HttpStatusCode.OK, response);
            }
            return StatusCode((int)HttpStatusCode.NoContent);
        }

        [Route("States/{countryCode}"), HttpGet]

        public async Task<IActionResult> GetStatesByCountryCode(string countryCode)
        {
            var response = await _postService.GetStatesByCountryCode(countryCode);
            //Successful
            if (response != null)
            {
                return StatusCode((int)HttpStatusCode.OK, response);
            }
            return StatusCode((int)HttpStatusCode.NoContent);
        }

        [Route("Localities/{stateCode}"), HttpGet]

        public async Task<IActionResult> GetLocalityByStateCode(string stateCode)
        {
            var response = await _postService.GetLocalityByStateCode(stateCode);
            //Successful
            if (response != null)
            {
                return StatusCode((int)HttpStatusCode.OK, response);
            }
            return StatusCode((int)HttpStatusCode.NoContent);
        }
    }
}