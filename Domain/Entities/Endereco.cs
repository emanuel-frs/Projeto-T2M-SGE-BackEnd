using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Endereco
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("enderecoId")]
        public int EnderecoId { get; set; }

        [Required(ErrorMessage = "Rua é obrigatória")]
        [Column("rua")]
        public string Rua { get; set; }

        [Required(ErrorMessage = "Número é obrigatório")]
        [Column("numero")]
        public int Numero { get; set; }

        [Column("complemento")]
        public string Complemento { get; set; }

        [Required(ErrorMessage = "Bairro é obrigatório")]
        [Column("bairro")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Cidade é obrigatória")]
        [Column("cidade")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Estado é obrigatório")]
        [Column("estado")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "CEP é obrigatório")]
        [Column("cep")]
        [StringLength(8, ErrorMessage = "CEP deve ter exatamente 8 caracteres.")]
        public string CEP { get; set; }

        public Endereco() { }

        public Endereco(int id, string rua, int numero, string complemento, string bairro, string cidade, string estado, string cep)
        {
            EnderecoId = id;
            Rua = rua;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            CEP = cep;
        }
    }
}
