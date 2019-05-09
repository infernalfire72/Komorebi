using Komorebi.Server;

namespace Komorebi
{
    class Program
    {
        static void Main(string[] args)
        {
            new HttpServer(5001);
        }
    }
}
