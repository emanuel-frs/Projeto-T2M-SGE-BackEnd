using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ViaCep;

namespace Domain.ValueObject
{
    public class Local
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("eventoId")]
        public int LocalId { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        [Column("nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Estado é obrigatório")]
        [Column("estado")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "Cidade é obrigatório")]
        [Column("cidade")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Bairro é obrigatório")]
        [Column("bairro")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Bairro é obrigatório")]
        [Column("cep")]
        public string Cep { get; set; }

        public Local() { }

        public Local(int localId, string nome, string estado, string cidade, string bairro, string cep)
        {
            LocalId = localId;
            Nome = nome;
            Estado = estado;
            Cidade = cidade;
            Bairro = bairro;
            Cep = cep;
        }
    }
}
