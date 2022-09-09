using BookCore;
using BookData;
using Microsoft.AspNetCore.Mvc;


namespace OnlineBookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICart _cart;
 
        public CartController(ICart cart, IBook book)
        {
            _cart = cart;
         }
        // GET: api/<CartController>
        [HttpGet]
        public IActionResult GetCart()
        {
            var carts = _cart.GetAllCart();
            return Ok(carts);
        }

        [HttpGet("bId")]
        public IActionResult GetBookOfCart(int bId)
        {
            var books = _cart.GetCartBooks(bId);
            return Ok(books);
        }


        // GET api/<CartController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpGet("{buyerId},getCarByBuyer")]
        public IActionResult GetCartBuyerId(int buyerId)
        {
            var cart = _cart.GetCartByBuyerId(buyerId);
            return Ok(cart);
        }


        [HttpPost]
        public IActionResult AddCartForBuyer(int Id)
        {
            _cart.AddCartBuyer(Id);
            return Ok("created");

        }

        [HttpPost("{buyerId},{bookId}")]
        public IActionResult AddBookToCart(int buyerId, int bookId)
        {
            _cart.AddBookToCart(buyerId, bookId);
            return Ok("added");
        }

        // PUT api/<CartController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CartController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
