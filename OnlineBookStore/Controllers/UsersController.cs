using BookCore;
using BookData;
using BookData.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using OnlineBookStore.Configuration;

namespace OnlineBookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUser _iuser;
        private readonly UserManager<IdentityUser> _userManger;

        public UsersController(IUser iuser, UserManager<IdentityUser> userManger)
        {
            _iuser  = iuser;
            _userManger = userManger;
        }
        // GET: api/<UsersController>
        [HttpGet("GetSellers")]
        public async Task<IActionResult> GetSellers()
        {
            var sellers = await _iuser.GetSellers();
            return Ok(sellers);
        }

        [HttpGet("GetBuyers")]
        public async Task<IActionResult> GetBuyers()
        {
            var buyers = await _iuser.GetBuyers();
            return Ok(buyers);
        }

        // GET api/<UsersController>/5 //seller
        [HttpGet("{id},sellerId")]
        public async Task<IActionResult> GetSellerById(int seller_id)
        {
            return Ok(await _iuser.GetSellerById(seller_id));
        }

        // GET api/<UsersController>/5 //buyer
        [HttpGet("{id},buyerId")]
        public async Task<IActionResult> GetBuyerById(int buyer_id)
        {
            return Ok(await _iuser.GetBuyerById(buyer_id));
        }

        [HttpGet("{id},BuyerEmail")]
        public async Task<string> GetBuyerEmail (int id)
        {
            var buyer = _iuser.GetBuyerById (id);
            var user = await _userManger.FindByIdAsync(buyer.Result.AspUserId);
            var email = user.Email;
            return email;
        }

        [HttpGet("{id},SellerEmail")]
        public async Task<string> GetSellerEmail(int id)
        {
            var buyer = _iuser.GetSellerById(id);
            var user = await _userManger.FindByIdAsync(buyer.Result.AspUserId);
            var email = user.Email;
            return email;
        }

        // POST api/<UsersController> //add seller
        [HttpPost("seller")]
        public async Task<IActionResult> PostSeller ([FromBody] SellerDto seller)
        {
            _iuser.AddSeller(seller);
            return CreatedAtAction("Get",seller);
        }

        //POST api/<UsersController> //add buyer
        [HttpPost("buyer")]
        public async Task<IActionResult> PostBuyer([FromBody] BuyerDto buyer)
        {
            _iuser.AddBuyer(buyer);
            return CreatedAtAction("Get", buyer);
        }

        
        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id},removeSeller")]
        public void Delete(int id)
        {
            var sller = _iuser.RemoveSeller(id);
            _iuser.Commit();
        }
    }
}
