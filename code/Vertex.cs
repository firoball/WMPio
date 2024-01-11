using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMPio
{
    class Vertex : WMPObject
    {
        public float X;
        public float Y;
        public float Z;

        public Vertex(float x, float y, float z, int index) : base(index)
        {
            X = x;
            Y = y;
            Z = z;
            Index = index;
        }
    }
}
