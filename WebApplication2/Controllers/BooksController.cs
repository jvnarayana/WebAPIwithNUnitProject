using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Services;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public readonly iBookService bookService;
       

        public BooksController(iBookService _bookService)
        {
            bookService = _bookService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Book>> Get()
        {
            var result = bookService.GetAll();
            
            return Ok(result);
        }
        [HttpGet("{id}")]
        public ActionResult<Book> Get(Guid id)
        {
            var result = bookService.GuiById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);

        }
        [HttpDelete("{id}")]
        public ActionResult<Book> Remove(Guid id)
        {
           
            bookService.Remove(id);

            return Ok();
        }
        [HttpPost]
        public ActionResult<Book> Post(Book newbook)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = bookService.Add(newbook);

            return CreatedAtAction("Get", new { id = result.Id }, result);
        }


    }
}
