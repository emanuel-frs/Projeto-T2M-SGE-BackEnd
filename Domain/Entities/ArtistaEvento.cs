using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class ArtistaEvento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("artistaEventoId")]
        public int ArtistaEventoId { get; set; }

        [Required]
        [ForeignKey("Evento")]
        [Column("eventoId")]
        public int EventoId { get; set; }

        [Required]
        [ForeignKey("Artista")]
        [Column("artistaId")]
        public int ArtistaId { get; set; }

        [Column("dataRegistro")]
        public DateTime DataRegistro { get; set; }

        public ArtistaEvento() { }

        public ArtistaEvento(int eventoId, int participanteId, DateTime dataRegistro)
        {
            EventoId = eventoId;
            ArtistaId = participanteId;
            DataRegistro = dataRegistro;
        }
    }
}
