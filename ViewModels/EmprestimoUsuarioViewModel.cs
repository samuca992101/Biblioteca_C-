namespace BibliotecaC_.ViewModels
{
    public class EmprestimoUsuarioViewModel
    {

            public int EmprestimoId { get; set; }
            public DateTime DataEmprestimo { get; set; }
            public DateTime? DataDevolucao { get; set; }
            public int UsuarioId { get; set; }
            public string NomeUsuario { get; set; }
            // Adicione outros campos que precisar exibir na View

    }
}
