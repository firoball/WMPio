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

        public Region(string name, float floorHeight, float ceilingHeight, int index) : base(index)
        {
            Name = name;
            FloorHeight = floorHeight;
            CeilingHeight = ceilingHeight;
        }
    }
}
