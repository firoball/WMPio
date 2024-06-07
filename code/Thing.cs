﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMPio
{
    public class Thing : WMPObject
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

        public override string Format(string format)
        {
            return string.Format(CultureInfo.InvariantCulture, format, Name, X, Y, Angle, Region.Index, Index);
        }

    }
}
