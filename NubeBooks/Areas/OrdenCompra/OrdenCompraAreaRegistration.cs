using System.Web.Mvc;

namespace NubeBooks.Areas.OrdenCompra
{
    public class OrdenCompraAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "OrdenCompra";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "OrdenCompra_default",
                "OrdenCompra/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
