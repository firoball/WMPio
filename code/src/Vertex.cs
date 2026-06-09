using System.Globalization;

namespace WMPio
{
    public class Vertex : WmpObject
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

        public override string Format(string format)
        {
            return string.Format(CultureInfo.InvariantCulture, format, X, Y, Z, Index);
        }

    }
}
