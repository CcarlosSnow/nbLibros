
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
    
public partial class Responsable
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Responsable()
    {

        this.Comprobante = new HashSet<Comprobante>();

        this.EntidadResponsable = new HashSet<EntidadResponsable>();

        this.Proyecto = new HashSet<Proyecto>();

    }


    public int IdResponsable { get; set; }

    public string Nombre { get; set; }

    public string Descripcion { get; set; }

    public bool Estado { get; set; }

    public int IdEmpresa { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Comprobante> Comprobante { get; set; }

    public virtual Empresa Empresa { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<EntidadResponsable> EntidadResponsable { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Proyecto> Proyecto { get; set; }

}

}
