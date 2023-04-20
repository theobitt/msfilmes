// using System;
// using System.Collections.Generic;
// using System.Diagnostics;
// using System.IdentityModel.Tokens.Jwt;
// using System.Linq;
// using System.Security.Claims;
// using System.Text;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.Extensions.Logging;
// using Microsoft.IdentityModel.Tokens;
// using Microsoft.Extensions.Configuration;


// namespace ms_filmes.Controllers
// {
//     [Route("[controller]")]
//     public class AuthController : ControllerBase
//     {
//         // private readonly ILogger<AuthController> _logger;
//         private readonly IConfiguration _configuration;

//     public AuthController(IConfiguration configuration)
//     {
//         _configuration = configuration;
//     }

//         [HttpPost]
//         [AllowAnonymous]
//         public IActionResult Login([FromBody] LoginDto login)
//         {
//             if (login == null)
//             {
//                 return BadRequest("Invalid client request");
//             }

//             if (login.Username == "admin" && login.Password == "password")
//             {
//                 var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]));
//                 var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

//                 var tokenOptions = new JwtSecurityToken(
//                     issuer: Configuration["Jwt:Issuer"],
//                     audience: Configuration["Jwt:Issuer"],
//                     claims: new List<Claim>(),
//                     expires: DateTime.Now.AddMinutes(30),
//                     signingCredentials: signinCredentials
//                 );

//                 var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
//                 return Ok(new { Token = tokenString });
//             }

//             return Unauthorized();
//         }

//         public AuthController(ILogger<AuthController> logger)
//         {
//             _logger = logger;
//         }

//         public IActionResult Index()
//         {
//             return View();
//         }

//         [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
//         public IActionResult Error()
//         {
//             return View("Error!");
//         }
//     }
// }