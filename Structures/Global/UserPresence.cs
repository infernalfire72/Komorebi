using Komorebi.Objects;
using Komorebi.Packets;
using Komorebi.Structures.Enumerations;

namespace Komorebi.Structures
{
    public class UserStatus : ISerializable
    {
        public ActionType Action;
        public string ActionText, ActionMD5;
        public uint Mods, Beatmap;
        public byte Mode;

        private Player Player;

        public UserStatus() { }
        public UserStatus(Player P) => Player = P;
        public UserStatus(byte[] Data) => this.Populate(Data);

        public void ReadFromStream(PacketReader r)
        {
            Action = (ActionType)r.ReadByte();
            ActionText = r.ReadString();
            ActionMD5 = r.ReadString();
            Mods = r.ReadUInt32();
            Mode = r.ReadByte();
            Beatmap = r.ReadUInt32();
        }

        public void WriteToStream(PacketWriter w)
        {
            w.Write(Player.UserId);
            w.Write((byte)Player.Action);
            w.Write(Player.ActionText);
            w.Write(Player.ActionMD5);
            w.Write(Player.Mods);
            w.Write(Player.Mode);
            w.Write(Player.Beatmap);
            w.Write(Player.RankedScore);
            w.Write(Player.Accuracy);
            w.Write(Player.Playcount);
            w.Write(Player.TotalScore);
            w.Write(Player.GameRank);
            w.Write((short)Player.Performance);
        }
    }
}
