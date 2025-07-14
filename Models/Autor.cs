namespace BibliotecaC_.Models
{
    public class Autor
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Nacionalidade { get; set; }
        public ICollection<LivroAutor>? LivrosAutores { get; set; }
    }
}
