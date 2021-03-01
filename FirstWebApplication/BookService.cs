using FirstWebApplication.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace FirstWebApplication
{
    
        public interface IBookServce
        {
            IEnumerable<BookModel> GetAllBooks();
            void AddBook(BookModel newBook);
            bool DeleteBook(string Name);
            BookModel FindBook(string Name);
        }

        public class BookService : IBookServce
        {
            private void WriteToFile()
            {
                StreamWriter writer = new StreamWriter(@"C:\Users\kurie\source\training\FirstWebApplication\FirstWebApplication\App_Data\file.txt");
                var data = JsonConvert.SerializeObject(WebApiConfig.AllBooks);
                writer.Write(data);
                writer.Close();
                writer.Dispose();
            }
            
            public void AddBook(BookModel newBook)
            {
                WebApiConfig.AllBooks.Add(newBook);
                WriteToFile();
            }

            public bool DeleteBook(string Name)
            {
                throw new NotImplementedException();
            }

            public BookModel FindBook(string Name)
            {
                throw new NotImplementedException();
            }

            public IEnumerable<BookModel> GetAllBooks()
            {
                WebApiConfig.AllBooks.Clear();
                StreamReader reader = new StreamReader(@"C:\Users\kurie\source\training\FirstWebApplication\FirstWebApplication\App_Data\file.txt");
                string rdata = reader.ReadToEnd();
                List<BookModel> rdevices = JsonConvert.DeserializeObject<List<BookModel>>(rdata);
                WebApiConfig.AllBooks = rdevices;
                reader.Close();
                reader.Dispose();
                return rdevices;
            }
        }
   
}