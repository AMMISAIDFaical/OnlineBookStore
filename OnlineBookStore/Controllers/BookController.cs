using BookCore;
using BookData;
using Microsoft.AspNetCore.Mvc;


namespace OnlineBookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBook ibook;

        public BookController(IBook _Ibook)
        {
            ibook = _Ibook;
        }
        // GET: api/<BookController>
        [HttpGet]
        public IActionResult GetBooks()
        {
            var books =  ibook.GetBooks();
            return Ok(books);
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public IActionResult GetBookById(int id)
        {
           var book = ibook.GetBook(id);
            return Ok(book);
        }

        // POST api/<BookController>
        [HttpPost]
        public IActionResult AddBook([FromBody] Book book)
        {
            ibook.AddBook(book);
            ibook.Commit();
            return CreatedAtAction("GetBooks", book);
        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Book new_book)
        {
            var old_book = ibook.UpdateBook(id, new_book);
            return CreatedAtAction("GetBooks", old_book);

        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var book = ibook.RemoveBook(id);
            ibook.Commit();
            return Ok(book);
        }
    }
}
