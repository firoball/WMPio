using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMPio
{
    class Way : WMPObject
    {
        public string Name { get; set; }
        public List<Point> Points { get; set; }

        public Way(string name, List<Point> points, int index) : base(index)
        {
            Name = name;
            Points = points;
        }
    }
}
