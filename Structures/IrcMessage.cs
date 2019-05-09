using Komorebi.Packets;

namespace Komorebi.Structures
{
    public class IrcMessage : ISerializable
    {
        public string Sender, Message, Channel;
        public int SenderId; // For Writing
        public IrcMessage() { }
        public IrcMessage(byte[] Data) => this.Populate(Data);

        public void ReadFromStream(PacketReader r)
        {
            Sender = r.ReadString();
            Message = r.ReadString();
            Channel = r.ReadString();
            SenderId = 0; // Always 0 on reading incoming.
        }

        public void WriteToStream(PacketWriter w)
        {
            w.Write(Sender);
            w.Write(Message);
            w.Write(Channel);
            w.Write(SenderId);
        }
    }
}
