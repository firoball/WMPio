using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMPio
{
    public class Way : WMPObject
    {
        public string Name { get; set; }
        public List<Point> Points { get; set; }

        public Way(string name, List<Point> points, int index) : base(index)
        {
            Name = name;
            Points = points;
        }

        public override string Format(string format)
        {
            string points = string.Join("\t", Points.Select(x => string.Format(CultureInfo.InvariantCulture, "{0:F3} {1:F3}", x.X, x.Y)));

            return string.Format(CultureInfo.InvariantCulture, format, Name, points, Index);
        }

    }
}
