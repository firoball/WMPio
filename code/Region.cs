using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMPio
{
    class Region : WMPObject
    {
        public string Name;
        public float FloorHeight;
        public float CeilingHeight;
        public bool HasHeights;

        public Region(string name, float floorHeight, float ceilingHeight, int index) : base(index)
        {
            Name = name;
            FloorHeight = floorHeight;
            CeilingHeight = ceilingHeight;
            HasHeights = true;
        }

        public Region(string name) : this(name, 0.0f, 0.0f, -1)
        {
            HasHeights = false;
        }
    }
}
