using System;
using System.Net;
using System.Threading;

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

            Response.OutputStream.Close();
        }
    }
}
