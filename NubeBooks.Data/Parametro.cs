
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
    
public partial class Parametro
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Parametro()
    {

        this.Empresa = new HashSet<Empresa>();

        this.Empresa1 = new HashSet<Empresa>();

        this.Empresa2 = new HashSet<Empresa>();

    }


    public string IdParametro { get; set; }

    public string Nombre { get; set; }

    public string Descripcion { get; set; }

    public string Valor { get; set; }

    public System.DateTime FechaCreacion { get; set; }

    public string UsuarioCreacion { get; set; }

    public Nullable<System.DateTime> FechaModificacion { get; set; }

    public string UsuarioModificacion { get; set; }

    public bool Eliminado { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Empresa> Empresa { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Empresa> Empresa1 { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Empresa> Empresa2 { get; set; }

}

}
