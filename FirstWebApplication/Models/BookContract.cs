using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FirstWebApplication.Models
{
    public class BookContract
    {
        public String ReferenceId { get; set; }

        [Required]
        public String Name { get; set; }

        [Required]
        [MaxLength(10)]
        public String Author { get; set; }

        [Required]
        public String Genre { get; set; }

        [Required]
        public float Price { get; set; }
    }
}