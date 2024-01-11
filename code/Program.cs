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
            map.Parse("..\\..\\..\\meta\\vrdemw.wmp");
        }
    }
}
