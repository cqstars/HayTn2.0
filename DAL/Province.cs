using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class Province
    {
        public List<Model.ViewMode.TreeProvince> GetTreeProvince()
        {
            List<Model.ViewMode.TreeProvince> TreeProvince = new List<Model.ViewMode.TreeProvince>();
            string str = "select * from Province";
            DataTable dt = SqlHelper.ExecuteDataTable(str, CommandType.Text, null);
            foreach (DataRow dr in dt.Rows)
            {
                Model.ViewMode.TreeProvince Province = new Model.ViewMode.TreeProvince();
                Province.ProvinceID = Convert.ToInt32(dr["ProvinceID"]);
                Province.ProvinceName = dr["ProvinceName"].ToString();
                Province.TreeMsite = new DAL.Areas().GetAreasTree(Province.ProvinceID);
                TreeProvince.Add(Province);
            }
            return TreeProvince;
        }
        /// <summary>
        /// 增加一个省行政区域
        /// </summary>
        /// <returns></returns>
        public int AddProvince(Model.Province Province)
        {
            string str = "insert into Province (ProvinceName) values(@ProvinceName)";
            SqlParameter[] pms = new SqlParameter[] {
                 new SqlParameter("@ProvinceName",Province.ProvinceName)
            };
            return SqlHelper.ExecuteNonQuery(str, System.Data.CommandType.Text, pms);

        }
    }
}
