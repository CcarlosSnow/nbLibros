using NubeBooks.Core.DTO;
using NubeBooks.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace NubeBooks.Core.Logistics.DTO
{
    public class OrdenCompraDTO
    {
        public int IdOrdenCompra { get; set; }
        public string CodigoOrdenCompra { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Fecha { get; set; }
        public int IdEmpresa { get; set; }
        public int IdProveedor { get; set; }
        public int? IdContacto { get; set; }
        public int IdMoneda { get; set; }
        public decimal MontoTipoCambio { get; set; }
        public string Consideraciones { get; set; }
        public int AprobadoPor { get; set; }
        public bool IncluirFirma { get; set; }
        public string Comentario { get; set; }
        public List<DetalleOrdenCompraDTO> DetalleOrdenCompra { get; set; }
        public EmpresaDTO Empresa { get; set; }
        public MonedaDTO Moneda { get; set; }
        public ContactoDTO Contacto { get; set; }
        public EntidadResponsableDTO Proveedor { get; set; }
    }
}
