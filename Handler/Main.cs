using Colorful;
using Komorebi.Objects;
using Komorebi.Packets;
using System.Drawing;

namespace Komorebi.Handler
{
    public class Main
    {
        public static void Handle(Player p, Packet packet)
        {
            switch(packet.Type)
            {
                default:
                    Console.WriteLineFormatted($"Got Unknown Packet {packet.Type} with Length {packet.Data?.Length ?? 0}", Color.Yellow);
                    break;
            }
        }
    }
}
