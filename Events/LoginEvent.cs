using Komorebi.Extensions;
using Komorebi.Objects;
using Komorebi.Packets;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace Komorebi.Events
{
    public class LoginEvent
    {
        public static void Handle(ref HttpListenerContext ctx)
        {
            string Username, Password;

            using (StreamReader r = new StreamReader(ctx.Request.InputStream))
            {
                Username = r.ReadLine();
                Password = r.ReadLine();
            }

            int UserId = 0;

            // Check Login right here

            //

            Player p = new Player(UserId);
            Global.Players.Add(p.Token, p);
            ctx.Response.AddHeader("cho-token", p.Token);
            Packet LoginResponse = new Packet(PacketType.Server_LoginResponse, new Structures.Server.LoginResponse(UserId));
            ctx.Response.OutputStream.Serialize(LoginResponse);
            Packet ProtocolNegotiation = new Packet(PacketType.Server_ProtocolNegotiation, new Structures.Server.ProtocolNegtiation(19));
            ctx.Response.OutputStream.Serialize(ProtocolNegotiation);
            List<ISerializable> Packets = new List<ISerializable>();
            Packets.Add(new Packet(PacketType.Server_HandleStatsUpdate, new Structures.UserStatus(p)));
            Packets.Add(new Packet(PacketType.Server_UserPresence, new Structures.Server.UserPresence(p)));
            Packets.Add(new Packet(PacketType.Server_LoginPermissions));
            Packets.Add(new Packet(PacketType.Server_ChannelListingComplete));

            List<Channel> Channels = ChannelList.ReadChannels;
            if (p.Privileges.Has(32)) Channels.Concat(ChannelList.AdminChannels);

            for(int i = 0; i < Channels.Count; i++)
            {
                Packets.Add(new Packet(PacketType.Server_ChannelAvailable, Channels[i]));
            }

            List<Player> Players = Global.Players.FindAll(x => x != null);
            if (Global.Players.Count >= 100)
            {
                List<int> Bundle = new List<int>();
                for (int i = 0; i < Players.Count; i++) Bundle.Add(Players[i].UserId);
                Packets.Add(new Packet(PacketType.Server_UserPresenceBundle, new Structures.Server.PresenceBundle(Bundle)));
            } else
            {
                for (int i = 0; i < Players.Count; i++)
                {
                    Packets.Add(new Packet(PacketType.Server_HandleStatsUpdate, new Structures.UserStatus(Players[i])));
                    Packets.Add(new Packet(PacketType.Server_UserPresence, new Structures.Server.UserPresence(Players[i])));
                }
            }

            

            ctx.Response.OutputStream.Serialize(Packets);
        }
    }
}
