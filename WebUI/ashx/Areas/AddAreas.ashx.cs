using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.ashx.Areas
{
    /// <summary>
    /// AddAreas 的摘要说明
    /// </summary>
    public class AddAreas : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            Model.Areas NewAreas = new Model.Areas();
            NewAreas.AreasName = context.Request["value"].ToString();
            NewAreas.ProvinceID = Convert.ToInt32(context.Request["pk"]);
            int ok = new BLL.Areas().AddAreas(NewAreas);
            if (ok == 1)
            {context.Response.Write(200);
            }
            else
            { context.Response.Write(400); }
            
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