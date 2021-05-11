using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socom_Combined_Assault_Discord_Presence
{
    public static class GameHelper
    {
        //NEW Memory Sharp Input
        //Patch 1.0
        public static IntPtr PLAYER_POINTER_ADDRESS = new IntPtr(0x206FEB08);
        public static int PlayerKills = 0x654;
        public static int PlayerDeaths = 0x65C;
        public static IntPtr GAME_ENDED_ADDRESS = new IntPtr(0x20948264);
        public static IntPtr CURRENT_MAP_ADDRESS = new IntPtr(0x20783B78);
        public static IntPtr SEAL_WIN_COUNTER_ADDRESS = new IntPtr(0x20ccddac);
        public static IntPtr MERC_WIN_COUNTER_ADDRESS = new IntPtr(0x20CCDDB4);
        public static IntPtr ROOM_NAME_ADDRESS = new IntPtr(0x20C3D9A8);

        //Patch1.4


        //OLD Memory.dll Input
        //public const string GAME_ENDED_ADDRESS = "20948264";
        //public const string CURRENT_MAP_ADDRESS = "20783B78";
        //public const string SEAL_WIN_COUNTER_ADDRESS = "20ccddac";
        //public const string MERC_WIN_COUNTER_ADDRESS = "20CCDDB4";
        //public const string PLAYER_POINTER_ADDRESS = "206FEB08";
        //public const string ROOM_NAME_ADDRESS = "20C3D9A8";

        /// <summary>
        /// Current Map Image
        /// </summary>
        public static List<MapDataModel> mapInfo = new List<MapDataModel>
        {
            { new MapDataModel("055146d2.ZAR","Harvester","default")},
            { new MapDataModel("74068550.ZAR","Crucible","default")},
            { new MapDataModel("838dc6b0.ZAR","Killing Fields","default")},
            { new MapDataModel("e7763cea.ZAR","Citadel","default")},
            { new MapDataModel("733981f0.ZAR","Devil's Road","default")},
            { new MapDataModel("ea9385f.ZAR","Boneyard","default")},
            { new MapDataModel("299c50c.ZAR","Tidal Fury","default")},
            { new MapDataModel("d06ff55.ZAR","Antendora","default")},
            { new MapDataModel("ea9385f.ZAR","Storm Front","default")},
            { new MapDataModel("55146d2.ZAR","Fault","default")},
            { new MapDataModel("986fa1a.ZAR","Waterworls","default")},
            { new MapDataModel("55146d2.ZAR","Blackwoods","default")},
            { new MapDataModel("8dabcf2.ZAR","Summit","default")},
            { new MapDataModel("7ab5cb7.ZAR","Copperhead","default")},
            { new MapDataModel("d5d52f7.ZAR","Siphon","default")},
            { new MapDataModel("aea19d9.ZAR","Anchorage","default")},
            { new MapDataModel("8c3cd05.ZAR","Threshold","default")},
            { new MapDataModel("97b4826.ZAR","Retaliation","default")},
            { new MapDataModel("74aa7a5.ZAR","Bootcamp","default")},
            { new MapDataModel("909a6e6.ZAR","Prowler","default")},
            { new MapDataModel("d38d48c.ZAR","Echelon","default")},
            { new MapDataModel("1f79488.ZAR","Aftershock","default")},
            { new MapDataModel("E5B66869.ZAR","Guidance","default")},
            { new MapDataModel("5221e18.ZAR","Frostfire","default")},
            { new MapDataModel("ac5dd46.ZAR","Liberation","default")},
            { new MapDataModel("9181507.ZAR","Fishhook","default")},
            { new MapDataModel("2be6eab.ZAR","Desert Glory","default")},
            { new MapDataModel("e65077e.ZAR","Last Bastion","default")},
            { new MapDataModel("fb5ec81.ZAR","Crossroads","default")},
            { new MapDataModel("8ac526f.ZAR","Abamdoned","default")},
            { new MapDataModel("90849b5.ZAR","Afterhours","default")},
            { new MapDataModel("fa521ab.ZAR","Blood Lake","default")},
            { new MapDataModel("85a12d6.ZAR","Blizzard","default")},
            { new MapDataModel("NONE","","default")}
        };
    }

    public static class Socom3
    {
        //Patch 1.0
        public static IntPtr PlayerPointer = new IntPtr(0x20649F78);
        public static int PlayerKills = 0xF01C;
        public static int PlayerDeaths = 0xF014;
        public static int PlayerTeam = 0xD8;
        public static int PlayerHealth = 0x968;

        ///I'm still working on finding these addresses , these are leftover from CA for reference
        //public static IntPtr GameEndAddress = new IntPtr(0x20948264);
        //public static IntPtr CurrentMap = new IntPtr(0x20783B78);
        //public static IntPtr SealWins = new IntPtr(0x20ccddac);
        //public static IntPtr MercWins = new IntPtr(0x20CCDDB4);
        //public static IntPtr RoomName = new IntPtr(0x20C3D9A8);
    }
}

namespace Tools.Helpers
{
    public static class Extensions
    {
        public static IntPtr OffsetToPlaystationMemory(this IntPtr address)
            => address + 0x20000000;
    }
}

