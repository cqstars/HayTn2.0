using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class Province
    {
        public int AddProvince(Model.Province NewProvince)
        {
            
            int ok=new DAL.Province().AddProvince(NewProvince);
            return 200;
        }
        /// <summary>
        /// 根据省ID删除 省
        /// </summary>
        /// <param name="ProvinceID"></param>
        /// <returns></returns>
        public int DeleteProinceByID(int ProvinceID)
        {
            return new DAL.Province().DeleteProinceByID(ProvinceID);
        }
    }
}
