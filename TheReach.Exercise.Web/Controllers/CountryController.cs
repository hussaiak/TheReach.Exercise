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
    [Route("api/Country")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        { 
            this._countryService = countryService; 
        }


        [HttpGet]
        public async Task<IActionResult> GetCountries()
        {
            var response = await _countryService.GetCountries();
            //Successful
            if (response != null)
            {
                return StatusCode((int)HttpStatusCode.OK, response);
            }
            return StatusCode((int)HttpStatusCode.NoContent);
        }
    }
}