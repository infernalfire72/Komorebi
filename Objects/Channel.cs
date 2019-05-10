using Komorebi.Packets;

namespace Komorebi.Objects
{
    public class Channel : ISerializable
    {
        public string Name, Topic;
        public short UserCount;

        public Channel() { }
        public Channel(byte[] data) => this.Populate(data);
        public Channel(string Name, string Topic, short Users)
        {
            this.Name = Name;
            this.Topic = Topic;
            this.UserCount = Users;
        }

        public void ReadFromStream(PacketReader r)
        {
            Name = r.ReadString();
            Topic = r.ReadString();
            UserCount = r.ReadInt16();
        }

        public void WriteToStream(PacketWriter w)
        {
            w.Write(Name);
            w.Write(Topic);
            w.Write(UserCount);
        }
    }
}
