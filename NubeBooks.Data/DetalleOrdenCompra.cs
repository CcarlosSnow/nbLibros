//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NubeBooks.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class DetalleOrdenCompra
    {
        public int IdDetalleOrdenCompra { get; set; }
        public int IdOrdenCompra { get; set; }
        public int IdItem { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnidad { get; set; }
        public decimal MontoTotal { get; set; }
        public decimal PorcentajeIgv { get; set; }
        public decimal Igv { get; set; }
        public string UnidadMedida { get; set; }
        public string ItemServicio { get; set; }
    
        public virtual Item Item { get; set; }
        public virtual OrdenCompra OrdenCompra { get; set; }
    }
}
