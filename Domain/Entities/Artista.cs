using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Artista
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("eventoId")]
        public int ArtistaId { get; set; }

        [Required(ErrorMessage = "Nome obrigatório")]
        [Column("nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Email obrigatório")]
        [RegularExpression(@"^[a-zA-Z0-9+&-]+(?:\.[a-zA-Z0-9_+&-]+)*@(?:[a-zA-Z0-9-]+\.)+[a-zA-Z]{2,7}$", ErrorMessage = "Email inválido")]
        [Column("email")]
        public string Email { get; set; }

        public Artista() { }

        public Artista(int artistaId, string nome, string email)
        {
            ArtistaId = artistaId;
            Nome = nome;
            Email = email;
        }
    }
}
