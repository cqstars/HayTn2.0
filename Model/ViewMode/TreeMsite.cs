using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewMode
{
   public class TreeMsite
    {
        public int AreaSID
        {
            get; set;
        }

        public string AreasName
        {
            get; set;
        }
        public List<Msite> Mistes {
            get;set;
        }
    }
}
