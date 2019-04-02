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

        public List<Data.Book> Books { get; set; }

        public async Task OnGet()
        {
            Books = await _db.Books.ToListAsync();
        }
    }
}