using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ionicDemoApI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ionicDemoApI.Controllers
{
    [Route("api/[controller]")]
    public class FunctionController : Controller
    {
        [HttpGet]
        public IActionResult GetFunctions()
        {
            var functions = FunctionService.Current.Functions;
            return Ok(functions);
        }
    }
}