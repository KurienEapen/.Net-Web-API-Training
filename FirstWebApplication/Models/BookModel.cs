using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstWebApplication.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        public int ReferenceId { get; set; }
        public String Type { get; set; }
        public int Pages { get; set; }
        public float Price { get; set; }
    }
}