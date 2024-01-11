using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMPio
{
    class Wall : WMPObject
    {
        public string Name;
        public Vertex Vertex1;
        public Vertex Vertex2;
        public Region Region1;
        public Region Region2;
        public float OffsetX;
        public float OffsetY;

        public Wall(string name, Vertex vertex1, Vertex vertex2, Region region1, Region region2, float offsetX, float offsetY, int index) : base(index)
        {
            Name = name;
            Vertex1 = vertex1;
            Vertex2 = vertex2;
            Region1 = region1;
            Region2 = region2;
            OffsetX = offsetX;
            OffsetY = offsetY;
        }
    }
}
