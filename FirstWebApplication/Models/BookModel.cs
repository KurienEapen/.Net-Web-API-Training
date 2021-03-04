using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstWebApplication.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        public String ReferenceId { get; set; }
        public String Name { get; set; }
        public String Author { get; set; }
        public String Genre { get; set; }
        public float Price { get; set; }
    }
}