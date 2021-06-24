using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Curso.Domains.Entities;

namespace Curso.Infraestructure.Data.UoW {
    public class ApplicationDbContext : DbContext {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) {
        }
        public DbSet<Contacto> Contacto { get; set; }
    }
}
