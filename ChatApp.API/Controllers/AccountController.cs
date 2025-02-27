using ChatApp.API.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ChatApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;

        public AccountController(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Hello()
        {
            if(User.Identity == null || !User.Identity.IsAuthenticated)
            {
                return Unauthorized("You are not authenticated");
            }
            return Ok("You are authenticated");
        }

        [Authorize]
        [HttpGet("Profile")]
        public async Task<IActionResult> Profile()
        {
            var currentUser = await userManager.GetUserAsync(User);
            if(currentUser == null)
            {
                return BadRequest();
            }
           
            return Ok(currentUser);
        }
    }
}
