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
        /// 县
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
                    list.Add(AreasTree);
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
   
}
