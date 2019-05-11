using Komorebi.Events;
using Komorebi.Handler;
using Komorebi.Objects;
using Komorebi.Packets;
using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading;
using Console = Colorful.Console;
namespace Komorebi.Server
{
    public class HttpServer
    {
        public HttpServer(int Port)
        {
            this.Initialize(Port);
        }
        private HttpListener listener;
        private void Initialize(int port)
        {
            try
            {
                listener = new HttpListener();
                listener.Prefixes.Add($"http://*:{port}/");
                listener.Start();

                Console.WriteLineFormatted($"Now Listening on *:{port}", Color.LimeGreen);

                new Thread(() =>
                {
                    while(true)
                    {
                        try
                        {
                            HttpListenerContext ctx = listener.GetContext();
                            new Thread(() => Process(ctx)).Start();
                        } catch
                        {
                        }
                    }
                }).Start();

            } catch (Exception e)
            {
                
            }
        }

        private void Process(HttpListenerContext ctx)
        {
            HttpListenerRequest Request = ctx.Request;
            HttpListenerResponse Response = ctx.Response;

            if (Request.Headers["osu-token"] == null || Request.Headers["osu-token"] == "no")
            {
                LoginEvent.Handle(ref ctx);
            }
            else
            {
                Player p = Player.GetPlayer(Request.Headers["osu-token"]);
                if(p == null)
                {
                    Packet InvalidToken = new Packet(PacketType.Server_LoginResponse, new Structures.Server.LoginResponse(-5));
                    Response.OutputStream.Serialize(InvalidToken); // 7+4 = 11 lol
                    Response.StatusCode = 403;
                }

                using (MemoryStream ms = new MemoryStream())
                using (BinaryReader r = new BinaryReader(ms))
                {
                    Request.InputStream.CopyTo(ms);
                    ms.Position = 0;

                    while (true)
                    {
                        if (ms.Length - ms.Position < 7) // 7: Base Packet Length => 2 bytes Packet ID, 1 random byte?(idk), 4 length bytes
                            break;

                        PacketType PacketID = (PacketType)r.ReadInt16();
                        ms.Position += 1;
                        int Length = r.ReadInt32();
                        byte[] PacketData = r.ReadBytes(Length);
                        Main.Handle(p, new Packet(PacketID, PacketData));
                    }
                }

                p.PlayerStream.CopyTo(Response.OutputStream);
            }

            Response.OutputStream.Close();
        }
    }
}