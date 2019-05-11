using Komorebi.Packets;

namespace Komorebi.Structures.Server
{
    public class Announce : ISerializable
    {
        public string Notification;

        public Announce() { }
        public Announce(string Notification) => this.Notification = Notification;
        public Announce(byte[] Data) => this.Populate(Data);

        public void ReadFromStream(PacketReader r)
        {
            Notification = r.ReadString();
        }

        public void WriteToStream(PacketWriter w)
        {
            w.Write(Notification);
        }
    }
}