using FirstWebApplication.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace FirstWebApplication
{
    
        public interface IBookService
        {
            IEnumerable<BookContract> GetAllBooks();
            void AddBook(BookContract newBook);
            bool DeleteBook(string name);
            BookModel FindBook(string name);
        }

        public class BookService : IBookService
        {
            private readonly BookProvider _bookProvider = new BookProvider();
            private void WriteToFile()
            {
                StreamWriter writer = new StreamWriter(@"C:\Users\kurie\source\training\FirstWebApplication\FirstWebApplication\App_Data\file.txt");
                var data = JsonConvert.SerializeObject(WebApiConfig.AllBooks);
                writer.Write(data);
                writer.Close();
                writer.Dispose();
            }
            
            public void AddBook(BookContract newBook)
            {
                WebApiConfig.AllBooks.Add(newBook.ToModel());
                _bookProvider.AddDevice(newBook.ToModel().ToEntity());
            }

            public bool DeleteBook(string name)
            {
                throw new NotImplementedException();
            }

            public BookModel FindBook(string name)
            {
                throw new NotImplementedException();
            }

            public IEnumerable<BookContract> GetAllBooks()
            {
                // WebApiConfig.AllBooks.Clear();
                // StreamReader reader = new StreamReader(@"C:\Users\kurie\source\training\FirstWebApplication\FirstWebApplication\App_Data\file.txt");
                // string rdata = reader.ReadToEnd();
                // List<BookModel> rDevices = JsonConvert.DeserializeObject<List<BookModel>>(rdata);
                // WebApiConfig.AllBooks = rDevices;
                // reader.Close();
                // reader.Dispose();
                var rBooks = _bookProvider.GetAllBooks();
                return rBooks.Select(x => x.ToModel().ToContract());
            }
        }
   
}