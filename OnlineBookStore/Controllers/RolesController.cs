using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace OnlineBookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<RolesController> _logger;

        public RolesController(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ILogger<RolesController> logger)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _logger = logger;
        }

        // GET: getting roles reqeust 
        [HttpGet]
        public IActionResult GetAllRoles ()
        {
            var roles = _roleManager.Roles.ToList();
            return Ok(roles);
        }

        // POST create roles 
        [HttpPost]
        public async Task<IActionResult> CreateRole (string name)
        {
            //check if the role exist 
            var roleExist = await _roleManager.RoleExistsAsync(name);

            if (!roleExist) 
            {
                var roleResult = await _roleManager.CreateAsync(new IdentityRole(name));
                if (roleResult.Succeeded)
                {
                    return Ok($"role created succesfully {name}");
                    _logger.LogInformation($"role created succesfully {name}");
                }
                else
                {
                    return BadRequest($"could not create the role {name}");
                    _logger.LogInformation($"could not create the role {name}");
                }
            } else
            {
                return BadRequest($"this role {name} already exists !");
                _logger.LogInformation($"this role {name} already exists !");

            }
        }

        [HttpGet("users")]
        //[Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userManager.Users.ToListAsync();
            return Ok(users);
        }

        [HttpPost]
        [Route("GivingUserToRole")]
        public async Task <IActionResult> AddUserToRole(string email ,  string roleName)
        {
            // first checking if user exists 
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return BadRequest("this user doesnt exists");
            }
            // then checking if role exists 
            var role = await _roleManager.RoleExistsAsync(roleName);
            if (role == null)
            {
                return BadRequest("this role doesnt exists");
            }
            var result = await _userManager.AddToRoleAsync(user, roleName);

            if (result.Succeeded)
            {
                return Ok($"its all good user with {email} has been assigned to role {roleName}");
            }
            else
            {
                return BadRequest("adding the user to role failed");
            }
        }

        [HttpGet("getRoleOfUser")]
        public async Task<IActionResult> GetRoleOfUser(string email)
        {
            // first checking if user exists 
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return BadRequest("this user doesnt exists");
            }
            var role = await _userManager.GetRolesAsync(user);
            return Ok(role);
        }

        // GET api/<RolesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }


        // PUT api/<RolesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RolesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
