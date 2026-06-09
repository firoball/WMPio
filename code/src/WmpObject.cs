
namespace WMPio
{
    public class WmpObject
    {
        public int Index;

        public WmpObject(int index)
        {
            Index = index;
        }

        public virtual string Format(string format)
        {
            //override me
            return string.Empty;
        }
    }
}
