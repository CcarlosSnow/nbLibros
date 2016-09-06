using NubeBooks.Core.BL;
using NubeBooks.Core.DTO;
using NubeBooks.Core.Logistics.BL;
using NubeBooks.Core.Logistics.DTO;
using NubeBooks.Models;
using NubeBooks.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Web.Mvc;
using System.Globalization;
using System.Data;

namespace NubeBooks.Areas.OrdenCompra.Controllers
{
    public class OrdenCompraController : Controller
    {
        #region Variables y constructor
        private bool currentUser()
        {
            if (System.Web.HttpContext.Current.Session != null && System.Web.HttpContext.Current.Session["User"] != null) { return true; }
            else { return false; }
        }
        protected Navbar navbar { get; set; }
        private UsuarioDTO getCurrentUser()
        {
            if (this.currentUser())
            {
                return (UsuarioDTO)System.Web.HttpContext.Current.Session["User"];
            }
            return null;
        }
        private void MenuNavBarSelected(int num, int? subNum = null)
        {
            navbar.clearAll();
            navbar.lstOptions[num].cadena = "active";

            if (subNum != null)
            {
                //Limpiar Activos del ultimo elemento
                navbar.lstOptions[num].lstOptions[subNum.GetValueOrDefault()].cadena = "active";
            }
            ViewBag.navbar = navbar;
        }
        private bool isSuperAdministrator()
        {
            if (getCurrentUser().IdRol == 1) return true;
            return false;
        }
        private bool isAdministrator()
        {
            if (getCurrentUser().IdRol <= 2) return true;
            return false;
        }
        private bool isUsuarioInterno()
        {
            if (getCurrentUser().IdRol == 3) return true;
            return false;
        }
        private bool isUsuarioExterno()
        {
            if (getCurrentUser().IdRol == 4) return true;
            return false;
        }
        public OrdenCompraController()
        {
            UsuarioDTO user = getCurrentUser();
            if (user != null)
            {
                this.navbar = new Navbar();
                ViewBag.currentUser = user;
                ViewBag.NombreEmpresa = user.nombreEmpresa;
                ViewBag.Title = "";

                ViewBag.EsAdmin = isAdministrator();
                ViewBag.EsSuperAdmin = isSuperAdministrator();
                ViewBag.EsUsuarioInterno = isUsuarioInterno();
                ViewBag.EsUsuarioExterno = isUsuarioExterno();
                ViewBag.IdRol = user.IdRol;

                EmpresaBL empBL = new EmpresaBL();
                ViewBag.Empresas = empBL.getEmpresasViewBag();
            }
            else { ViewBag.EsAdmin = false; ViewBag.EsSuperAdmin = false; }
            CultureInfo[] cultures = { new CultureInfo("es-PE") };
        }
        private void createResponseMessage(string status, string message = "", string status_field = "status", string message_field = "message")
        {
            TempData[status_field] = status;
            if (!String.IsNullOrWhiteSpace(message))
            {
                TempData[message_field] = message;
            }
        }

        #region reportes
        private static void PintarCabeceraTabla(GridView gridView)
        {
            var myTable = (Table)gridView.Controls[0];
            foreach (GridViewRow row in myTable.Rows)
            {
                if (row.Cells.Count >= 3)
                {
                    for (int i = 0; i < row.Cells.Count; i++)
                    {
                        row.Cells[i].Text = row.Cells[i].Text.ToUpper();
                        row.Cells[i].BackColor = System.Drawing.Color.FromArgb(189, 195, 199);
                        row.Cells[i].Font.Bold = true;
                    }
                    break;
                }
            }
        }

        private static void AddSuperHeader(GridView gridView, string text = null)
        {
            var myTable = (Table)gridView.Controls[0];
            var myNewRow = new GridViewRow(0, -1, DataControlRowType.Header, DataControlRowState.Normal);
            myNewRow.Cells.Add(MakeCell(text, gridView.HeaderRow.Cells.Count));//gridView.Columns.Count
            myNewRow.Cells[0].Style.Add("background-color", "#cbcfd6");
            myTable.Rows.AddAt(0, myNewRow);
        }

