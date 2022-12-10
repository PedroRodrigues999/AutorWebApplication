using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutorWebApplication.Models;

namespace AutorWebApplication.Data
{
    public class AutorWebApplicationContext : DbContext
    {
        public AutorWebApplicationContext (DbContextOptions<AutorWebApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<AutorWebApplication.Models.Autor> Autor { get; set; } = default!;
    }
}
