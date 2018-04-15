using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ionicDemoApI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ionicDemoApI.Controllers
{
    [Route("api/role")]
    public class UsersController : Controller
    {
        [HttpGet("{roleId}/users")]
        public IActionResult GetUsers(int roleId)
        {
            var role = UserinfoService.Current.Roles.SingleOrDefault(p => p.Id == roleId);
            if (role == null)
            {
                return NotFound();
            }
            return Ok(role.Users);
        }
  
        [HttpGet("{roleId}/users/{id}")]
        public IActionResult GetUser(int roleId, int id)
        {
            var role = UserinfoService.Current.Roles.SingleOrDefault(p => p.Id == roleId);
            if (role == null)
            {
                return NotFound();
            }
            var user = role.Users.SingleOrDefault(p => p.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet("{roleId}/user")]
        public IActionResult GetUser(int roleId, string username, string password)
        {
            var role = UserinfoService.Current.Roles.SingleOrDefault(p => p.Id == roleId);
            if (role == null)
            {
                return null;
            }
            var user = role.Users.SingleOrDefault(p => p.Username == username && p.Password == password);
            //if (user == null)
            //{
            //    return NotFound();
            //}
            return Ok(user);
        }


    }
}