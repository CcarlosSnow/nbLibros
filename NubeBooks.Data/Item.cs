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
    
    public partial class Item
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Item()
        {
            this.DetalleOrdenCompra = new HashSet<DetalleOrdenCompra>();
            this.DetalleProforma = new HashSet<DetalleProforma>();
            this.MovimientoInv = new HashSet<MovimientoInv>();
        }
    
        public int IdItem { get; set; }
        public int IdCategoriaItm { get; set; }
        public int IdMoneda { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public Nullable<decimal> Precio { get; set; }
        public string Descripcion { get; set; }
        public string UnidadMedida { get; set; }
        public bool Estado { get; set; }
        public int IdEmpresa { get; set; }
    
        public virtual CategoriaItm CategoriaItm { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleOrdenCompra> DetalleOrdenCompra { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleProforma> DetalleProforma { get; set; }
        public virtual Empresa Empresa { get; set; }
        public virtual Moneda Moneda { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MovimientoInv> MovimientoInv { get; set; }
    }
}
