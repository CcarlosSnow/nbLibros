
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
    
public partial class Proforma
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Proforma()
    {

        this.DetalleProforma = new HashSet<DetalleProforma>();

    }


    public int IdProforma { get; set; }

    public string CodigoProforma { get; set; }

    public int IdEmpresa { get; set; }

    public int IdContacto { get; set; }

    public int IdEntidadResponsable { get; set; }

    public Nullable<int> IdMoneda { get; set; }

    public Nullable<int> IdCuentaBancaria { get; set; }

    public int ValidezOferta { get; set; }

    public string MetodoPago { get; set; }

    public Nullable<System.DateTime> FechaEntrega { get; set; }

    public Nullable<System.DateTime> FechaProforma { get; set; }

    public string LugarEntrega { get; set; }

    public Nullable<System.DateTime> FechaFacturacion { get; set; }

    public Nullable<System.DateTime> FechaCobranza { get; set; }

    public Nullable<System.DateTime> FechaRegistro { get; set; }

    public string ComentarioProforma { get; set; }

    public string ComentarioAdiccional { get; set; }

    public string OrdenCompra { get; set; }

    public Nullable<int> Estado { get; set; }



    public virtual Contacto Contacto { get; set; }

    public virtual CuentaBancaria CuentaBancaria { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<DetalleProforma> DetalleProforma { get; set; }

    public virtual Empresa Empresa { get; set; }

    public virtual EntidadResponsable EntidadResponsable { get; set; }

}

}
