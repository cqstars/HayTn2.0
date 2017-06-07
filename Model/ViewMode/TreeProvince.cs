using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewMode
{
    public class TreeProvince 
    {
        public int ProvinceID
        {
            get; set;
        }
        public string ProvinceName
        {
            get; set;
        }

        public List<Model.ViewMode.TreeMsite> TreeMsite
        {
            get; set;
        }
       
    }
}
