using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BibliotecaC_.Models;

namespace BibliotecaC_.Data
{
    public class BibliotecaC_Context : DbContext
    {
        public BibliotecaC_Context (DbContextOptions<BibliotecaC_Context> options)
            : base(options)
        {
        }

        public DbSet<BibliotecaC_.Models.Autor> Autor { get; set; } = default!;

        public DbSet<BibliotecaC_.Models.Editora>? Editora { get; set; }

        public DbSet<BibliotecaC_.Models.Emprestimo>? Emprestimo { get; set; }

        public DbSet<BibliotecaC_.Models.Endereco>? Endereco { get; set; }

        public DbSet<BibliotecaC_.Models.Funcionario>? Funcionario { get; set; }

        public DbSet<BibliotecaC_.Models.Livro>? Livro { get; set; }

        public DbSet<BibliotecaC_.Models.Reserva>? Reserva { get; set; }

        public DbSet<BibliotecaC_.Models.Usuarios>? Usuarios { get; set; }

        public DbSet<BibliotecaC_.Models.LivroAutor>? LivroAutor { get; set; }
    }
}
