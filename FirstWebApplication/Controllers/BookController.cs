using FirstWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FirstWebApplication.Controllers
{
    [RoutePrefix("api/book")]
    public class BookController : ApiController
    {
        private readonly IBookService _bookService = new BookService();

        [HttpGet]
        [CustomAuthorization(Users = "kurien,rahul")]
        [Route("all")]
        public IEnumerable<BookContract> RetrieveAllBooks()
        {
            return _bookService.GetAllBooks();
        }

        [HttpGet]
        [Route("{id:int}")]
        public string BookById(int id)
        {
            if(id < 10)
            {
                return "small value";
            }
            return "big value";
        }

        [HttpGet]
        [Route("{val:alpha}")]
        public string BookByName(string val)
        {
            if (val == "custom")
            {
                return "verified custom";
            }
            return "You entered : "+val;
        }

        [HttpGet]
        [Route("~/something/else")]
        public string SomethingElse()
        {
            return "new route";
        }

        [HttpPost]
        public IHttpActionResult AddBook([FromBody]BookContract book)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _bookService.AddBook(book);
            return Ok("Book added");
        }

        [HttpPut]
        public void Put(int id, [FromBody]string value)
        {
        }

        [HttpDelete]
        public void Delete(int id)
        {
        }
    }
}
