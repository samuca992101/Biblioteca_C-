using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BibliotecaC_.Models
{
    public class Emprestimo
    {
        public int Id { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime? DataDevolucao { get; set; }
        public bool Devolvido { get; set; }
        public int LivroId { get; set; }
        public Livro? Livro { get; set; }
        public int UsuarioId { get; set; }
        public Usuarios? Usuario { get; set; }
        public int FuncionarioId { get; set; }
        public Funcionario? Funcionario { get; set; }

    }
}
