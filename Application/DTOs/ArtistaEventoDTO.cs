using Domain.Projection;

public class ArtistaEventoDto : IArtistaEventoProjection
{
    public string NomeEvento { get; set; }
    public string NomeArtista { get; set; }
    public string Endereco { get; set; }
    public DateTime DataEvento { get; set; }
}
