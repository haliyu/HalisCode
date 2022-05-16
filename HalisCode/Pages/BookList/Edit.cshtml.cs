using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HalisCode.Blist;
using HalisCode.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HalisCode.Pages.BookList
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Book Books { get; set; }

        public async Task OnGet(int id)
        {
           Books = await _db.Book.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var BookofDb = await _db.Book.FindAsync(Books.Id);

                BookofDb.Name = Books.Name;
                BookofDb.Author = Books.Author;
                BookofDb.Isbn = Books.Isbn;

                await _db.SaveChangesAsync();

                return RedirectToPage("Index");

            }
            return RedirectToPage();
        }
    }
}
