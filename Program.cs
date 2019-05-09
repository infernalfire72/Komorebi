using Komorebi.Managers;
using Komorebi.Server;

namespace Komorebi
{
    class Program
    {
        static void Main(string[] args)
        {
            ConfigManager.LoadConfig();
            new HttpServer(5001);
        }
    }
}
