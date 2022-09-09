using BookCore;
using BookData;
using BookData.DTOs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace OnlineBookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookDbContext _context;
        private readonly IBook ibook;

        public BookController(BookDbContext context, IBook ibook)
        {
            _context = context;
            this.ibook = ibook;
        }
        
        // GET: api/<BookController>
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpGet]
        public IActionResult GetBooks()
         {
            var books = ibook.GetBooks();
            return Ok(books);   
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = ibook.GetBook(id);
            return Ok(book);
        }

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Seller")]
        [HttpGet("{seller_id},sellerBooks")]
        public async Task<IActionResult> GetBooksBySeller(int seller_id)
        {
            var Sellerbooks = await ibook.GetBooksBySeller(seller_id);
            return Ok(Sellerbooks);
        }   
        
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Buyer")]
        [HttpGet("{buyer_id},buyerBooks")]
        public async Task<IActionResult> GetBooksByBuyer(int buyer_id)
        {
            var Buyerbooks = await ibook.GetBooksByBuyer(buyer_id);
            return Ok(Buyerbooks);
        }

        // POST api/<BookController>
        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody] BookDto book)
        {
            if (ModelState.IsValid)
            {
                    ibook.AddBook(book);
                    return CreatedAtAction("GetBooks", book.Id, book);
            } else
            {
                return BadRequest("wrong model");
            }
        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] BookDto new_book)
        {
            var old_book = ibook.UpdateBook(id,  new_book);
            return CreatedAtAction("GetBooks", new_book.Id,new_book);
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var book = ibook.RemoveBook(id);
            return Ok(book);
        }
    }
}
