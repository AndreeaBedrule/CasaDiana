using CasaDiana.Dto;
using CasaDiana.Models;
using CasaDiana.Service;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CasaDiana.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class UsersController : ControllerBase
    {
       
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("/register")]
        public async Task<ActionResult> Register(UserDto userDto)
        {
            try
            {
                return Ok(await _userService.Register(userDto));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }      
        }

        [HttpPost]
        [Route("/login")]
        public IActionResult Login(AuthentiactionCredentials credentials)
        {
            try
            {
                return Ok(_userService.Login(credentials));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("/getOneUser")]
        public async Task<ActionResult> GetOneUser(int id)
        {
            return Ok(await _userService.GetOne(id));
        }
    }
}
