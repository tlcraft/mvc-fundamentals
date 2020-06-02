using Microsoft.AspNetCore.Mvc;
using Shared.Models;
using Shared.Services;
using System.Collections.Generic;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public IEnumerable<UserModel> GetUsers()
        {
            var users = this.userService.GetAllUsers();

            return users;
        }

        [HttpGet]
        [Route("{userId}")]
        public IActionResult GetUser(int userId)
        {
            var user = this.userService.GetUser(userId);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public IActionResult CreateUser(UserModel newUser)
        {
            return SaveUser(newUser);
        }

        [HttpPut]
        public IActionResult UpdateUser(UserModel user)
        {
            return SaveUser(user);
        }

        private IActionResult SaveUser(UserModel user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (user.Id > 0)
            {
                this.userService.UpdateUser(user);
            }
            else
            {
                this.userService.AddUser(user);
            }

            return Ok();
        }

        [HttpDelete]
        [Route("{userId}")]
        public IActionResult DeleteUser(int userId)
        {
            if (userId <= 0)
            {
                return BadRequest();
            }

            var recordsUpdated = this.userService.DeleteUser(userId);

            if (recordsUpdated <= 0)
            {
                return BadRequest($"The userId: {userId} doesn't exist.");
            }

            return Ok("Ok");
        }
    }
}
