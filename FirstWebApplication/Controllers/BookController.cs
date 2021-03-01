using FirstWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FirstWebApplication.Controllers
{
    public class BookController : ApiController
    {
        private BookService _bookService = new BookService();
        // GET: api/Message
        public IEnumerable<BookModel> Get()
        {
            return _bookService.GetAllBooks();
        }

        // GET: api/Message/5
        public string Get(int id)
        {
            if(id < 10)
            {
                return "small value";
            }
            return "big value";
        }

        // POST: api/Message
        public void Post([FromBody]BookModel book)
        {
            _bookService.AddBook(book);
        }

        // PUT: api/Message/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Message/5
        public void Delete(int id)
        {
        }
    }
}
