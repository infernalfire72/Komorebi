using System.Collections.Generic;
using System.IO;

namespace Komorebi.Packets
{
    public interface ISerializable
    {
        void ReadFromStream(PacketReader r);
        void WriteToStream(PacketWriter w);
    }

    public static class Ext
    {
        public static void Populate(this ISerializable s, byte[] data)
        {
            using (MemoryStream stream = new MemoryStream(data))
            using (PacketReader r = new PacketReader(stream))
                s.ReadFromStream(r);
        }

        public static byte[] Serialize(this ISerializable s)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                using (PacketWriter w = new PacketWriter(stream))
                    s.WriteToStream(w);
                return stream.ToArray();
            }
        }

        public static byte[] Serialize(this IEnumerable<ISerializable> list)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                using (PacketWriter w = new PacketWriter(stream))
                    foreach(ISerializable s in list) s.WriteToStream(w);
                return stream.ToArray();
            }
        }

        public static void Serialize(this Stream s, Packet p)
        {
            byte[] PacketData = p.Serialize();
            s.Write(PacketData, 0, PacketData.Length);
        }

        public static void Serialize(this Stream s, IEnumerable<Packet> list)
        {
            byte[] PacketData = list.Serialize();
            s.Write(PacketData, 0, PacketData.Length);
        }
    }
}
