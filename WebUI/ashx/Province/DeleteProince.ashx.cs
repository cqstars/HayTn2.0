using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.ashx.Province
{
    /// <summary>
    /// DeleteProince 的摘要说明
    /// </summary>
    public class DeleteProince : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            context.Response.Write(new BLL.Province().DeleteProinceByID(Convert.ToInt32(context.Request["ProvinceID"])));
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