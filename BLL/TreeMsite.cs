using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class TreeMsite
    {
        DAL.Areas m = new DAL.Areas();
        //List<Model.ViewMode.TreeMsite> Tree = new List<Model.ViewMode.TreeMsite>();
        public List<Model.ViewMode.TreeMsite> GetTree()
        {

            return m.GetAreasTree();
        }
        /// <summary>
        /// 用litjson做一个返回为json对象，数组形式的数据，同时数组是Model.ViewMode.TreeMsite类
        /// </summary>
        /// <returns></returns>
        public object GetJsonTree()
        {
           return new { info = m.GetAreasTree() };
          
        }
        public List<Model.Areas> GetTreeMsite()
        {

            return m.GetAreasByProvinceId(1);
        }
    }
}
