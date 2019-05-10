﻿using Komorebi.Structures.Enumerations;
using Shared;
using System;

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
        public ActionType Action;
        public string ActionText, ActionMD5;
        public uint Mods, Beatmap = 0;
        // Status/Stats
        public byte Mode = 0;
        // Stats
        public long RankedScore, TotalScore = 0;
        public float Accuracy = 4.2f;
        public int Playcount, Performance, GameRank = 0;

        public string Country;

        public Player() { }
        public Player(int _UserID)
        {
            UserId = _UserID;
            Username = (string)Database.RunQueryOne($"SELECT username FROM users WHERE id = {UserId};");
            Token = new Guid().ToString();
        }

        public static Player GetPlayer(string T)
        {
            Global.Players.TryGetValue(T, out Player x);
            return x;
        }
    }
}