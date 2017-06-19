using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.ashx.Msite
{
    /// <summary>
    /// AddMsite 的摘要说明
    /// </summary>
    public class AddMsite : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            Model.Msite NewMsite = new Model.Msite();
            NewMsite.MsiteName = context.Request["value"].ToString();
            NewMsite.AreasID = Convert.ToInt32(context.Request["pk"]);
            context.Response.Write(new BLL.Msite().AddMsite(NewMsite));
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