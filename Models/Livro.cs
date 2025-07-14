using System.ComponentModel.DataAnnotations;

namespace BibliotecaC_.Models
{
    public class Livro
    {
        public int Id { get; set; }

        public string? Titulo { get; set; }
        [Required]
        [StringLength(13, MinimumLength = 13, ErrorMessage = "O ISBN deve ter exatamente 13 caracteres.")]
        public string? Isbn { get; set; }

        public DateTime DataPublicacao { get; set; }

        public ICollection<LivroAutor>? LivrosAutores { get; set; }

        public int EditoraId { get; set; }
        public Editora? Editora { get; set; }
    }
}
