using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ionicDemoApI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ionicDemoApI.Controllers
{
    [Route("api/[controller]")]
    public class MachineController : Controller
    {
        [HttpGet]
        public IActionResult GetMachines()
        {
            var machines = FunctionService.Current.Machines;
            return Ok(machines);
        }
    }
}