using Komorebi.Extensions;
using Komorebi.Objects;
using Komorebi.Packets;
using Shared.Utils;
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

            int UserId = UserUtils.GetUserID(Username);

            if(!UserUtils.CheckPassword(UserId, Password))
            {
                Packet InvalidToken = new Packet(PacketType.Server_LoginResponse, new Structures.Server.LoginResponse(-1));
                ctx.Response.OutputStream.Serialize(InvalidToken);
                return;
            }

            Player p = new Player(UserId);
            p.SetData(true);
            Global.Players.Add(p.Token, p);
            ctx.Response.AddHeader("cho-token", p.Token);
            Packet LoginResponse = new Packet(PacketType.Server_LoginResponse, new Structures.Server.LoginResponse(UserId));
            ctx.Response.OutputStream.Serialize(LoginResponse);
            Packet ProtocolNegotiation = new Packet(PacketType.Server_ProtocolNegotiation, new Structures.Server.ProtocolNegtiation(19));
            ctx.Response.OutputStream.Serialize(ProtocolNegotiation);
            List<ISerializable> Packets = new List<ISerializable>();
            Packets.Add(new Packet(PacketType.Server_HandleStatsUpdate, new Structures.UserStatus(p)));
            Packets.Add(new Packet(PacketType.Server_UserPresence, new Structures.Server.UserPresence(p)));
            Packets.Add(new Packet(PacketType.Server_LoginPermissions, new Structures.Server.LoginPermissions(p.Privileges)));
            if (Config.LoginNotification != null) Packets.Add(new Packet(PacketType.Server_Announce, new Structures.Server.Announce(Config.LoginNotification)));
            if (Config.MainMenuIcon != null) Packets.Add(new Packet(PacketType.Server_TitleUpdate, new Structures.Server.TitleUpdate(Config.MainMenuIcon)));
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
