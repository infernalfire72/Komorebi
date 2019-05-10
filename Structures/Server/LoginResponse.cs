using Komorebi.Packets;

namespace Komorebi.Structures.Server
{
    public class LoginResponse : ISerializable
    {
        int UserId;
        public LoginResponse() { }
        public LoginResponse(int userId) => UserId = userId;
        public LoginResponse(byte[] data) => this.Populate(data);

        public void ReadFromStream(PacketReader r)
        {
            UserId = r.ReadInt32();
        }

        public void WriteToStream(PacketWriter w)
        {
            w.Write(UserId);
        }
    }
}
