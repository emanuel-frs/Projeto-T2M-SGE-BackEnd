using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Projection
{
    public interface IArtistaEventoProjection
    {
        string NomeEvento { get; }
        string NomeArtista { get; }
        string Endereco { get; }
        DateTime DataEvento { get; }
    }
}
