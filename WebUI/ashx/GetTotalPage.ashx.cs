using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.ashx
{
    /// <summary>
    /// GetTotalPage 的摘要说明
    /// </summary>
    public class GetTotalPage : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write(new BLL.GetSiteData().GetTotalPage().ToString());
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