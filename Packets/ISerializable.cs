namespace Komorebi.Packets
{
    public interface ISerializable
    {
        void ReadFromStream(PacketReader r);
        void WriteToStream(PacketWriter w);
    }
}
