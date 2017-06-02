using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
    public class TreeMsite
    {
        /// <summary>
        /// 遍历旅游一级分类及下面的二级分类
        /// </summary>
        /// <returns></returns>
        public List<Model.ViewMode.TreeMsite> GetMsiteList()
        {
            List<Model.ViewMode.TreeMsite> list = new List<Model.ViewMode.TreeMsite>();
            string str = "select * from Areas";
            SqlDataReader dr = SqlHelper.ExecuteReader(str, System.Data.CommandType.Text, null);

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Model.ViewMode.TreeMsite AreasTree = new Model.ViewMode.TreeMsite();
                    AreasTree.AreaSID= dr.GetInt32(0);
                    AreasTree.AreasName = dr.GetString(1);
                    //TourRouteClassName  TourRouteClassID
                    
                    list.Add(AreasTree);
                    //Model.Msite site = new Model.Msite();
                    //site.MsiteID = dr.GetInt32(0);
                    //site.MsiteName = dr.GetString(1);
                    //site.AreasID = dr.GetInt32(2);
                    //site.MsiteTable = dr.GetString(3);
                    //MyTourClass.TourType = new Dal_TourType().GetTourType(dr.GetInt32(0));
                    //MyTourClass.TourRouteClassName = dr.GetString(1);

                    //list.Add(MyTourClass);
                    list.Add(AreasTree);
                }
                return list;
            }
            else
            {
                list = null;
                return list;
            }

        }

    }
    /// <summary>
    /// 根据传入的AreasID获取Msite实体对象集合
    /// </summary>
    /// <returns></returns>
    
}
