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
        
        [Route("all")]
        public IEnumerable<BookModel> Get()
        {
            return _bookService.GetAllBooks();
        }

        [Route("{id}")]
        public string Get(int id)
        {
            if(id < 10)
            {
                return "small value";
            }
            return "big value";
        }

        [Route("string/{val}")]
        public string Get(String val)
        {
            if (val == "custom")
            {
                return "verified custom";
            }
            return "You enterd : "+val;
        }

        [Route("~/something/else")]
        public string GetSomethingElse()
        {
            return "new route";
        }

        public void Post([FromBody]BookModel book)
        {
            _bookService.AddBook(book);
        }

 
        public void Put(int id, [FromBody]string value)
        {
        }


        public void Delete(int id)
        {
        }
    }
}
