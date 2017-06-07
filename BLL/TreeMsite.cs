using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    #region 按照省、区、测站生成的树
    public class TreeProvince
    {
        public List<Model.ViewMode.TreeProvince> GetTree()
        {

            return new DAL.Province().GetTreeProvince();
        }
    } 
    #endregion
    #region 左边省级--县级---测站树生成
    public class TreeMsite
    {
        DAL.Areas m = new DAL.Areas();
        //List<Model.ViewMode.TreeMsite> Tree = new List<Model.ViewMode.TreeMsite>();
        public List<Model.ViewMode.TreeMsite> GetTree()
        {

            return m.GetAreasTree(1);
        }
        /// <summary>
        /// 用litjson做一个返回为json对象，数组形式的数据，同时数组是Model.ViewMode.TreeMsite类
        /// </summary>
        /// <returns></returns>
        public object GetJsonTree()
        {
            return new { info = m.GetAreasTree(1) };

        }
        public List<Model.Areas> GetTreeMsite()
        {

            return m.GetAreasByProvinceId(1);
        }
    }
    #endregion
    #region 分页显示测站监控数据

    public class GetSiteData
    {
        DAL.Msite MsiteData = new DAL.Msite();
        /// <summary>
        /// 获得测站监控数据Model.ViewMode.SiteDataList
        /// </summary>
        /// <returns></returns>
        public List<Model.ViewMode.SiteDataList> ShowALL(int pagesize, int pageindex)
        {
            return MsiteData.showAll(pagesize, pageindex);
        }
        /// <summary>
        /// 获得测站监控数据的总页数
        /// </summary>
        /// <returns></returns>
        public int GetTotalPage()
        {
            return MsiteData.TotalQuntitySite("RW1");
        }
    }
    #endregion

}
