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
    
    public partial class TipoMovimientoInv
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TipoMovimientoInv()
        {
            this.FormaMovimientoInv = new HashSet<FormaMovimientoInv>();
        }
    
        public int IdTipoMovimientoInv { get; set; }
        public string Nombre { get; set; }
        public bool Estado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FormaMovimientoInv> FormaMovimientoInv { get; set; }
    }
}
