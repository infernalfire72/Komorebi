namespace Komorebi.Extensions
{
    public static class @int
    {
        public static bool Has(this int x, int y)
        {
            return ((x & y) > 1);
        }
    }
}
