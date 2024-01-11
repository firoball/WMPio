using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMPio
{
    class Thing : WMPObject
    {
        public string Name;
        public float X;
        public float Y;
        public float Angle;
        public Region Region;

        public Thing(string name, float x, float y, float angle, Region region, int index) : base(index)
        {
            Name = name;
            X = x;
            Y = y;
            Angle = angle;
            Region = region;
        }
    }
}