        private static void AddWhiteHeader(GridView gridView, int index, string text = null)
        {
            var myTable = (Table)gridView.Controls[0];
            var myNewRow = new GridViewRow(0, -1, DataControlRowType.Header, DataControlRowState.Normal);
            myNewRow.Cells.Add(MakeCell(text, gridView.HeaderRow.Cells.Count));//gridView.Columns.Count
            myNewRow.Cells[0].Style.Add("background-color", "#ffffff");
            myNewRow.Cells[0].HorizontalAlign = HorizontalAlign.Left;
            myTable.Rows.AddAt(index, myNewRow);
        }

        private static TableHeaderCell MakeCell(string text = null, int span = 1)
        {
            return new TableHeaderCell() { ColumnSpan = span, Text = text ?? string.Empty, CssClass = "table-header" };
        }
        #endregion

        #endregion
        public ActionResult Index()
        {
            if (!this.currentUser()) { return RedirectToAction("Ingresar", "Admin", new { Area = string.Empty }); }
            ViewBag.Title += "Órdenes de Compra";
            MenuNavBarSelected(13);

            UsuarioDTO currentUser = getCurrentUser();
            var lista = new OrdenCompraBL().getOrdenesCompraEnEmpresa(currentUser.IdEmpresa);

            return View(lista);
        }

        public ActionResult Nuevo(int? id)
        {
            if (!this.currentUser()) { return RedirectToAction("Ingresar", "Admin", new { Area = string.Empty }); }
            ViewBag.Title += "Órdenes de Compra";
            MenuNavBarSelected(13);

            UsuarioDTO user = getCurrentUser();

            EntidadResponsableBL entBL = new EntidadResponsableBL();
            ViewBag.lstProveedores = entBL.getEntidadesResponsablesActivasPorTipoEnEmpresa(user.IdEmpresa, 2);
            EmpresaBL empBL = new EmpresaBL();
            ViewBag.lstMonedas = empBL.getListaMonedasAll();
            MovimientoInvBL movItmBL = new MovimientoInvBL();
            ViewBag.lstItems = movItmBL.getItemsServicios_Proforma(user.IdEmpresa);
            ViewBag.lstContactos = new List<ContactoDTO>();
            UsuariosBL oUsuariosBL = new UsuariosBL();
            ViewBag.lstUsuarios = oUsuariosBL.getAllUsuariosActivosEnEmpresa(user.IdEmpresa);

            OrdenCompraDTO obj;
            if (id != null && id > 0)
            {
                obj = new OrdenCompraBL().getOrdenCompraId((int)id);
                return View(obj);
            }
            obj = new OrdenCompraDTO();
            obj.IdEmpresa = user.IdEmpresa;
            obj.Fecha = DateTime.Now;
            obj.DetalleOrdenCompra = new List<DetalleOrdenCompraDTO>();

            return View(obj);
        }

