using NubeBooks.Core.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NubeBooks.Core.Logistics.DTO
{
    [Serializable]
    public class ProformaDTO
    {
        public int IdProforma { get; set; }
        [Display(Name = "Número de Proforma")]
        public string CodigoProforma { get; set; }
        public int IdEmpresa { get; set; }
        public int IdContacto { get; set; }
        public int IdEntidadResponsable { get; set; }
        public int? IdMoneda { get; set; }
        public int? IdCuentaBancaria { get; set; }
        public int ValidezOferta { get; set; }
        public string MetodoPago { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? FechaEntrega { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? FechaProforma { get; set; }

        public string LugarEntrega { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? FechaFacturacion { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? FechaCobranza { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? FechaRegistro { get; set; }

        public string ComentarioProforma { get; set; }
        public string ComentarioAdiccional { get; set; }

        public string OrdenCompra { get; set; }

        [Display(Name = "Estado")]
        public int? Estado { get; set; }
        public List<DetalleProformaDTO> DetalleProforma { get; set; }
        public EmpresaDTO Empresa { get; set; }
        public ContactoDTO Contacto { get; set; }
        public EntidadResponsableDTO EntidadResponsable { get; set; }

        public List<CuentaBancariaDTO> CuentaBancaria { get; set; }

        public string NombreCuentaBancaria { get; set; }
    }
}
