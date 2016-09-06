using NubeBooks.Core.Logistics.DTO;
using NubeBooks.Core.BL;
using NubeBooks.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NubeBooks.Core.Logistics.BL
{
    public class OrdenCompraBL : Base
    {
        public List<OrdenCompraDTO> getOrdenesCompraEnEmpresa(int idEmpresa)
        {
            using (var context = getContext())
            {
                var result = context.OrdenCompra.Where(x => x.IdEmpresa == idEmpresa).Select(x => new OrdenCompraDTO
                {
                    IdOrdenCompra = x.IdOrdenCompra,
                    CodigoOrdenCompra = x.CodigoOrdenCompra,
                    Fecha = x.Fecha,
                    IdEmpresa = x.IdEmpresa,
                    IdProveedor = x.IdProveedor,
                    IdContacto = x.IdContacto,
                    IdMoneda = x.IdMoneda,
                    //MontoTipoCambio = x.MontoTipoCambio,
                    Consideraciones = x.Consideraciones,
                    AprobadoPor = x.AprobadoPor,
                    IncluirFirma = x.IncluirFirma,
                    Comentario = x.Comentario
                }).OrderByDescending(x => x.Fecha).ToList();

                if (idEmpresa > 0)
                {
                    foreach (var pro in result)
                    {
                        pro.Proveedor = new EntidadResponsableBL().getEntidadResponsableEnEmpresa_Only(pro.IdEmpresa, pro.IdProveedor);
                        pro.Empresa = new EmpresaBL().getEmpresa(pro.IdEmpresa);
                        if (pro.IdContacto > 0)
                        { pro.Contacto = new ContactoBL().getContacto((int)pro.IdContacto); }
                    }
                }

                return result;
            }
        }

        public OrdenCompraDTO getOrdenCompraId(Int32 idOrdenCompra)
        {
            using (var context = getContext())
            {
                var result = context.OrdenCompra.Where(x => x.IdOrdenCompra == idOrdenCompra).Select(x => new OrdenCompraDTO
                {
                    IdOrdenCompra = x.IdOrdenCompra,
                    CodigoOrdenCompra = x.CodigoOrdenCompra,
                    Fecha = x.Fecha,
                    IdEmpresa = x.IdEmpresa,
                    IdContacto = x.IdContacto,
                    IdProveedor = x.IdProveedor,
                    IdMoneda = x.IdMoneda,
                    //MontoTipoCambio = x.MontoTipoCambio,
                    Consideraciones = x.Consideraciones,
                    AprobadoPor = x.AprobadoPor,
                    IncluirFirma = x.IncluirFirma,
                    Comentario = x.Comentario

                }).SingleOrDefault();

                result.Proveedor = new EntidadResponsableBL().getEntidadResponsableEnEmpresa_Only(result.IdEmpresa, result.IdProveedor);
                result.Empresa = new EmpresaBL().getEmpresa(result.IdEmpresa);
                //result.Contacto = new ContactoBL().getContacto(result.IdContacto);
                if (result.IdContacto > 0)
                { result.Contacto = new ContactoBL().getContacto((int)result.IdContacto); }
                result.DetalleOrdenCompra = getDetalleOrdenCompraPorId(result.IdOrdenCompra);
                return result;
            }
        }

        public List<DetalleOrdenCompraDTO> getDetalleOrdenCompraPorId(int idOrdenCompra)
        {
            using (var context = getContext())
            {
                var items = context.DetalleOrdenCompra.Where(x => x.IdOrdenCompra == idOrdenCompra && x.ItemServicio == "0502").Select(x => new DetalleOrdenCompraDTO
                {
                    IdOrdenCompra = x.IdOrdenCompra,
                    IdItem = x.IdItem,
                    Cantidad = x.Cantidad,
                    PrecioUnidad = x.PrecioUnidad,
                    UnidadMedida = x.UnidadMedida,
                    MontoTotal = x.MontoTotal,
                    //NombreItem = context.Item.FirstOrDefault(i => i.IdItem == x.IdItem).Nombre,
                    NombreItem = x.Item.Codigo + " - " + x.Item.Nombre,
                    IGV = x.Igv,
                    PorcentajeIGV = x.PorcentajeIgv,
                    ItemServicio = x.ItemServicio
                }).ToList();

                var servicios = context.DetalleOrdenCompra.Where(x => x.IdOrdenCompra == idOrdenCompra && x.ItemServicio == "0501").Select(x => new DetalleOrdenCompraDTO
                {
                    IdOrdenCompra = x.IdOrdenCompra,
                    IdItem = x.IdItem,
                    Cantidad = x.Cantidad,
                    PrecioUnidad = x.PrecioUnidad,
                    UnidadMedida = x.UnidadMedida,
                    MontoTotal = x.MontoTotal,
                    NombreItem = context.Servicio.Where(y => y.IdServicio == x.IdItem).Select(y => y.Codigo + " - " + y.Nombre).FirstOrDefault().ToString(),
                    IGV = x.Igv,
                    PorcentajeIGV = x.PorcentajeIgv,
                    ItemServicio = x.ItemServicio
                }).ToList();

                var result = items.Concat(servicios);

                return result.ToList();
            }
        }

        public bool SaveOrdenCompra(OrdenCompraDTO OrdenCompra)
        {
            bool result = false;
            using (var context = getContext())
            {
                try
                {
                    OrdenCompra nuevo = new OrdenCompra();
                    if (OrdenCompra.IdOrdenCompra != 0)
                    {
                        nuevo = context.OrdenCompra.Where(c => c.IdOrdenCompra == OrdenCompra.IdOrdenCompra).SingleOrDefault();
                    }
                    else { nuevo.Fecha = DateTime.Now; }
                    nuevo.IdOrdenCompra = OrdenCompra.IdOrdenCompra;
                    if (OrdenCompra.CodigoOrdenCompra == null || OrdenCompra.CodigoOrdenCompra == "") { nuevo.CodigoOrdenCompra = CodigoOrdenCompra(OrdenCompra.IdEmpresa); }
                    nuevo.Fecha = OrdenCompra.Fecha;
                    nuevo.IdEmpresa = OrdenCompra.IdEmpresa;
                    nuevo.IdContacto = OrdenCompra.IdContacto == 0 ? null : OrdenCompra.IdContacto;
                    nuevo.IdProveedor = OrdenCompra.IdProveedor;
                    nuevo.IdMoneda = OrdenCompra.IdMoneda;
                    //nuevo.MontoTipoCambio = OrdenCompra.MontoTipoCambio;
                    nuevo.Consideraciones = OrdenCompra.Consideraciones;
                    nuevo.Comentario = OrdenCompra.Comentario;
                    nuevo.AprobadoPor = OrdenCompra.AprobadoPor;
                    nuevo.IncluirFirma = OrdenCompra.IncluirFirma;
                    if (nuevo.IdOrdenCompra == 0)
                    {
                        context.OrdenCompra.Add(nuevo);
                    }

                    context.SaveChanges();

                    Int32 IdOrdenCompra = nuevo.IdOrdenCompra;

                    DeleteDetalleItem(IdOrdenCompra);


                    foreach (var detalle in OrdenCompra.DetalleOrdenCompra)
                    {
                        DetalleOrdenCompra deta = new DetalleOrdenCompra();
                        deta.IdOrdenCompra = IdOrdenCompra;
                        deta.IdItem = detalle.IdItem;
                        deta.Cantidad = detalle.Cantidad;
                        deta.PrecioUnidad = detalle.PrecioUnidad;
                        deta.UnidadMedida = detalle.UnidadMedida;
                        deta.MontoTotal = detalle.MontoTotal;
                        deta.PorcentajeIgv = detalle.PorcentajeIGV;
                        deta.Igv = detalle.IGV;
                        deta.ItemServicio = detalle.ItemServicio;
                        context.DetalleOrdenCompra.Add(deta);
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

        public bool DeleteDetalleItem(Int32 idOrdenCompra)
        {
            using (var context = getContext())
            {
                try
                {
                    var row = context.DetalleOrdenCompra.Where(x => x.IdOrdenCompra == idOrdenCompra);
                    context.DetalleOrdenCompra.RemoveRange(row);
                    context.SaveChanges();
                    return true;

                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public List<OrdenCompraDTO> getOrdenCompraExportarEnEmpresa(int idEmpresa)
        {
            using (var context = getContext())
            {
                var result = context.OrdenCompra.Where(x => x.IdEmpresa == idEmpresa).Select(x => new OrdenCompraDTO
                {
                    IdOrdenCompra = x.IdOrdenCompra,
                    CodigoOrdenCompra = x.CodigoOrdenCompra,
                    Fecha = x.Fecha,
                    IdEmpresa = x.IdEmpresa,
                    IdContacto = x.IdContacto,
                    IdProveedor = x.IdProveedor,
                    IdMoneda = x.IdMoneda,
                    Consideraciones = x.Consideraciones,
                    AprobadoPor = x.AprobadoPor,
                    IncluirFirma = x.IncluirFirma,
                    Comentario = x.Comentario,
                    DetalleOrdenCompra = x.DetalleOrdenCompra.Select(r => new DetalleOrdenCompraDTO
                    {
                        IdDetalleOrdenCompra = r.IdDetalleOrdenCompra,
                        IdItem = r.IdItem,
                        Cantidad = r.Cantidad,
                        PrecioUnidad = r.PrecioUnidad,
                        MontoTotal = r.MontoTotal,
                        PorcentajeIGV = r.PorcentajeIgv,
                        IGV = r.Igv,
                        UnidadMedida = r.UnidadMedida,
                        ItemServicio = r.ItemServicio
                    }).ToList()
                }).OrderByDescending(x => x.CodigoOrdenCompra).ToList();

                if (idEmpresa > 0)
                {
                    foreach (var pro in result)
                    {
                        pro.Proveedor = new EntidadResponsableBL().getEntidadResponsableEnEmpresa_Only(pro.IdEmpresa, pro.IdProveedor);
                        pro.Empresa = new EmpresaBL().getEmpresa(pro.IdEmpresa);
                        if (pro.IdContacto > 0)
                        { pro.Contacto = new ContactoBL().getContacto((int)pro.IdContacto); }
                    }
                }

                return result;
            }
        }

        private string CodigoOrdenCompra(Int32 IdEmpresa)
        {
            string result = string.Empty;
            using (var context = getContext())
            {
                try
                {
                    var OrdenCompra = context.OrdenCompra.Where(c => c.IdEmpresa == IdEmpresa);
                    var maximo = Convert.ToInt32(OrdenCompra.Max(c => c.CodigoOrdenCompra)) + 1;
                    result = maximo.ToString("0000000");
                }
                catch (Exception)
                {
                    result = "0000001";
                }
            }
            return result;
        }
    }
}
