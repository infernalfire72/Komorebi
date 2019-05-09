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

                Console.WriteLineFormatted($"Now Listening on *:{port}", Color.Green);

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

            }
            else
            {
                

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
                    }
                }
            }

            Response.OutputStream.Close();
        }
    }
}
