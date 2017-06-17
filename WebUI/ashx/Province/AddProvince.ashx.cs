using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.ashx.Province
{
    /// <summary>
    /// AddProvince 的摘要说明
    /// </summary>
    public class AddProvince : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string ProvinceName = context.Request["value"].ToString();
            Model.Province p = new Model.Province();
            p.ProvinceName = ProvinceName;
            int ok = new BLL.Province().AddProvince(p);
            context.Response.ContentType = "text/plain";
            context.Response.Write(ok);
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