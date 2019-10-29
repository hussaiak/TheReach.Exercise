using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheReach.Exercise.DataModel.Models;
using TheReach.Exercise.Web.Services;

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
        public IActionResult GetUsers()
        {
            var response = _userService.GetUsers();
            //Successful
            if (response != null)
            {
                return StatusCode((int)HttpStatusCode.OK, response);
            }
            return StatusCode((int)HttpStatusCode.NoContent);
        }
    }
}