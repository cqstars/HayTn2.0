using System;
/*======================================================================================
 * 程序员：彭涛
 * 时间：2015-11-25
 ======================================================================================*/
using System.Text;
using System.Web;
using System.Collections.Generic;
using LitJson;

namespace Common
{
    /// <summary>
    /// List转换到json
    /// </summary>
    public class ListToJison
    {
        /// <summary>
        /// 将list转换为json
        /// </summary>
        /// <typeparam name="T">一个list泛型需要的类</typeparam>
        /// <param name="list">list对象</param>
        /// <returns></returns>
        public static string GetJsonString<T>(List<T> list)
        {
            //string listJson = JsonMapper.ToJson(list);
            //return listJson;
           return new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(list);
            
        }
        
    }
}
