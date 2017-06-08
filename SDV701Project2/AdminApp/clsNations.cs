using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminApp
{
    class clsNations
    {
        private static List<clsNation> _NationList = new List<clsNation>();

        public static List<clsNation> NationList
        {
            get{return _NationList;}
            set{_NationList = value;}
        }
    }
}
