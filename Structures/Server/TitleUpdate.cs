using Komorebi.Packets;

namespace Komorebi.Structures.Server
{
    public class TitleUpdate : ISerializable
    {
        public string Notification;

        public TitleUpdate() { }
        public TitleUpdate(string Notification) => this.Notification = Notification;
        public TitleUpdate(byte[] Data) => this.Populate(Data);

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
