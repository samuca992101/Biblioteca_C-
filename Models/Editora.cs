using System.ComponentModel.DataAnnotations;

namespace BibliotecaC_.Models
{
    public class Editora
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        [Required]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "O CNPJ deve ter exatamente 14 caracteres.")]
        public string? Cnpj { get; set; }
        public List<Livro> LivrosList { get; set; } = new List<Livro>();
    }
}
