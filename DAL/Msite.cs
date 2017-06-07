using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace DAL
{
    public class Msite
    {
        /// <summary>
        /// 根据传入的AreasID获取此AreasID下的Msite（测站信息）
        /// </summary>
        /// <param name="AreasId"></param>
        /// <returns></returns>
        public List<Model.Msite> GetMsiteByAreasId(int AreasId)
        {
            List<Model.Msite> Msites = new List<Model.Msite>(); 
            string str = "select * from Msite where AreasID=" + AreasId;
            
            DataTable dt = SqlHelper.ExecuteDataTable(str, CommandType.Text, null);
            foreach (DataRow dr in dt.Rows)
            {
                Model.Msite m = new Model.Msite();
                m.MsiteID = Convert.ToInt32(dr["MsiteID"]);
                m.MsiteName = dr["MsiteName"].ToString();
                m.AreasID = Convert.ToInt32(dr["AreasID"]);
                m.MsiteTable = dr["MsiteTable"].ToString();
                Msites.Add(m);
            }
            return Msites;
        }

        /// <summary>
        /// 根据传入的测站数据库名，比如RW1  RW2之类，获得整个测站表有多少了监控记录，已备分页
        /// </summary>
        /// <param name="TableName"></param>
        /// <returns></returns>

        public int TotalQuntitySite(string TableName)
        {
            string str1 = "select COUNT(*) from " + TableName;
            // SqlParameter[] pms = { new SqlParameter("@TableName",TableName)} ;
            return Convert.ToInt32(SqlHelper.ExecuteScalar(str1, CommandType.Text, null));

        }
        /// <summary>
        /// 传入测站数据表，页面分页大小，页面值获得分页的测站数据
        /// </summary>
        /// <returns></returns>
        public List<Model.ViewMode.SiteDataList> showAll(int pagesize, int pageindex)
        {
            //string str = "SELECT TOP " + pagesize.ToString() + " * FROM(select TourRouteName,TourImg,TourRouteID,TourTypeID,TourRouteSpecial,TourRouteSetoutCity,TourDestination,TourPrice,TourChildrenPrice,ROW_NUMBER() over (order by TourRouteID asc) as Row_number from TourRoute) A WHERE Row_number  >" + pagesize.ToString() + "*(" + pageindex.ToString() + ")";
            string str ="SELECT TOP "+ pagesize.ToString()+" * FROM(select[DateTime],[PriWatersupplyT],[PriWatersupplyP],[PriWaterBackT],[PriWaterBackP],[SecWatersupplyT],[SecWatersupplyP],[SecWaterBackT],[SecWaterBackP],[TankWaterlevel], ROW_NUMBER() over(order by DateTime desc) as Row_number from RW1 )A WHERE Row_number > "+pagesize.ToString() + " * (" + pageindex.ToString() + ")";
            List<Model.ViewMode.SiteDataList> siteDataList= new List<Model.ViewMode.SiteDataList>();
            DataTable dt = SqlHelper.ExecuteDataTable(str, CommandType.Text, null);
            foreach (DataRow dr in dt.Rows)
            {
                Model.ViewMode.SiteDataList  MT = new Model.ViewMode.SiteDataList();
                MT.DateTime = Convert.ToDateTime(dr["DateTime"]).ToString("");
                MT.PriWaterBackP = string.Format("{0:N2}",dr["PriWatersupplyT"].ToString());
                MT.PriWatersupplyP = string.Format("{0:N2}", dr["PriWatersupplyP"].ToString());
                MT.PriWaterBackT = string.Format("{0:N2}", dr["PriWaterBackT"].ToString());
                MT.PriWaterBackP = string.Format("{0:N2}", dr["PriWaterBackP"].ToString());
                MT.SecWatersupplyT = string.Format("{0:N2}", dr["SecWatersupplyT"].ToString());
                MT.SecWatersupplyP = string.Format("{0:N2}", dr["SecWatersupplyP"].ToString());
                MT.SecWaterBackT = string.Format("{0:N2}", dr["SecWaterBackT"].ToString());
                MT.SecWaterBackP = string.Format("{0:N2}", dr["SecWaterBackP"].ToString());
                MT.TankWaterlevel = string.Format("{0:N2}", dr["TankWaterlevel"].ToString());
                //MT.TourType = new Dal_TourType().GetTourTYpeById(Convert.ToInt32(dr["TourTypeID"])); //这里直接调用角色类中的方法：根据角色ID获得该角色类的对象，因为数据库中存放的是角色类表的主键(外键)
                siteDataList.Add(MT);
            }
            return siteDataList;
        }
    }


}
