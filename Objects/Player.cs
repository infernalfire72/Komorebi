using System;

namespace Komorebi.Objects
{
    public class Player
    {
        public readonly int UserId;
        public string Username;
        public string SafeUsername;
        public readonly string Token;


        public Player() { }
        public Player(int _UserID)
        {
            UserId = _UserID;
            Token = new Guid().ToString();
        }

        public static Player GetPlayer(string T)
        {
            Global.Players.TryGetValue(T, out Player x);
            return x;
        }
    }
}
