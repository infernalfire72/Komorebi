using Komorebi.Packets;

namespace Komorebi.Structures.Server
{
    public class ProtocolNegtiation : ISerializable
    {
        public int Version;

        public ProtocolNegtiation() { }
        public ProtocolNegtiation(int Version) => this.Version = Version;
        public ProtocolNegtiation(byte[] Data) => this.Populate(Data);

        public void ReadFromStream(PacketReader r)
        {
            Version = r.ReadInt32();
        }

        public void WriteToStream(PacketWriter w)
        {
            w.Write(Version);
        }
    }
}
