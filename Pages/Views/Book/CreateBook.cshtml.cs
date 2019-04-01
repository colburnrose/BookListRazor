using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace BookListRazor.Pages.Views.Book
{
    public class CreateBookModel : PageModel
    {
        private readonly BookDbContext _db;

        public CreateBookModel(BookDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _db.Books.Add(Book);
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }

        [BindProperty]
        public Data.Book Book { get; set; }

        //[Display(Name="Book Name")]
        //[DataType(DataType.Text)]
        //[StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters.")]
        //public string Name { get; set; }

        //[Display(Name="IBSN")]
        //[DataType(DataType.Text)]
        //public string Isbn { get; set; }

        //[Display(Name = "Author")]
        //[DataType(DataType.Text)]
        //public string Author { get; set; }
    }
}