﻿using System.Web.Mvc;

namespace NubeBooks.Areas.Proformas
{
    public class EmpresaAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Empresa";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Empresa_default",
                "Empresa/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}