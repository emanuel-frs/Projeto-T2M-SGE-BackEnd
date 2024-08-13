using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Evento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("eventoId")]
        public int EventoId { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        [Column("nome")]
        public string Nome { get; set; }


        [Required(ErrorMessage = "Data é obrigatória")]
        [Column("data")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "Descrição é obrigatória")]
        [Column("descricao")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Capacidade é obrigatória")]
        [Column("capacidade")]
        public int Capacidade { get; set; }

        [ForeignKey("Endereco")]
        [Column("enderecoId")]
        public int EnderecoId { get; set; }

        public Evento(){ }

        public Evento(int id, string nome, DateTime data, string descricao, int capacidade, int enderecoId)
        {
            EventoId =id;
            Nome =nome;
            Data =data;
            Descricao =descricao;
            Capacidade =capacidade;
            EnderecoId =enderecoId;
        }
    }
}
