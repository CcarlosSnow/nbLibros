using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NubeBooks.Core.DTO
{
    public class ParametroDTO
    {
        public string IdParametro { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Valor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public bool Eliminado { get; set; }
    }
}
