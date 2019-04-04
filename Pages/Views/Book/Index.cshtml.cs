using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookListRazor.Pages.Views.Book
{
    public class IndexModel : PageModel
    {
        private readonly BookDbContext _db;

        public IndexModel(BookDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Data.Book> Books { get; set; }

        [TempData]
        public string Message { get; set; }

        public async Task OnGet()
        {
            Books = await _db.Books.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var book = await _db.Books.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            _db.Remove(book);
            await _db.SaveChangesAsync();

            Message = "Book has been deleted successfully";
            return RedirectToPage("Index");
        }
    }
}