using System.Globalization;

namespace WMPio
{
    public class PlayerStart : WmpObject
    {
        public float X;
        public float Y;
        public float Angle;
        public Region Region;

        public PlayerStart(float x, float y, float angle, Region region, int index) : base(index)
        {
            X = x;
            Y = y;
            Angle = angle;
            Region = region;
        }

        public override string Format(string format)
        {
            return string.Format(CultureInfo.InvariantCulture, format, X, Y, Angle, Region.Index, Index);
        }

    }
}
