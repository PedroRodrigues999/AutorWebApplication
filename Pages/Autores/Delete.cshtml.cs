using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AutorWebApplication.Data;
using AutorWebApplication.Models;

namespace AutorWebApplication.Pages.Autores
{
    public class DeleteModel : PageModel
    {
        private readonly AutorWebApplication.Data.AutorWebApplicationContext _context;

        public DeleteModel(AutorWebApplication.Data.AutorWebApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Autor Autor { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Autor == null)
            {
                return NotFound();
            }

            var autor = await _context.Autor.FirstOrDefaultAsync(m => m.Id == id);

            if (autor == null)
            {
                return NotFound();
            }
            else 
            {
                Autor = autor;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Autor == null)
            {
                return NotFound();
            }
            var autor = await _context.Autor.FindAsync(id);

            if (autor != null)
            {
                Autor = autor;
                _context.Autor.Remove(Autor);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
