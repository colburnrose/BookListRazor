using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;

namespace BookListRazor.Pages.Views.Book
{
    public class EditModel : PageModel
    {
        private readonly BookDbContext _db;

        public EditModel(BookDbContext db)
        {
            _db = db;
        }

        [BindProperty] public Data.Book Book { get; set; }

        [TempData]
        public string Message { get; set; }

        public async Task OnGet(int id)
        {
            Book = await _db.Books.FindAsync(id);
        }

        // Update method to update an existing book.
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var book = await _db.Books.FindAsync(Book.Id);

                book.Name = Book.Name;
                book.Isbn = Book.Isbn;
                book.Author = Book.Author;

                _db.Update(book);
                await _db.SaveChangesAsync();

                Message = "Book has been updated successfully";
                return RedirectToPage("Index");
            }

            return RedirectToPage();
        }
    }
}