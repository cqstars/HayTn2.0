using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class Areas
    {
        /// <summary>
        /// 根据传入的ProvinceID获取此ProvinceID下的Areas（区县信息）
        /// </summary>
        /// <param name="AreasId"></param>
        /// <returns></returns>
        public List<Model.Areas> GetAreasByProvinceId(int ProvinceID)
        {
            List<Model.Areas> Areases = new List<Model.Areas>();
            string str = "select * from Areas where ProvinceID=" + ProvinceID;

            DataTable dt = SqlHelper.ExecuteDataTable(str, CommandType.Text, null);
            foreach (DataRow dr in dt.Rows)
            {
                Model.Areas Area = new Model.Areas();
                Area.AreaSID = Convert.ToInt32(dr["AreaSID"]);
                Area.AreasName = dr["AreasName"].ToString();
                Areases.Add(Area);
            }
            return Areases;
        }

        /// <summary>
        ///为县级Areas和测站Msite提供树形数据
        /// </summary>
        /// <returns></returns>
        public List<Model.ViewMode.TreeMsite> GetAreasTree(int ProvinceID)
        {
            string str = "select * from Areas where ProvinceID=" + ProvinceID;
            DataTable dt = SqlHelper.ExecuteDataTable(str, CommandType.Text, null);
            List<Model.ViewMode.TreeMsite> Tree = new List<Model.ViewMode.TreeMsite>();
            foreach (DataRow dw in dt.Rows)
            {
                Model.ViewMode.TreeMsite AreasTree = new Model.ViewMode.TreeMsite();
                AreasTree.AreaSID = Convert.ToInt32(dw["AreaSID"]);
                AreasTree.AreasName= dw["AreasName"].ToString();
                AreasTree.Mistes = new DAL.Msite().GetMsiteByAreasId(AreasTree.AreaSID);
                Tree.Add(AreasTree);
            }
            return Tree;
        }
        /// <summary>
        /// 传入Areas对象，插入Areas表
        /// </summary>
        /// <param name="NewAreas"></param>
        /// <returns></returns>
        public int AddAreas(Model.Areas NewAreas)
        {
            string str = "insert into Areas(AreasName,ProvinceID) values(@AreasName,@ProvinceID)";
            SqlParameter[] pms = new SqlParameter[] {
                 new SqlParameter("@AreasName",NewAreas.AreasName),
                 new SqlParameter("@ProvinceID",NewAreas.ProvinceID)
            };
            return SqlHelper.ExecuteNonQuery(str, System.Data.CommandType.Text, pms);
        }
        /// <summary>
        /// 根据传入的AreaSID，删除Areas,但先查一下Msite表下面有没有测站，有不能删，返回400，删掉成功，返回200
        /// </summary>
        /// <param name="AreaSID"></param>
        /// <returns></returns>
        public int DeleteAreasByID(int AreaSID)
        {
            if (new Msite().GetMsiteByAreasId(AreaSID).Count != 0)
            {
                return 400;
            }
            else
            {
                string str = "delete from Areas where AreaSID=@AreaSID";
                SqlParameter[] pms = new SqlParameter[] {
                 new SqlParameter("@AreaSID",AreaSID)};
                int ok = SqlHelper.ExecuteNonQuery(str, System.Data.CommandType.Text, pms);
                if (ok == 1)
                {
                    return 200;
                }
                else
                { return 400; }

            }
        }

    }
}
