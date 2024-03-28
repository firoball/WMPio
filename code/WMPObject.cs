using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMPio
{
    class WMPObject
    {
        public int Index;

        public WMPObject(int index)
        {
            Index = index;
        }

        public virtual string Format(string format)
        {
            //override me
            return string.Empty;
        }
    }
}
