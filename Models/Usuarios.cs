namespace BibliotecaC_.Models
{
    public class Usuarios
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
        public DateTime DataNascimento { get; set; }

        public List<Endereco> Enderecos { get; set; } = new List<Endereco>();
        // Relacionamentos
        public List<Emprestimo> Emprestimos { get; set; } = new List<Emprestimo>();
        public List<Reserva> Reservas { get; set; } = new List<Reserva>();
    }
}
