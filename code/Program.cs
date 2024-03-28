using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMPio
{
    class Program
    {
        static void Main(string[] args)
        {
            Map map = new Map();
            //map.Parse("..\\..\\..\\meta\\vrdemw.wmp");
            map.Parse("..\\..\\..\\meta\\vrdemw_old.wmp");
            //map.Export("..\\..\\..\\meta\\vrdemw_wmpio.wmp");
            map.Export("..\\..\\..\\meta\\vrdemw_old_wmpio.wmp");
        }
    }
}
