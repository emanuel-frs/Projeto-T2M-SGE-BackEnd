using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Domain.ValueObject;

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
        public string Name { get; set; }

        [Required(ErrorMessage = "Data é obrigatória")]
        [Column("data")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "Descrição é obrigatória")]
        [Column("descricao")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Capacidade é obrigatória")]
        [Column("capacidade")]
        public int Capacidade { get; set; }

        [ForeignKey("Local")]
        public int LocalId { get; set; }

        public Local Local { get; set; }

        public Evento(){ }

        public Evento(int id, string nome, DateTime data, string descricao, int capacidade, int localId)
        {
            EventoId =id;
            Name =nome;
            Data =data;
            Descricao =descricao;
            Capacidade =capacidade;
            LocalId =localId;
        }
    }
}
