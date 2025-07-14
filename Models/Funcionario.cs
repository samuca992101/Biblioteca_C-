namespace BibliotecaC_.Models
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Matricula { get; set; }
        public CargoEnum Cargo { get; set; }
        public enum CargoEnum
        {
            Bibliotecario = 1,
            Atendente = 2,
            Gerente = 3,
            Auxiliar = 4
        }
        public List<Emprestimo> Emprestimos { get; set; } = new List<Emprestimo>();

    }
}
