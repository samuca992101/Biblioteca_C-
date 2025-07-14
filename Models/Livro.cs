using System.ComponentModel.DataAnnotations;

namespace BibliotecaC_.Models
{
    public class Livro
    {
        public int Id { get; set; }
        [Display(Name = "Título")]
        public string? Titulo { get; set; }
        [Required]
        [StringLength(13, MinimumLength = 13, ErrorMessage = "O ISBN deve ter exatamente 13 caracteres.")]
        public string? Isbn { get; set; }
        [Display(Name = "Data da publicação")]
        public DateTime DataPublicacao { get; set; }

        public ICollection<LivroAutor>? LivrosAutores { get; set; }
        [Display(Name = "Editora")]
        public int EditoraId { get; set; }
        public Editora? Editora { get; set; }
    }
}
