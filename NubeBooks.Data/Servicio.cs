
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
    
public partial class Servicio
{

    public int IdServicio { get; set; }

    public int IdMoneda { get; set; }

    public string Nombre { get; set; }

    public string Codigo { get; set; }

    public string Descripcion { get; set; }

    public Nullable<decimal> Precio { get; set; }

    public bool Estado { get; set; }

    public int IdEmpresa { get; set; }



    public virtual Moneda Moneda { get; set; }

}

}
