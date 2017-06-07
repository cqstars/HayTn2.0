using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LitJson;
namespace WebUI.ashx
{
    /// <summary>
    /// GetTreeProvince 的摘要说明
    /// </summary>
    public class GetTreeProvince : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write(JsonMapper.ToJson(new { Province = new BLL.TreeProvince().GetTree() }));
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