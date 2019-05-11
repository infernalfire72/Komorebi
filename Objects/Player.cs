using Komorebi.Structures.Enumerations;
using Shared;
using System;
using Komorebi.Packets;
using System.IO;
using MySql.Data.MySqlClient;
using Shared.Utils;

namespace Komorebi.Objects
{
    public class Player
    {
        public readonly int UserId;
        public string Username;
        public string SafeUsername => Username.Replace(" ", "_").ToLower();
        public readonly string Token;

        public int Privileges;

        // Status
        public ActionType Action = ActionType.Idle;
        public string ActionText, ActionMD5 = "";
        public uint Mods, Beatmap = 0;
        // Status/Stats
        public byte Mode = 0;
        // Stats
        public long RankedScore, TotalScore = 0;
        public float Accuracy = 4.2f;
        public int Playcount, Performance, GameRank = 0;

        public long loggedIn;
        public long pingTime = (long)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        public long onlineTime => (long)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds - loggedIn;

        public string Country;

        private MemoryStream ms;

        public Player() { }
        public Player(int _UserID)
        {
            UserId = _UserID;

            Username = (string)Database.RunQueryOne($"SELECT username FROM users WHERE id = {UserId};");

            Token = new Guid().ToString();
            loggedIn = (long)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            ms = new MemoryStream();
        }

        public void SetData(bool SetCountry = false)
        {
            using (MySqlDataReader r = Database.RunQuery($"SELECT * FROM users_stats WHERE id = {UserId}"))
            {
                if (SetCountry)
                {
                    Country = r.GetString("country");
                }

                if (this.Mode > 3) this.Mode = 0;
                DatabaseMode Mode = (DatabaseMode)this.Mode;
                RankedScore = r.GetInt64($"ranked_score_{Mode}");
                TotalScore = r.GetInt64($"total_score_{Mode}");
                Accuracy = (r.GetFloat($"avg_accuracy_{Mode}") / 100f);
                Playcount = r.GetInt32($"playcount_{Mode}");
                GameRank = (int)UserUtils.GetGameRank(UserId, this.Mode);
                Performance = r.GetInt32($"pp_{Mode}");
            }
        }

        public static Player GetPlayer(string T)
        {
            Global.Players.TryGetValue(T, out Player x);
            return x;
        }

        public void Write(Packet Packet)
        {
            ms.Serialize(Packet);
        }

        public Stream PlayerStream => ms;
    }
}
