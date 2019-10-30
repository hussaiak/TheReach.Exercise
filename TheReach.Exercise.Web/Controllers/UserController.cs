using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheReach.Exercise.DataModel.Models;
using TheReach.Exercise.Web.Services;
using TheReach.Exercise.Web.ViewModel;

namespace TheReach.Exercise.Web.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            this._userService = userService;
        } 

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var response = await _userService.GetUsers();
            //Successful
            if (response != null)
            {
                return StatusCode((int)HttpStatusCode.OK, response);
            }
            return StatusCode((int)HttpStatusCode.NoContent);
        }

        [Route("Submit"), HttpPost]
        public async Task<IActionResult> SubmitUserApplication(UserDetails userDetails)
        {
            var response = await _userService.SubmitUserApplication(userDetails);
            //Successful 
            return StatusCode((int)HttpStatusCode.OK, response); 
        }
    }
}