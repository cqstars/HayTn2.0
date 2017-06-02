using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LitJson;

namespace WebUI.ashx
{
    /// <summary>
    /// GetTreeMsite 的摘要说明
    /// </summary>
    public class GetTreeMsite : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            BLL.TreeMsite Tree = new BLL.TreeMsite();
 //           JsonData jd = new JsonData();
 //           jd["result"] = 1;
 //           jd["user"] = new JsonData();//**新添加一层关系时，需要再次 new** JsonData（）
 //           jd["user"]["name"] = "zhang";
 //           jd["user"]["password"] = 123456;
 //           jd["user"] = new JsonData();
 //           jd["user"]["name"] = "李四";
 //           jd["user"]["password"] = 123;
 //           string jsonData = JsonMapper.ToJson(jd); 
 //context.Response.Write(jsonData);
            //context.Response.Write(JsonMapper.ToJson(Tree.GetTree()));
           
            context.Response.Write(JsonMapper.ToJson(Tree.GetJsonTree()));
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