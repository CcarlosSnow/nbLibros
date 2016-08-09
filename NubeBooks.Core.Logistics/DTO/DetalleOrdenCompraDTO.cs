using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NubeBooks.Core.Logistics.DTO
{
    public class DetalleOrdenCompraDTO
    {
        public int IdDetalleOrdenCompra { get; set; }
        public int IdOrdenCompra { get; set; }
        public int IdItem { get; set; }
        public string NombreItem { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnidad { get; set; }
        public decimal MontoTotal { get; set; }
        public decimal PorcentajeIGV { get; set; }
        public decimal IGV { get; set; }
        public string UnidadMedida { get; set; }
        public string ItemServicio { get; set; }
    }
}
