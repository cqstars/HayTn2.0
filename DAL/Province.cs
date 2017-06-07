using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
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
    }
}
