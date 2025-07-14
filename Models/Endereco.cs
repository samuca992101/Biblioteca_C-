using System.ComponentModel.DataAnnotations;

namespace BibliotecaC_.Models
{
    public class Endereco
    {
        public int Id { get; set; }
        public string? Logradouro { get; set; }
        [Display(Name = "Número")]
        public int Numero { get; set; }
        public string? Complemento { get; set; }
        public string? Bairro { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
        [Display(Name = "CEP")]
        public string? Cep { get; set; }
        // Relacionamentos
        [Display(Name = "Nome do Usuário")]
        public int UsuarioId { get; set; }
        public Usuarios? Usuario { get; set; }
    }
}
