using Komorebi.Objects;
using System.Collections.Generic;

namespace Komorebi
{
    public static class Global
    {
        public static Dictionary<string, Player> Players = new Dictionary<string, Player>();
        public static Dictionary<string, Channel> Channels = new Dictionary<string, Channel>();
    }
}
