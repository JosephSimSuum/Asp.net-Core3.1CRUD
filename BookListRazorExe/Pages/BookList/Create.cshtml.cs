﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazorExe.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRazorExe.Pages.BookList
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContex _db;
        public CreateModel(ApplicationDbContex db)
        {
            _db = db;

        }
        [BindProperty]
        public Book Book { get; set; }
        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _db.Book.AddAsync(Book);
                await _db.SaveChangesAsync();
                return RedirectToPage("index");
            }
            else
            {
                return Page();
            }
        }
    }
}