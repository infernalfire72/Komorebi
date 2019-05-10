﻿using Komorebi.Objects;
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
            List<ISerializable> Packets = new List<ISerializable>();
            Packets.Add(new Packet(PacketType.Server_HandleStatsUpdate, new Structures.UserStatus(p)));
            Packets.Add(new Packet(PacketType.Server_UserPresence, new Structures.Server.UserPresence(p)));
            ctx.Response.OutputStream.Serialize(Packets);
        }
    }
}
