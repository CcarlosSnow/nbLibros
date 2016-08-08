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
    
    public partial class EntidadResponsable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EntidadResponsable()
        {
            this.Comprobante = new HashSet<Comprobante>();
            this.Comprobante1 = new HashSet<Comprobante>();
            this.Contacto = new HashSet<Contacto>();
            this.Movimiento = new HashSet<Movimiento>();
            this.MovimientoInv = new HashSet<MovimientoInv>();
            this.Proforma = new HashSet<Proforma>();
            this.Proyecto = new HashSet<Proyecto>();
        }
    
        public int IdEntidadResponsable { get; set; }
        public Nullable<int> IdTipoIdentificacion { get; set; }
        public Nullable<int> IdTipoEntidad { get; set; }
        public Nullable<int> IdResponsable { get; set; }
        public string Nombre { get; set; }
        public bool Estado { get; set; }
        public Nullable<decimal> Detraccion { get; set; }
        public string Tipo { get; set; }
        public int IdEmpresa { get; set; }
        public string NroIdentificacion { get; set; }
        public string NombreComercial { get; set; }
        public string Direccion { get; set; }
        public string Banco { get; set; }
        public string CuentaSoles { get; set; }
        public string CuentaDolares { get; set; }
        public Nullable<int> Credito { get; set; }
        public Nullable<int> TipoPersona { get; set; }
        public string Telefono1 { get; set; }
        public string Telefono2 { get; set; }
        public string Email { get; set; }
        public string Comentario { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comprobante> Comprobante { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comprobante> Comprobante1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contacto> Contacto { get; set; }
        public virtual Responsable Responsable { get; set; }
        public virtual TipoEntidad TipoEntidad { get; set; }
        public virtual TipoIdentificacion TipoIdentificacion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Movimiento> Movimiento { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MovimientoInv> MovimientoInv { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Proforma> Proforma { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Proyecto> Proyecto { get; set; }
        public virtual Empresa Empresa { get; set; }
    }
}
