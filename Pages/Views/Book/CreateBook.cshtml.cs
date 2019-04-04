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

            Message = "Book has been created successfully " + Book.Name;
            return RedirectToPage("Index");
        }

        [BindProperty]
        public Data.Book Book { get; set; }

        [TempData]
        public string Message { get; set; }

    }
}