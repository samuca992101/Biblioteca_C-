namespace BibliotecaC_.Models
{
    public class LivroAutor
    {
        public int Id { get; set; }
        public int LivroId { get; set; }
        public Livro? Livro { get; set; }

        public int AutorId { get; set; }
        public Autor? Autor { get; set; }
    }
}
