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
    
    public partial class CuentaBancaria
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CuentaBancaria()
        {
            this.Movimiento = new HashSet<Movimiento>();
            this.Proforma = new HashSet<Proforma>();
        }
    
        public int IdCuentaBancaria { get; set; }
        public string NombreCuenta { get; set; }
        public System.DateTime FechaConciliacion { get; set; }
        public decimal SaldoDisponible { get; set; }
        public decimal SaldoBancario { get; set; }
        public bool Estado { get; set; }
        public Nullable<int> IdMoneda { get; set; }
        public int IdEmpresa { get; set; }
        public Nullable<int> IdTipoCuenta { get; set; }
    
        public virtual Empresa Empresa { get; set; }
        public virtual Moneda Moneda { get; set; }
        public virtual TipoCuenta TipoCuenta { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Movimiento> Movimiento { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Proforma> Proforma { get; set; }
    }
}
