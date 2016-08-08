using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NubeBooks.Core.DTO;

namespace NubeBooks.Core.BL
{
    public class ParametroBL : Base
    {
        public List<ParametroDTO> ListByCodigo(string Codigo)
        {
            using (var context = getContext())
            {
                var result = context.Parametro.Where(x => x.IdParametro.Substring(0,2) == Codigo && x.IdParametro != Codigo + "00" && x.Eliminado == false).Select(x => new ParametroDTO
                {
                    IdParametro = x.IdParametro,
                    Nombre = x.Nombre,
                    Descripcion = x.Descripcion,
                    Valor = x.Valor,
                    FechaCreacion = x.FechaCreacion,
                    UsuarioCreacion = x.UsuarioCreacion,
                    FechaModificacion = x.FechaModificacion,
                    UsuarioModificacion = x.UsuarioModificacion
                }).OrderBy(x => x.Nombre).ToList();
                return result;
            }
        }
    }
}
