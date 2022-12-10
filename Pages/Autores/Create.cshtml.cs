using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AutorWebApplication.Data;
using AutorWebApplication.Models;

namespace AutorWebApplication.Pages.Autores
{
    public class CreateModel : PageModel
    {
        private readonly AutorWebApplication.Data.AutorWebApplicationContext _context;

        public CreateModel(AutorWebApplication.Data.AutorWebApplicationContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Autor Autor { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Autor == null || Autor == null)
            {
                return Page();
            }

            _context.Autor.Add(Autor);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
