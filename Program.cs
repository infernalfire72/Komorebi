using Komorebi.Managers;
using Komorebi.Objects;
using Komorebi.Server;

namespace Komorebi
{
    class Program
    {
        static void Main(string[] args)
        {
            ConfigManager.LoadConfig();
            ChannelList.Initialize();
            new HttpServer(Config.ServerPort);
        }
    }
}
