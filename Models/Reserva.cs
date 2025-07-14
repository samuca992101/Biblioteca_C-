using System.ComponentModel.DataAnnotations;

namespace BibliotecaC_.Models
{
    public class Reserva
    {
        public int Id { get; set; }
        [Display(Name = "Data da reserva")]
        public DateTime DataReserva { get; set; }
        [Display(Name = "Data da conclusão da reserva")]
        public DateTime? DataConclusaoReserva { get; set; }
        [Display(Name="Título do livro")]
        public int LivroId { get; set; }
        public Livro? Livro { get; set; }
        [Display(Name = "Nome do usuário")]
        public int UsuarioId { get; set; }
        public Usuarios? Usuario { get; set; }

    }
}
