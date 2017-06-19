using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.ashx.Areas
{
    /// <summary>
    /// DeleteAreas 的摘要说明
    /// </summary>
    public class DeleteAreas : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write(new BLL.Areas().DeleteAreasByID(Convert.ToInt32(context.Request["AreaSID"])));
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