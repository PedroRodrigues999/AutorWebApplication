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
    public class IndexModel : PageModel
    {
        private readonly AutorWebApplication.Data.AutorWebApplicationContext _context;

        public IndexModel(AutorWebApplication.Data.AutorWebApplicationContext context)
        {
            _context = context;
        }

        public IList<Autor> Autor { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Autor != null)
            {
                Autor = await _context.Autor.ToListAsync();
            }
        }
    }
}
