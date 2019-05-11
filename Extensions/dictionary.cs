using System;
using System.Collections.Generic;
using System.Linq;

namespace Komorebi.Extensions
{
    public static class @Dictionary
    {
        public static List<TValue> FindAll<TKey, TValue>(this Dictionary<TKey, TValue> Dict, Func<TValue, bool> x)
        {
            /*List<TValue> l = new List<TValue>();
            foreach (KeyValuePair<TKey, TValue> e in Dict)
            {
                if (e.Value == null) continue;
            }

            return l;*/
            return Dict.Values.Where(x).ToList();
        }
    }
}
