using BookDemo.Data;
using BookDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace BookDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var books = ApplicationContext.Books;
            return Ok(books);//200 code
        }


        [HttpGet("{id:int}")]
        public IActionResult GetOneBooks(int id)
        {
            var book = ApplicationContext
                .Books
                .Where(b => b.Id.Equals(id))
                .SingleOrDefault();

            if (book is null)
            {
                return NotFound();//404
            }


            return Ok(book);//200 code
        }

        [HttpPost]
        public IActionResult CreateOneBooks([FromBody] Book book)
        {
            try
            {
                if (book is null)
                {
                    return BadRequest();//400                    
                }
                ApplicationContext.Books.Add(book);
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateBook([FromRoute] int id, [FromBody] Book book)
        {
            //check book ?

            var entity = ApplicationContext
                .Books
                .Find(b => b.Id.Equals(id));//tek bir nesne döndğü için sinfleordefault a gertek yok


            if (entity is null)
            {
                return NotFound();//404
            }

            //check id

            if (id != book.Id)
            {
                return BadRequest("Invalid argument");//400
            }

            ApplicationContext.Books.Remove(book);
            book.Id = entity.Id;//map
            ApplicationContext.Books.Add(book);
            return Ok(book);

        }

        [HttpDelete]
        public IActionResult DeleteAllBooks()
        {
            ApplicationContext.Books.Clear();
            return NoContent();//204
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteOneBook([FromRoute(Name = "id")] int id)
        {
            var entity = ApplicationContext
                .Books
                .Find(b => b.Id.Equals(id));

            if (entity is null)
            {
                return NotFound(new
                {
                    StatusCode = 404,
                    message = $"Book wirh id:{id} could not found. "
                });//istemci taraflı hata 404
            }

            ApplicationContext.Books.Remove(entity);
            return NoContent();




        }



        [HttpPatch]
        public IActionResult PartiallyUpdateOneBook([FromRoute(Name = "id")] int id, [FromBody] JsonPatchDocument<Book> bookpatch)
        {
            var entity = ApplicationContext.Books.Find(b => b.Id.Equals(id));

            if (entity is null)
            {
                return NotFound();//404
            }

            bookpatch.ApplyTo(entity);
            return NoContent();//204
        }
    }
}
