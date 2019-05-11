namespace Komorebi.Packets
{
    public class Packet : ISerializable
    {
        public PacketType Type;
        public byte[] Data;

        public Packet(PacketType t)
        {
            this.Type = t;
            Data = new byte[0];
        }

        public Packet(PacketType t, byte[] data)
        {
            Type = t;
            Data = data;
        }

        public Packet(PacketType t, ISerializable Struct)
        {
            this.Type = t;
            this.Data = Struct.Serialize();
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
            w.Write(Data?.Length ?? 0);
            w.Write(Data);
        }
    }
}