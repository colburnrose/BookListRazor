using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookListRazor.Data
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name="Book Name")]
        public string Name { get; set; }

        [Display(Name="ISBN")]
        public string Isbn { get; set; }

        public string Author { get; set; }
    }
}
