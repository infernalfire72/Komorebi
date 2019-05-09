using System.IO;

namespace Komorebi.Packets
{
    public class PacketReader : BinaryReader
    {
        public PacketReader(Stream input) : base(input) { }

        public override string ReadString()
        {
            return ReadByte() == 0x00 ? null : base.ReadString();
        }
    }
}
