using Komorebi.Extensions;
using Komorebi.Packets;
using Komorebi.Structures;
using MySql.Data.MySqlClient;
using Shared;
using System.Collections.Generic;

namespace Komorebi.Objects
{
    public class Channel : ISerializable
    {
        public string Name, Topic;
        public short UserCount => (short)joinedPlayers.Count;

        public bool Write = true;
        public bool Read = true;


        public List<Player> joinedPlayers = new List<Player>();

        public Channel() { }
        public Channel(byte[] data) => this.Populate(data);
        public Channel(string Name, string Topic)
        {
            this.Name = Name;
            this.Topic = Topic;
        }

        public bool Join(Player p)
        {
            if (!Read && !p.Privileges.Has(32)) return false;
            joinedPlayers.Add(p);
            return true;
        }

        public void Leave(Player p)
        {
            joinedPlayers.Remove(p);
        }

        public void Broadcast(IrcMessage msg, Player Sender)
        {
            if (!Write && !Sender.Privileges.Has(32)) return; // Readonly for Members under Admin
            Packet MessagePacket = new Packet(PacketType.Server_IrcMessage, msg);
            for (int i = 0; i < joinedPlayers.Count; i++)
            {
                if (joinedPlayers[i] == null) continue;
                if (joinedPlayers[i] == Sender) continue;
                joinedPlayers[i].Write(MessagePacket);
            }
        }

        public void ReadFromStream(PacketReader r)
        {
            Name = r.ReadString();
            Topic = r.ReadString();
            //UserCount = r.ReadInt16();
        }

        public void WriteToStream(PacketWriter w)
        {
            w.Write(Name);
            w.Write(Topic);
            w.Write(UserCount);
        }
    }

    public static class ChannelList
    {
        private static bool a = false;

        public static void Initialize()
        {
            if(a)
            {
                Global.Channels.Clear();
            }
            using (MySqlDataReader r = Database.RunQuery("SELECT * FROM channels;"))
            {
                while(r.Read())
                {
                    Channel c = new Channel(r.GetString("name"), r.GetString("topic"));
                    c.Write = r.GetByte("public_write") == 1;
                    c.Read = r.GetByte("public_read") == 1;
                    Global.Channels.Add(c.Name, c);
                }
            }
            a = true;
        }

        public static List<Channel> ReadChannels => Global.Channels.FindAll(x => x.Read);
        public static List<Channel> AdminChannels => Global.Channels.FindAll(x => !x.Read);
    }
}