        [HttpPost]
        public JsonResult GetContactos(int idEntidad)
        {
            EntidadResponsableBL objBL = new EntidadResponsableBL();
            var lista = objBL.getContactosActivos_EnEntidadResponsable(idEntidad);
            return Json(new { lista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddOrdenCompra(OrdenCompraDTO dto)
        {
            if (!this.currentUser()) { return RedirectToAction("Ingresar", "Admin", new { Area = string.Empty }); }
            if (getCurrentUser().IdRol == 4) { return RedirectToAction("Index", "Proformas"); }
            try
            {
                if (dto != null)
                {
                    dto.DetalleOrdenCompra = (List<DetalleOrdenCompraDTO>)TempData["lstDetalleOrdenCompra"] ?? new List<DetalleOrdenCompraDTO>();
                }

                OrdenCompraBL objBL = new OrdenCompraBL();

                if (dto.IdOrdenCompra == 0)
                {
                    if (objBL.SaveOrdenCompra(dto))
                    {
                        createResponseMessage(CONSTANTES.SUCCESS);
                        return RedirectToAction("Index", "OrdenCompra");
                    }
                    else
                    {
                        createResponseMessage(CONSTANTES.ERROR, CONSTANTES.ERROR_INSERT_MESSAGE);
                    }
                }
                else if (dto.IdOrdenCompra > 0)
                {
                    if (objBL.SaveOrdenCompra(dto))
                    {
                        createResponseMessage(CONSTANTES.SUCCESS);
                        return RedirectToAction("Index", "OrdenCompra");
                    }
                    else
                    {
                        createResponseMessage(CONSTANTES.ERROR, CONSTANTES.ERROR_UPDATE_MESSAGE);
                    }
                }
            }
            catch (Exception e)
            {
                if (dto.IdOrdenCompra != 0)
                    createResponseMessage(CONSTANTES.ERROR, CONSTANTES.ERROR_UPDATE_MESSAGE);
                else createResponseMessage(CONSTANTES.ERROR, CONSTANTES.ERROR_INSERT_MESSAGE);
            }
            TempData["OrdenCompra"] = dto;
            return RedirectToAction("Nuevo", "OrdenCompra", new { id = dto.IdOrdenCompra });
        }

        [HttpPost]
        public ActionResult PasslstItems(List<DetalleOrdenCompraDTO> lista)
        {
            TempData["lstDetalleOrdenCompra"] = lista;
            return Json(new { success = true, mensaje = "Si funciona" }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ExportarOrdenCompra()
        {
            EmpresaDTO empresa = (new EmpresaBL()).getEmpresa(getCurrentUser().IdEmpresa);

            OrdenCompraBL objBL = new OrdenCompraBL();
            List<OrdenCompraDTO> lista = objBL.getOrdenCompraExportarEnEmpresa(empresa.IdEmpresa);

            System.Data.DataTable dt = new System.Data.DataTable();
            dt.Clear();

            dt.Columns.Add("Codigo de Orden de Compra", typeof(String));
            dt.Columns.Add("Fecha");
            dt.Columns.Add("Proveedor", typeof(String));
            dt.Columns.Add("Contacto", typeof(String));
            dt.Columns.Add("Consideraciones", typeof(String));
            dt.Columns.Add("Comentario", typeof(String));

            foreach (var item in lista)
            {
                System.Data.DataRow row = dt.NewRow();
                row["Codigo de Orden de Compra"] = item.CodigoOrdenCompra;
                row["Fecha"] = item.Fecha;
                row["Proveedor"] = item.Proveedor.Nombre;
                row["Contacto"] = item.Contacto == null ? "" : item.Contacto.Nombre;
                row["Consideraciones"] = item.Consideraciones;
                row["Comentario"] = item.Comentario;
                dt.Rows.Add(row);
            }

            GenerarOrdenCompraPdf(dt, "Detalle de Ordenes de Compra", "Detalle_de_Ordenes_Compra", empresa, Response);
            createResponseMessage(CONSTANTES.SUCCESS, CONSTANTES.SUCCESS_FILE);
            return RedirectToAction("Index", "OrdenCompra"); ;
        }
        private static void GenerarOrdenCompraPdf(DataTable dt, string titulo, string nombreDoc, EmpresaDTO objEmpresa, HttpResponseBase Response)
        {
            GridView gv = new GridView();

            gv.DataSource = dt;
            gv.AllowPaging = false;
            gv.DataBind();

            if (dt.Rows.Count > 0)
            {
                PintarCabeceraTabla(gv);
                //PintarIntercaladoCategorias(gv);

                AddSuperHeader(gv, titulo + " - Empresa:" + objEmpresa.Nombre);
                AddWhiteHeader(gv, 1, "RUC: " + objEmpresa.RUC);

                Response.ClearContent();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment; filename=" + nombreDoc + "_" + objEmpresa.Nombre + "_" + DateTime.Now.ToString("dd-MM-yyyy") + ".xls");
                Response.ContentType = "application/ms-excel";
                Response.Charset = "";

                System.IO.StringWriter sw = new System.IO.StringWriter();
                HtmlTextWriter htw = new HtmlTextWriter(sw);
                gv.RenderControl(htw);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
                htw.Close();
                sw.Close();
            }
        }
    }
}