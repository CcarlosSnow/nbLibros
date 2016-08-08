using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;

namespace NubeBooks
{
    /// <summary>
    /// Summary description for ImageHandler
    /// </summary>
    public class ImageHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string f = context.Request.QueryString.Get("f");
            Image image = Image.FromFile(f);
            context.Response.Clear();
            context.Response.ClearHeaders();
            image.Save(context.Response.OutputStream, ImageFormat.Jpeg);
            context.Response.ContentType = "image/jpeg";
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}