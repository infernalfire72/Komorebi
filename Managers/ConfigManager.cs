using Console = Colorful.Console;
using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Collections.Generic;

namespace Komorebi.Managers
{
    internal class ConfigManager
    {
        internal static bool ConfigExists => File.Exists("Komorebi.cfg");

        private static Dictionary<string, string> Fields = new Dictionary<string, string>();

        public static void LoadConfig()
        {
            ParseConfig();

            Config.ServerPort = GetValue("ServerPort", 5001);
        }

        internal static void ParseConfig()
        {
            if(!ConfigExists)
            {
                Console.WriteLineFormatted("Config File not Found...\nGenerating a new one.", Color.Red);
                Thread.Sleep(5000);
                Environment.Exit(1337);
                return;
            }

            string[] ConfigLines = File.ReadAllLines("Komorebi.cfg");
            for(int i = 0; i < ConfigLines.Length; i++)
            {
                if (ConfigLines[i].Length < 3) continue;
                if (ConfigLines[i].StartsWith("[")) continue;
                int SplitterPos = ConfigLines[i].IndexOf("=");
                string Key = ConfigLines[i].Substring(0, SplitterPos).Trim();
                string Value = ConfigLines[i].Substring(SplitterPos).Remove(0, 1).Trim();
                Fields.Add(Key, Value);
            }


        }

        private static dynamic GetValue<dynamic>(string Keyname, dynamic Default)
        {
            object TReturn = Default;
            if (Fields.TryGetValue(Keyname, out string Value))
            {
                string Type = typeof(dynamic).Name;
                switch (Type)
                {
                    case "Boolean":
                        TReturn = Char.ToLower(Value[0]) == 't';
                        break;
                    case "Int32":
                        TReturn = Convert.ToInt32(Value);
                        break;
                    case "Int64":
                        TReturn = Convert.ToInt64(Value);
                        break;
                    case "String":
                        TReturn = Value;
                        break;
                }
            }

            return (dynamic)TReturn;
        }
    }
}

namespace Komorebi
{
    public static class Config
    {
        public static int ServerPort = 5001;
    }
}