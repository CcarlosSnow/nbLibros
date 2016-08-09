//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
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
            this.DetalleProforma = new HashSet<DetalleProforma>();
            this.MovimientoInv = new HashSet<MovimientoInv>();
            this.DetalleOrdenCompra = new HashSet<DetalleOrdenCompra>();
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
        public virtual ICollection<DetalleProforma> DetalleProforma { get; set; }
        public virtual Moneda Moneda { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MovimientoInv> MovimientoInv { get; set; }
        public virtual Empresa Empresa { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleOrdenCompra> DetalleOrdenCompra { get; set; }
    }
}
