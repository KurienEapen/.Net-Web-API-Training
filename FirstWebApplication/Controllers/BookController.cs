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
        private BookService _bookService = new BookService();

        [HttpGet]
        [Route("all")]
        public IEnumerable<BookModel> RetrieveAllBooks()
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
        public string BookByName(String val)
        {
            if (val == "custom")
            {
                return "verified custom";
            }
            return "You enterd : "+val;
        }

        [HttpGet]
        [Route("~/something/else")]
        public string SomethingElse()
        {
            return "new route";
        }

        [HttpPost]
        public void Post([FromBody]BookModel book)
        {
            _bookService.AddBook(book);
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
