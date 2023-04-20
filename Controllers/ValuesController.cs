using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ms_filmes.Controllers
{
    [Route("[controller]")]
    public class ValuesController : Controller
    {
        [Authorize(Policy = "AdminPolicy")]
        [HttpGet("admin")]
        public IActionResult AdminEndpoint()
        {
            return Ok("Admin endpoint");
        }

        [Authorize(Policy = "UserPolicy")]
        [HttpGet("user")]
        public IActionResult UserEndpoint()
        {
            return Ok("User endpoint");
        }

        private readonly ILogger<ValuesController> _logger;

        public ValuesController(ILogger<ValuesController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}