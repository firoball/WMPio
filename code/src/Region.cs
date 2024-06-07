using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMPio
{
    public class Region : WMPObject
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

        public Region(string name, int index) : this(name, 0.0f, 0.0f, index)
        {
            //floor and ceil hgt must be initialized from script (values unknown by wmp)
            //region name is all CAPS and should be updated to script representation
            HasHeights = false;
        }

        public override string Format(string format)
        {
            return string.Format(CultureInfo.InvariantCulture, format, Name, FloorHeight, CeilingHeight, Index);
        }

    }
}
