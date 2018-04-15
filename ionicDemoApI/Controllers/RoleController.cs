using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ionicDemoApI.Dtos;
using ionicDemoApI.Models;
using ionicDemoApI.Repositories;
using ionicDemoApI.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ionicDemoApI.Controllers
{
    [Route("api/[controller]")]
    public class RoleController : Controller
    {
        private readonly ILogger<RoleController> _logger;
        private readonly IMailService _mailService;
        private readonly IUserinfoRepository _userinfoRepository;
        public RoleController(ILogger<RoleController> logger,
            IMailService mailService,
            IUserinfoRepository userinfoRepository) //构造函数中 注入logger
        {
            //HttpContext.RequestServices.GetService(typeof(ILogger<RoleController>));
            _logger = logger;
            _mailService = mailService;
            _userinfoRepository = userinfoRepository;
        }

        [HttpGet]
        public IActionResult GetRoles()
        {
            var roles = _userinfoRepository.GetRoles();
            var results = new List<RoleWithoutUserDto>();
            foreach (var role in roles) {
                results.Add(new RoleWithoutUserDto
                {
                    Id=role.Id,
                    Name=role.Name,
                    Des =role.Des,
                    CreateTime =role.CreateTime,
                    ModifyTime =role.ModifyTime,
                });
            }
            return Ok(results);
            //return Ok(UserinfoService.Current.Roles);
        }
        [HttpGet("{id}", Name = "GetRole")] //Route匹配任何方式
        public IActionResult GetRole(int id)
        {
            try
            {
                //Console.Write(id);
                // throw new Exception("来个异常！！！");
                var role = UserinfoService.Current.Roles.SingleOrDefault(p => p.Id == id);
                if (role == null)
                {
                    _logger.LogInformation($"Id为{id}的角色没有被找到..");
                    return NotFound();
                }

                return Ok(role);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"查找Id为{id}的产品时出现了错误!!", ex);
                return StatusCode(500, "处理请求的时候发生了错误！");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] RoleCreation role)
        {
            if (role == null)
            {
                return BadRequest();
            }
            if (role.Name == "管理员")
            {
                ModelState.AddModelError("Name", "角色名称不能是管理员！");
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
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] RoleModification role)
        {
            var model = UserinfoService.Current.Roles.SingleOrDefault(p => p.Id == id);
            if (model == null)
            {
                return NotFound();
            }
            if (role == null)
            {
                return BadRequest();
            }
            model.Name = role.Name;
            model.Des = role.Des;
            //return Ok(model);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody] JsonPatchDocument<RoleModification> patchDoc)
        {
            var model = UserinfoService.Current.Roles.SingleOrDefault(p => p.Id == id);
            if (model == null)
            {
                return NotFound();
            }
            if (patchDoc == null)
            {
                return BadRequest();
            }
            var toPatch = new RoleModification
            {
                Name = model.Name,
                Des = model.Des,
            };
            patchDoc.ApplyTo(toPatch, ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            TryValidateModel(toPatch);
            Console.Write(toPatch);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            model.Name = toPatch.Name;
            model.Des = toPatch.Des;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var model = UserinfoService.Current.Roles.SingleOrDefault(p => p.Id == id);
            if (model == null)
            {
                return NotFound();
            }
            UserinfoService.Current.Roles.Remove(model);
            _mailService.Send("Product Deleted", $"Id为{id}的产品被删除了");
            return NoContent();
        }
    }
}