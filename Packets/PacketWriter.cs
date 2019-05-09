using System.IO;

namespace Komorebi.Packets
{
    public class PacketWriter : BinaryWriter
    {
        public PacketWriter(Stream output) : base(output)
        {
        }

        public override void Write(string value)
        {
            if (value == null)
            {
                Write((byte)0x00);
            } else if (value.Length == 0)
            {
                Write((byte)0x0b);
                Write((byte)0x00);
            } else
            {
                Write((byte)0x0b);
                base.Write(value);
            }
        }
    }
}
