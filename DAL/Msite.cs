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
    }
}
