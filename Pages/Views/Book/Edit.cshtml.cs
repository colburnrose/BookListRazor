using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRazor.Pages.Views.Book
{
    public class EditModel : PageModel
    {
        private readonly BookDbContext _db;

        public EditModel(BookDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Data.Book Book { get; set; }

        public void OnGet(int id)
        {
            Book = _db.Books.Find(id);
        }


    }
}