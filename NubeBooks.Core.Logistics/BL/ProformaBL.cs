﻿using NubeBooks.Core.Logistics.DTO;
using NubeBooks.Core.BL;
using NubeBooks.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NubeBooks.Core.Logistics.BL
{
    public class ProformaBL : Base
    {
        public List<ProformaDTO> getProformasEnEmpresa(int idEmpresa)
        {
            using (var context = getContext())
            {
                var result = context.Proforma.Where(x => x.IdEmpresa == idEmpresa).Select(x => new ProformaDTO
                {
                    IdProforma = x.IdProforma,
                    CodigoProforma = x.CodigoProforma,
                    IdEmpresa = x.IdEmpresa,
                    IdContacto = x.IdContacto,
                    IdEntidadResponsable = x.IdEntidadResponsable,
                    IdMoneda = x.IdMoneda,
                    IdCuentaBancaria = x.IdCuentaBancaria,
                    ValidezOferta = x.ValidezOferta,
                    MetodoPago = x.MetodoPago,
                    FechaEntrega = x.FechaEntrega,
                    FechaProforma = x.FechaProforma,
                    LugarEntrega = x.LugarEntrega,
                    FechaFacturacion = x.FechaFacturacion,
                    FechaCobranza = x.FechaCobranza,
                    FechaRegistro = x.FechaRegistro,
                    ComentarioAdiccional = x.ComentarioAdiccional,
                    ComentarioProforma = x.ComentarioProforma,
                    OrdenCompra = x.OrdenCompra,
                    IdEstado = x.Estado,
                    IdUsuarioRegistro = x.UsuarioRegistro,
                    IdUsuarioModifica = x.UsuarioModifica,
                    FechaModifica = x.FechaModifica
                }).OrderByDescending(x => x.CodigoProforma).ToList();

                if (idEmpresa > 0)
                {
                    foreach (var pro in result)
                    {
                        pro.EntidadResponsable = new EntidadResponsableBL().getEntidadResponsableEnEmpresa_Only(pro.IdEmpresa, pro.IdEntidadResponsable);
                        pro.Empresa = new EmpresaBL().getEmpresa(pro.IdEmpresa);
                        if (pro.IdContacto > 0)
                        { pro.Contacto = new ContactoBL().getContacto((int)pro.IdContacto); }
                        if (pro.IdUsuarioRegistro > 0)
                        { pro.UsuarioRegistro = new UsuariosBL().getUsuario((int)pro.IdUsuarioRegistro); }
                        pro.Estado = new ParametroBL().ListByIdParametro(pro.IdEstado);
                        pro.MotivoRechazo = new ParametroBL().ListByIdParametro(pro.IdMotivoRechazo);
                    }
                }

                return result;
            }
        }
        public List<ProformaDTO> getProformasExportarEnEmpresa(int idEmpresa)
        {
            using (var context = getContext())
            {
                var result = context.Proforma.Where(x => x.IdEmpresa == idEmpresa).Select(x => new ProformaDTO
                {
                    IdProforma = x.IdProforma,
                    CodigoProforma = x.CodigoProforma,
                    IdEmpresa = x.IdEmpresa,
                    IdContacto = x.IdContacto,
                    IdEntidadResponsable = x.IdEntidadResponsable,
                    IdMoneda = x.IdMoneda,
                    IdCuentaBancaria = x.IdCuentaBancaria,
                    ValidezOferta = x.ValidezOferta,
                    MetodoPago = x.MetodoPago,
                    FechaEntrega = x.FechaEntrega,
                    FechaProforma = x.FechaProforma,
                    LugarEntrega = x.LugarEntrega,
                    FechaFacturacion = x.FechaFacturacion,
                    FechaCobranza = x.FechaCobranza,
                    FechaRegistro = x.FechaRegistro,
                    ComentarioAdiccional = x.ComentarioAdiccional,
                    ComentarioProforma = x.ComentarioProforma,
                    OrdenCompra = x.OrdenCompra,
                    IdEstado = x.Estado,
                    NombreCuentaBancaria = x.CuentaBancaria.NombreCuenta,
                    DetalleProforma = x.DetalleProforma.Select(r => new DetalleProformaDTO
                    {
                        IdProforma = r.IdProforma,
                        IdItem = r.IdItem,
                        Cantidad = r.Cantidad,
                        PrecioUnidad = r.PrecioUnidad,
                        MontoTotal = r.MontoTotal,
                        TipoCambio = r.TipoCambio,
                        NombreItem = r.Item.Codigo + r.Item.Nombre,
                        Descuento = r.Descuento,
                        Igv = r.Igv,
                        PorcentajeIgv = r.PorcentajeIgv
                    }).ToList()
                }).OrderByDescending(x => x.CodigoProforma).ToList();

                if (idEmpresa > 0)
                {
                    foreach (var pro in result)
                    {
                        pro.EntidadResponsable = new EntidadResponsableBL().getEntidadResponsableEnEmpresa_Only(pro.IdEmpresa, pro.IdEntidadResponsable);
                        pro.Empresa = new EmpresaBL().getEmpresa(pro.IdEmpresa);
                        if (pro.IdContacto > 0)
                        { pro.Contacto = new ContactoBL().getContacto((int)pro.IdContacto); }
                        if (pro.IdUsuarioRegistro > 0)
                        { pro.UsuarioRegistro = new UsuariosBL().getUsuario((int)pro.IdUsuarioRegistro); }
                        pro.Estado = new ParametroBL().ListByIdParametro(pro.IdEstado);
                        pro.MotivoRechazo = new ParametroBL().ListByIdParametro(pro.IdMotivoRechazo);
                    }
                }

                return result;
            }
        }
        public List<ProformaDTO> getProformaEnEmpresa(int idEmpresa)
        {
            using (var context = getContext())
            {
                var result = context.Proforma.Where(x => x.IdEmpresa == idEmpresa).Select(x => new ProformaDTO
                {
                    IdProforma = x.IdProforma,
                    CodigoProforma = x.CodigoProforma,
                    IdEmpresa = x.IdEmpresa,
                    IdContacto = x.IdContacto,
                    IdEntidadResponsable = x.IdEntidadResponsable,
                    IdMoneda = x.IdMoneda,
                    IdCuentaBancaria = x.IdCuentaBancaria,
                    ValidezOferta = x.ValidezOferta,
                    MetodoPago = x.MetodoPago,
                    FechaEntrega = x.FechaEntrega,
                    FechaProforma = x.FechaProforma,
                    LugarEntrega = x.LugarEntrega,
                    FechaFacturacion = x.FechaFacturacion,
                    FechaCobranza = x.FechaCobranza,
                    FechaRegistro = x.FechaRegistro,
                    ComentarioAdiccional = x.ComentarioAdiccional,
                    ComentarioProforma = x.ComentarioProforma,
                    OrdenCompra = x.OrdenCompra,
                    IdEstado = x.Estado
                }).OrderByDescending(x => x.FechaRegistro).ToList();

                foreach (var pro in result)
                {
                    pro.EntidadResponsable = new EntidadResponsableBL().getEntidadResponsableEnEmpresa_Only(pro.IdEmpresa, pro.IdEntidadResponsable);
                    pro.Empresa = new EmpresaBL().getEmpresa(pro.IdEmpresa);
                    if (pro.IdContacto > 0)
                    { pro.Contacto = new ContactoBL().getContacto((int)pro.IdContacto); }
                    if (pro.IdUsuarioRegistro > 0)
                    { pro.UsuarioRegistro = new UsuariosBL().getUsuario((int)pro.IdUsuarioRegistro); }
                    pro.Estado = new ParametroBL().ListByIdParametro(pro.IdEstado);
                    pro.MotivoRechazo = new ParametroBL().ListByIdParametro(pro.IdMotivoRechazo);
                }

                return result;
            }
        }
        public ProformaDTO getProformaId(Int32 idProforma)
        {
            using (var context = getContext())
            {
                var result = context.Proforma.Where(x => x.IdProforma == idProforma).Select(x => new ProformaDTO
                {
                    IdProforma = x.IdProforma,
                    CodigoProforma = x.CodigoProforma,
                    IdEmpresa = x.IdEmpresa,
                    IdContacto = x.IdContacto,
                    IdEntidadResponsable = x.IdEntidadResponsable,
                    IdMoneda = x.IdMoneda,
                    IdCuentaBancaria = x.IdCuentaBancaria,
                    ValidezOferta = x.ValidezOferta,
                    MetodoPago = x.MetodoPago,
                    FechaEntrega = x.FechaEntrega,
                    FechaProforma = x.FechaProforma,
                    LugarEntrega = x.LugarEntrega,
                    FechaFacturacion = x.FechaFacturacion,
                    FechaCobranza = x.FechaCobranza,
                    FechaRegistro = x.FechaRegistro,
                    ComentarioAdiccional = x.ComentarioAdiccional,
                    ComentarioProforma = x.ComentarioProforma,
                    OrdenCompra = x.OrdenCompra,
                    IdEstado = x.Estado
                }).SingleOrDefault();

                result.EntidadResponsable = new EntidadResponsableBL().getEntidadResponsableEnEmpresa_Only(result.IdEmpresa, result.IdEntidadResponsable);
                result.Empresa = new EmpresaBL().getEmpresa(result.IdEmpresa);
                //result.Contacto = new ContactoBL().getContacto(result.IdContacto);
                if (result.IdContacto > 0)
                { result.Contacto = new ContactoBL().getContacto((int)result.IdContacto); }
                result.DetalleProforma = getDetalleProformaPorId(result.IdProforma);
                result.CuentaBancaria = new CuentaBancariaBL().getCuentasBancariasActivasPorTipoEnEmpresa(result.IdEmpresa, 1);
                if (result.IdUsuarioRegistro > 0)
                { result.UsuarioRegistro = new UsuariosBL().getUsuario((int)result.IdUsuarioRegistro); }
                result.Estado = new ParametroBL().ListByIdParametro(result.IdEstado);
                result.MotivoRechazo = new ParametroBL().ListByIdParametro(result.IdMotivoRechazo);
                return result;
            }
        }
        public List<DetalleProformaDTO> getDetalleProformaPorId(int idProforma)
        {
            using (var context = getContext())
            {
                var items = context.DetalleProforma.Where(x => x.IdProforma == idProforma && x.ItemServicio == "0502").Select(x => new DetalleProformaDTO
                {
                    IdProforma = x.IdProforma,
                    IdItem = x.IdItem,
                    Cantidad = x.Cantidad,
                    PrecioUnidad = x.PrecioUnidad,
                    UnidadMedida = x.UnidadMedida,
                    MontoTotal = x.MontoTotal,
                    TipoCambio = x.TipoCambio,
                    //NombreItem = context.Item.FirstOrDefault(i => i.IdItem == x.IdItem).Nombre,
                    NombreItem = x.Item.Codigo + " - " + x.Item.Nombre,
                    Descuento = x.Descuento,
                    Igv = x.Igv,
                    PorcentajeIgv = x.PorcentajeIgv,
                    PorcentajeDescuento = x.PorcentajeDescuento,
                    ItemServicio = x.ItemServicio
                }).ToList();

                var servicios = context.DetalleProforma.Where(x => x.IdProforma == idProforma && x.ItemServicio == "0501").Select(x => new DetalleProformaDTO
                {
                    IdProforma = x.IdProforma,
                    IdItem = x.IdItem,
                    Cantidad = x.Cantidad,
                    PrecioUnidad = x.PrecioUnidad,
                    UnidadMedida = x.UnidadMedida,
                    MontoTotal = x.MontoTotal,
                    TipoCambio = x.TipoCambio,
                    NombreItem = context.Servicio.Where(y => y.IdServicio == x.IdItem).Select(y => y.Codigo + " - " + y.Nombre).FirstOrDefault().ToString(),
                    Descuento = x.Descuento,
                    Igv = x.Igv,
                    PorcentajeIgv = x.PorcentajeIgv,
                    PorcentajeDescuento = x.PorcentajeDescuento,
                    ItemServicio = x.ItemServicio
                }).ToList();

                var result = items.Concat(servicios);

                return result.ToList();
            }
        }
        public bool SaveProforma(ProformaDTO proforma)
        {
            bool result = false;
            using (var context = getContext())
            {
                try
                {
                    Proforma nuevo = new Proforma();
                    if (proforma.IdProforma != 0)
                    {
                        nuevo = context.Proforma.Where(c => c.IdProforma == proforma.IdProforma).SingleOrDefault();
                        nuevo.UsuarioModifica = proforma.IdUsuarioModifica;
                        nuevo.FechaModifica = DateTime.Now;
                    }
                    else
                    {
                        nuevo.FechaRegistro = DateTime.Now;
                        nuevo.UsuarioRegistro = proforma.IdUsuarioRegistro;
                    }
                    nuevo.IdProforma = proforma.IdProforma;
                    if (proforma.CodigoProforma == null || proforma.CodigoProforma == "") { nuevo.CodigoProforma = CodigoProforma(proforma.IdEmpresa); }
                    //else { nuevo.CodigoProforma = proforma.CodigoProforma; }
                    nuevo.IdEmpresa = proforma.IdEmpresa;
                    nuevo.IdContacto = proforma.IdContacto;
                    nuevo.IdEntidadResponsable = proforma.IdEntidadResponsable;
                    nuevo.IdMoneda = proforma.IdMoneda;
                    nuevo.IdCuentaBancaria = proforma.IdCuentaBancaria;
                    nuevo.ValidezOferta = proforma.ValidezOferta;
                    nuevo.MetodoPago = proforma.MetodoPago;
                    nuevo.FechaEntrega = proforma.FechaEntrega;
                    DateTime Hora = DateTime.Now;
                    nuevo.FechaProforma = proforma.FechaProforma + new TimeSpan(Hora.Hour, Hora.Minute, Hora.Second); ;
                    nuevo.LugarEntrega = proforma.LugarEntrega;
                    nuevo.FechaFacturacion = proforma.FechaFacturacion;
                    nuevo.FechaCobranza = proforma.FechaCobranza;
                    nuevo.ComentarioAdiccional = proforma.ComentarioAdiccional;
                    nuevo.ComentarioProforma = proforma.ComentarioProforma;
                    nuevo.OrdenCompra = proforma.OrdenCompra;
                    nuevo.Estado = proforma.IdEstado;
                    nuevo.MotivoRechazo = proforma.IdMotivoRechazo;
                    if (nuevo.IdProforma == 0)
                    {
                        context.Proforma.Add(nuevo);
                    }

                    context.SaveChanges();

                    Int32 IdProforma = nuevo.IdProforma;

                    DeleteDetalleItem(IdProforma);


                    foreach (var detalle in proforma.DetalleProforma)
                    {
                        DetalleProforma deta = new DetalleProforma();
                        deta.IdProforma = IdProforma;
                        deta.IdItem = detalle.IdItem;
                        deta.Cantidad = detalle.Cantidad;
                        deta.PrecioUnidad = detalle.PrecioUnidad;
                        deta.UnidadMedida = detalle.UnidadMedida;
                        deta.Descuento = detalle.Descuento;
                        deta.MontoTotal = detalle.MontoTotal;
                        deta.TipoCambio = detalle.TipoCambio;
                        deta.PorcentajeIgv = detalle.PorcentajeIgv;
                        deta.Igv = detalle.Igv;
                        deta.PorcentajeDescuento = detalle.PorcentajeDescuento;
                        deta.ItemServicio = detalle.ItemServicio;
                        context.DetalleProforma.Add(deta);
                    }
                    context.SaveChanges();
                    result = true;
                }
                catch (Exception e)
                {
                    throw new ArgumentException(e.Message);
                }
            }
            return result;
        }
        private string CodigoProforma(Int32 IdEmpresa)
        {
            string result = string.Empty;
            using (var context = getContext())
            {
                try
                {
                    var proforma = context.Proforma.Where(c => c.IdEmpresa == IdEmpresa);
                    var maximo = Convert.ToInt32(proforma.Max(c => c.CodigoProforma)) + 1;
                    result = maximo.ToString("0000000");
                }
                catch (Exception)
                {
                    result = "0000001";
                }
            }
            return result;
        }
        public bool DeleteDetalleItem(Int32 idProforma)
        {
            using (var context = getContext())
            {
                try
                {
                    var row = context.DetalleProforma.Where(x => x.IdProforma == idProforma);
                    context.DetalleProforma.RemoveRange(row);
                    context.SaveChanges();
                    return true;

                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

    }
}
