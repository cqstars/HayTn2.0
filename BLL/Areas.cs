using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Areas
    {
        public int AddAreas(Model.Areas NewAreas)
        {
            return new DAL.Areas().AddAreas(NewAreas);
        }
        public int DeleteAreasByID(int AreaSID)
        {
            return new DAL.Areas().DeleteAreasByID(AreaSID);
        }
    }
}
