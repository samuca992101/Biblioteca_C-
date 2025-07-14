using System.ComponentModel.DataAnnotations;

namespace BibliotecaC_.Models
{
    public class LivroAutor
    {
        public int Id { get; set; }
        [Display(Name = "Título do livro")]
        public int LivroId { get; set; }
        public Livro? Livro { get; set; }
        [Display(Name = "Autor do livro")]
        public int AutorId { get; set; }
        public Autor? Autor { get; set; }
    }
}
