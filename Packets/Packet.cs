namespace Komorebi.Packets
{
    public class Packet : ISerializable
    {
        public PacketType Type;
        public byte[] Data;

        public Packet(PacketType t, byte[] data)
        {
            Type = t;
            Data = data;
        }

        public void ReadFromStream(PacketReader r)
        {
            Type = (PacketType)r.ReadInt16();
            r.ReadByte();
            int length = r.ReadInt32();
            Data = r.ReadBytes(length);
        }

        public override string ToString() => $"Type: {Type}, Data length: {Data?.Length ?? 0}";

        public void WriteToStream(PacketWriter w)
        {
            w.Write((short)Type);
            w.Write((byte)0);
            w.Write(Data.Length);
            w.Write(Data);
        }
    }
}
