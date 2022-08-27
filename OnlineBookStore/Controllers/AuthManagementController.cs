using BookCore;
using BookCore.DTOs.Requests;
using BookCore.DTOs.Responses;
using BookData;
using BookData.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OnlineBookStore.Configuration;
using OnlineBookStore.DTOs.Requests;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace OnlineBookStore.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthManagementController : ControllerBase
    {
        private readonly ILogger<AuthManagementController> _logger;
        private readonly UserManager<IdentityUser> _userManger;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUser _user;
        private readonly JwtConfig _jwtConfig;


        public AuthManagementController(IOptionsMonitor<JwtConfig> optionMonitor,
            ILogger<AuthManagementController> logger,   
            UserManager<IdentityUser> userManger,
            RoleManager<IdentityRole> roleManager,
            IUser user
            )
        {
            _logger = logger;
            _userManger = userManger;
            _roleManager = roleManager;
            _jwtConfig = optionMonitor.CurrentValue;
            _user= user;
        }

        // GET: api/<AuthManagementController>
        [HttpGet]
        public IActionResult GetAllRoles()
        {
            var roles = _roleManager.Roles.ToList();
            return Ok(roles);
        }
        
        // POST api/<AuthManagementController> adding user to asp users table 
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register ([FromBody] UserRegestrationDto user)
        {
            if (ModelState.IsValid)
            {
                var existingUser = await _userManger.FindByEmailAsync(user.Email);
                
                if (existingUser != null)
                {
                    return BadRequest("this email already have user");
                }
                var new_user = new IdentityUser() { Email = user.Email, UserName = user.UserName };
                var IsCreated = await _userManger.CreateAsync(new_user,user.Password);
                
                if (IsCreated.Succeeded)    
                {
                    //this line of code makes sure that we create a user with admin role 
                    //await _userManger.AddToRoleAsync(new_user, role);


                    //token generated and to return to the craeted user helps to get roles claims infos and and used for authorizationse
                    //we have async methode GenerateJwtToken() where we passing user async => await required
                    var jwtToken = await GenerateJwtToken(new_user);

                    //returning the token in an OK() methode
                    return Ok(jwtToken);
                }   
                else
                {
                    return BadRequest("unable to create user !");
                }
            }            
            return BadRequest();
        }

        // this post adds a user to asp users table and also in buyer table based on the role buyer in asp user table
        [HttpPost]
        [Route("RegisterBuyer")]
        public async Task<IActionResult> RegisterBuyer([FromBody] UserRegestrationDtoBuyer  Buyer_user)
        {
            if (ModelState.IsValid)
            {
                var existingUser = await _userManger.FindByEmailAsync(Buyer_user.Email);

                if (existingUser != null)
                {
                    return BadRequest("this email already have user");
                }
                var new_user = new IdentityUser() { Email = Buyer_user.Email, UserName = Buyer_user.UserName };
                var IsCreated = await _userManger.CreateAsync(new_user, Buyer_user.Password);

                if (IsCreated.Succeeded)
                {
                    //this line of code makes sure that we create a user with admin role 
                    await _userManger.AddToRoleAsync(new_user, "Buyer");

                    var buyer = new BuyerDto() {
                        First_name = Buyer_user.First_name,
                        Last_name = Buyer_user.Last_name,
                        Adress = Buyer_user.Adress,
                        Ship_Adress = Buyer_user.Ship_Adress,
                        AspUserId = (new_user.Id).ToString()
                    };
                    var usersController = new UsersController(_user, _userManger);
                    usersController.PostBuyer(buyer);

                    //token generated and to return to the craeted user helps to get roles claims infos and and used for authorizationse
                    //we have async methode GenerateJwtToken() where we passing user async => await required
                    var jwtToken = await GenerateJwtToken(new_user);

                    //returning the token in an OK() methode
                    return Ok(jwtToken);
                }
                else
                {
                    return BadRequest("unable to create user !");
                }
            }
            return BadRequest();
        }

        // this post adds a user to asp users table and also in seller table based on the role seller in asp user table
        [HttpPost]
        [Route("RegisterSeller")]
        public async Task<IActionResult> RegisterSeller([FromBody] UserRegestrationDtoSeller Seller_user)
        {
            if (ModelState.IsValid)
            {
                var existingUser = await _userManger.FindByEmailAsync(Seller_user.Email);

                if (existingUser != null)
                {
                    return BadRequest("this email already have user");
                }
                var new_user = new IdentityUser() { Email = Seller_user.Email, UserName = Seller_user.UserName };
                var IsCreated = await _userManger.CreateAsync(new_user, Seller_user.Password);

                if (IsCreated.Succeeded)
                {
                    //this line of code makes sure that we create a user with admin role 
                    await _userManger.AddToRoleAsync(new_user, "Seller");

                    var seller = new SellerDto()
                    {
                        First_name = Seller_user.First_name,
                        Last_name = Seller_user.Last_name,
                        Adress = Seller_user.Adress,
                        Discount = Seller_user.Discount,
                        AspUserId = (new_user.Id).ToString()
                    };
                    var usersController = new UsersController(_user, _userManger);
                    usersController.PostSeller(seller);

                    //token generated and to return to the craeted user helps to get roles claims infos and and used for authorizationse
                    //we have async methode GenerateJwtToken() where we passing user async => await required
                    var jwtToken = await GenerateJwtToken(new_user);

                    //returning the token in an OK() methode
                    return Ok(jwtToken);
                }
                else
                {
                    return BadRequest("unable to create user !");
                }
            }
            return BadRequest();
        }

        //the login processes simulaire to the registration
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest user)
        {
            //checking the model body request
            if (ModelState.IsValid)
            {
                //see if the user exists in database table using methode in the user manager class
                var existingUser = await _userManger.FindByEmailAsync(user.Email);

                if (existingUser == null)
                {
                    BadRequest("this user is not registred !");
                }
                //check on password too
                var isCorrect = await _userManger.CheckPasswordAsync(existingUser, user.Password);
                
                if (!isCorrect) {
                    BadRequest("credentiel dont match !"); 
                }

                //generating the token for the logged user after checking its state (credentiels + existense)
                var jwtToken = GenerateJwtToken(existingUser);
                //ok methode with object where it holds token and succces (logged and everything is fine)
                return Ok(new{ Success = true, Token = jwtToken });
            }
            return BadRequest("wrong infos !");
        }

        //generating token methode
        private async Task<AuthResult> GenerateJwtToken(IdentityUser user)  
         {
            // this jwt handler to handle generating processes
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            
            // key made with encoding the key in appsettings (secret) after mapping it to class and injecting it here 
            var key = Encoding.ASCII.GetBytes(_jwtConfig.Secret);

            //getting all user claimes this is made for the role phase 
            var claims = await GetAllValidClaims(user);

            //description of token claims duration and crypting methode
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddSeconds(30), // 5-10 
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            //after specifying the description we called handler to take what we discribed to make token with
            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            //over here we finilizing the creation processes
            var jwtToken = jwtTokenHandler.WriteToken(token);

            //return the token in authresult obj it holdes prop for token and success 
            return new AuthResult()
            {
                Token = jwtToken,
                Success = true
            };
        }

        //ROLE PHASE
        // Get all valid claims for the corresponding user 
        private async Task<List<Claim>> GetAllValidClaims(IdentityUser user)
        {
            //getting all claims of user we have

            var claims = new List<Claim>
            {
                new Claim("Id", user.Id),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            // Getting the claims that we have assigned to the user
            var userClaims = await _userManger.GetClaimsAsync(user);
            claims.AddRange(userClaims);

            // Get the user role and add it to the claims
            var userRoles = await _userManger.GetRolesAsync(user);

            foreach (var userRole in userRoles)
            {
                var role = await _roleManager.FindByNameAsync(userRole);

                if (role != null)
                {
                    claims.Add(new Claim(ClaimTypes.Role, userRole));
                    
                    var roleClaims = await _roleManager.GetClaimsAsync(role);
                    foreach (var roleClaim in roleClaims)
                    {
                        claims.Add(roleClaim);
                    
                    }
                }
            }
            return claims;
        }



    }
}
