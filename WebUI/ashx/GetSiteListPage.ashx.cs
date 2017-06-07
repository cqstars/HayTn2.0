using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LitJson;
namespace WebUI.ashx
{
    /// <summary>
    /// GetSiteListPage 的摘要说明
    /// </summary>
    public class GetSiteListPage : IHttpHandler
    {
        #region 无刷新分页
        public string BindSource(int pagesize, int page)
        {
            BLL.GetSiteData b = new BLL.GetSiteData();
            return (JsonMapper.ToJson(b.ShowALL(pagesize, page)));
        }
        #endregion
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            String str = string.Empty;

            if (context.Request["pageIndex"] != null && context.Request["pageIndex"].ToString().Length > 0)
            {
                int pageIndex;   //具体的页面数
                int.TryParse(context.Request["pageIndex"], out pageIndex);
                if (context.Request["pageSize"] != null && context.Request["pageSize"].ToString().Length > 0)
                {
                    //页面显示条数   
                    int size = Convert.ToInt32(context.Request["pageSize"]);
                    string data = BindSource(size, pageIndex);
                    context.Response.Write(data);
                    context.Response.End();
                }
            }

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