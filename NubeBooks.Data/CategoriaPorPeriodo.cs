
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
    
public partial class CategoriaPorPeriodo
{

    public int IdCategoria { get; set; }

    public int IdPeriodo { get; set; }

    public decimal Monto { get; set; }



    public virtual Categoria Categoria { get; set; }

    public virtual Periodo Periodo { get; set; }

}

}
