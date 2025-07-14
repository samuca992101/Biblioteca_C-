using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BibliotecaC_.Models
{
    public class Emprestimo
    {
        public int Id { get; set; }
        [Display(Name = "Data do empréstimo")]
        public DateTime DataEmprestimo { get; set; }
        [Display(Name = "Data da devolução")]
        public DateTime? DataDevolucao { get; set; }
        public bool Devolvido { get; set; }
        [Display(Name = "Título do livro")]
        public int LivroId { get; set; }
        public Livro? Livro { get; set; }
        [Display(Name = "Nome do usuário")]
        public int UsuarioId { get; set; }
        public Usuarios? Usuario { get; set; }
        [Display(Name = "Nome do funcionário")]
        public int FuncionarioId { get; set; }
        public Funcionario? Funcionario { get; set; }

    }
}
