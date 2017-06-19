using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Msite
    {
        public int AddMsite(Model.Msite NewMsite)
        {
            return new DAL.Msite().AddMsite(NewMsite);
        }
    }
}
