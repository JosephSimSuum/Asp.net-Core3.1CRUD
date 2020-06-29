using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazorExe.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Query;

namespace BookListRazorExe.Pages.BookList
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContex _db;

        public EditModel(ApplicationDbContex db)
        {
            _db = db;
        }
        [BindProperty]
        public Book Book { get; set; }
        public async Task OnGet(int id)
        {
           Book= await _db.Book.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var BookFronDb = await _db.Book.FindAsync(Book.id);
                BookFronDb.Name = Book.Name;
                BookFronDb.Author = Book.Author;
                BookFronDb.ISBN = Book.ISBN;

                await _db.SaveChangesAsync();
                return RedirectToPage("index");


            }
            return RedirectToPage();
        }
    }
}