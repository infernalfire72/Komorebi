using System.Collections.Generic;

namespace Komorebi.Extensions
{
    public static class @List
    {
        public static void Concat<T>(this List<T> list, List<T> lta)
        {
            for(int i = 0; i < lta.Count; i++) list.Add(lta[i]);
        }
    }
}
