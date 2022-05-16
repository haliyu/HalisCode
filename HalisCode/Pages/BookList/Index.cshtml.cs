using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HalisCode.Blist;
using HalisCode.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HalisCode.Pages.Boolist
{
    public class IndexModel : PageModel
    {

        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Book> Books { get; set; }
       
        public async Task OnGet()
        {
            Books = await _db.Book.ToListAsync();
        }
    }
}
