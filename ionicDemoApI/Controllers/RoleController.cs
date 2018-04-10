using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ionicDemoApI.Models;
using ionicDemoApI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ionicDemoApI.Controllers
{
    [Route("api/[controller]")]
    public class RoleController : Controller
    {
        [HttpGet]
        public IActionResult GetRoles()
        {
            return Ok(UserinfoService.Current.Roles);
        }
        [Route("{id}", Name = "GetRole")] //Route匹配任何方式
        public IActionResult GetRole(int id)
        {
            var role = UserinfoService.Current.Roles.SingleOrDefault(p => p.Id == id);
            if (role == null)
            {
                return NotFound();
            }
            return Ok(role);
        }

        [HttpPost]
        public IActionResult Post([FromBody] RoleCreation role)
        {
            if (role == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var maxId = UserinfoService.Current.Roles.Max(x => x.Id);
            var newRole = new Role
            {
                Id = ++maxId,
                Name = role.Name,
                Des = role.Des,
            };
            UserinfoService.Current.Roles.Add(newRole);
            return CreatedAtRoute("GetRole", new { id = newRole.Id }, newRole);
        }
    }
}