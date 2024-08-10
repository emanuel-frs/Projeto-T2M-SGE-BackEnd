using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Participante
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("eventoId")]
        public int LocalId { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        [Column("nome")]
        public string Nome { get; set; }

        [ForeignKey("Evento")]
        public int EventoId { get; set; }

        public Evento Evento { get; set; }

        public Participante() { }

        public Participante(int localId, string nome, int eventoId, Evento evento)
        {
            LocalId = localId;
            Nome = nome;
            EventoId = eventoId;
            Evento = evento;
        }
    }
}
