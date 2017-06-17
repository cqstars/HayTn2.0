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
    }
}
