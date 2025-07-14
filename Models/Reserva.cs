namespace BibliotecaC_.Models
{
    public class Reserva
    {
        public int Id { get; set; }
        public DateTime DataReserva { get; set; }
        public DateTime? DataConclusaoReserva { get; set; }
        public int LivroId { get; set; }
        public Livro? Livro { get; set; }
        public int UsuarioId { get; set; }
        public Usuarios? Usuario { get; set; }

    }
}
