using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Lab4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly Catalog catalog;

        public BooksController(Catalog catalog)
        {
            this.catalog = catalog;
        }

        // GET: api/Books
        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetAllBooks()
        {
            var books = catalog.GetAllBooks();
            return Ok(books);
        }

        // GET: api/Books/{title}
        [HttpGet("{title}")]
        public ActionResult<IEnumerable<Book>> GetBooksByTitle(string title)
        {
            var books = catalog.SearchByTitle(title);
            return Ok(books);
        }

        // GET: api/Books/author/{author}
        [HttpGet("author/{author}")]
        public ActionResult<IEnumerable<Book>> GetBooksByAuthor(string author)
        {
            var books = catalog.SearchByAuthor(author);
            return Ok(books);
        }

        // GET: api/Books/isbn/{isbn}
        [HttpGet("isbn/{isbn}")]
        public ActionResult<Book> GetBookByISBN(string isbn)
        {
            var book = catalog.SearchByISBN(isbn).FirstOrDefault();
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        // GET: api/Books/keywords?keywords=keyword1,keyword2
        [HttpGet("keywords")]
        public ActionResult<IEnumerable<Book>> GetBooksByKeywords([FromQuery] List<string> keywords)
        {
            var books = catalog.SearchByKeywords(keywords);
            return Ok(books);
        }

        // POST: api/Books
        [HttpPost]
        public ActionResult<Book> AddBook(Book book)
        {
            catalog.AddBook(book);
            return CreatedAtAction(nameof(GetBookByISBN), new { isbn = book.ISBN }, book);
        }
    }
}
