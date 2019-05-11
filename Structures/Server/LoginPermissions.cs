using Komorebi.Packets;

namespace Komorebi.Structures.Server
{
    public class LoginPermissions : ISerializable
    {
        int Permissions;
        public LoginPermissions() { }
        public LoginPermissions(int Permissions) => this.Permissions = Permissions;
        public LoginPermissions(byte[] Data) => this.Populate(Data);

        public void ReadFromStream(PacketReader r)
        {
            Permissions = r.ReadInt32();
        }

        public void WriteToStream(PacketWriter w)
        {
            w.Write(Permissions);
        }
    }
}
