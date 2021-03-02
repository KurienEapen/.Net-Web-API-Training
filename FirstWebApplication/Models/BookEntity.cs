using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstWebApplication.Models
{
    public class BookEntity
    {
        public int Id { get; set; }
        public int ReferenceId { get; set; }
        public String Name { get; set; }
        public String Author { get; set; }
        public int Genre { get; set; }
        public float Price { get; set; }
    }
}