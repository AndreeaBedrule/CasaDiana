using CasaDiana.Models;
using CasaDiana.Service;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CasaDiana.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
       
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("/register")]
        public async Task<ActionResult> Register(User user)
        {
            try
            {
                return Ok(await _userService.Register(user));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
           
               
        }
        /*[HttpGet]*/
        /*public async Task<ActionResult<List<User>>> Get() 
        {
            return Ok(await _context.User.ToListAsync());
        }*/

        /*[HttpPost]*/
        /*public async Task<ActionResult<List<User>>> AddUser(User user)
        {
            users.Add(user);
            return Ok(users);
        }*/

    }
}
