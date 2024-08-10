using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("userId")]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "Nome obrigatório")]
        [Column("nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Email obrigatório")]
        [RegularExpression(@"^[a-zA-Z0-9+&-]+(?:\.[a-zA-Z0-9_+&-]+)*@(?:[a-zA-Z0-9-]+\.)+[a-zA-Z]{2,7}$", ErrorMessage = "Email inválido")]
        [Column("email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha obrigatória")]
        [Column("senha")]
        public string Senha { get; set; }

        public Usuario() { }

        public Usuario(int usuarioId, string nome, string email, string senha)
        {
            UsuarioId = usuarioId;
            Nome = nome;
            Email = email;
            Senha = senha;
        }
    }
}
