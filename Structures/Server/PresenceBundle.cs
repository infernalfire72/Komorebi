using Komorebi.Packets;
using System.Collections.Generic;

namespace Komorebi.Structures.Server
{
    public class PresenceBundle : ISerializable
    {
        public List<int> Bundle;

        public PresenceBundle() { }
        public PresenceBundle(byte[] Data) => this.Populate(Data);
        public PresenceBundle(List<int> bundle) => Bundle = bundle;

        public void ReadFromStream(PacketReader r)
        {
            short count = r.ReadInt16();
            for (int i = 0; i < count; i++) Bundle.Add(r.ReadInt32());
        }

        public void WriteToStream(PacketWriter w)
        {
            w.Write((short)Bundle.Count);
            for (int i = 0; i < Bundle.Count; i++) w.Write(Bundle[i]);
        }
    }
}
