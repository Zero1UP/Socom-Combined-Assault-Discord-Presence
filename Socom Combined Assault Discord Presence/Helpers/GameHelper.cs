using System;
using System.Collections.Generic;

namespace Socom_Combined_Assault_Discord_Presence
{
    public static class SOCOM1
    {
        //Player Object Data
        public static IntPtr PLAYER_POINTER_ADDRESS = new IntPtr(0x2048D548);
        public const int PlayerName = 0x14;
        public const int PlayerTeam = 0xC4;
        public const int PlayerHealth = 0xED0;
        public const int CurrentRound = 0x484;
        public const int PlayerKills = 0x48C;
        public const int PlayerDeaths = 0x494;

        //Game information
        public static IntPtr ROUND_TIMER = new IntPtr(0x20578100);
        public static IntPtr GAME_ENDED_ADDRESS = new IntPtr(0x205D708C);
        public static IntPtr SEAL_WIN_COUNTER_ADDRESS = new IntPtr(0x205D7514);
        public static IntPtr TERR_WIN_COUNTER_ADDRESS = new IntPtr(0x205D7528);
        public static IntPtr SEALS_ALIVE_COUNTER_ADDRESS = new IntPtr(0x205D70DC);
        public static IntPtr TERR_ALIVE_COUNTER_ADDRESS = new IntPtr(0x205D70F0);

        ///ROOM NAME?
        ///CURRENT MAP ADDRESS?
    }

    public static class SOCOM2
    {
        public static IntPtr PLAYER_POINTER_ADDRESS = new IntPtr(0x20435618);
        public static IntPtr GAME_ENDED_ADDRESS = new IntPtr(0x20694C44);  //May need to reset this to 0 after it ends, it seems to persist till the next game and doesn't reset when the player loads i
        public static IntPtr CURRENT_MAP_ADDRESS = new IntPtr(0x204417C0); // Text String of MapID, if not in a game then it is set to NONE
        public static IntPtr SEAL_WIN_COUNTER_ADDRESS = new IntPtr(0x20695388);
        public static IntPtr TERRORIST_WIN_COUNTER_ADDRESS = new IntPtr(0x2069539C);
        public static IntPtr ROOM_NAME_ADDRESS = new IntPtr(0x21FFBBE0);

        public static int PLAYER_KILLS_OFFSET = 0x550;
        public static int PLAYER_DEATHS_OFFSET = 0x556;
        //public const string CUSTOM_MAP_ADDRESS = "200F71B0";


        public static List<MapDataModelS2> mapInfo = new List<MapDataModelS2>
        {
            { new MapDataModelS2("MP1","Blizzard","blizzard","MP26","Blizzard Day","blizzard_day")},
            { new MapDataModelS2("MP2","Frost Fire","frostfire","MP27","Frostfire Day","frostfire_day")},
            { new MapDataModelS2("MP5","Abandoned","abandoned","MP21","Abandoned Day","abandoned_day")},
            { new MapDataModelS2("MP73","Sand Storm","sandstorm","MP89","Sandstorm Day","sandstorm_day")},
            { new MapDataModelS2("MP7","Night Stalker","nightstalker","MP29","Nightstalker Day","nightstalker_day")},
            { new MapDataModelS2("MP6","Desert Glory","desertglory","MP28","Desert Glory Night","desertglory_night")},
            { new MapDataModelS2("M51","Seeding Chaos","seedingchaos","","","")},
            { new MapDataModelS2("M52","Terminal Transaction","terminaltransaction","","","")},
            { new MapDataModelS2("M53","Upland Assault","default","","","")},
            { new MapDataModelS2("M61","Urban Sweep","default","","","")},
            { new MapDataModelS2("M62","Strangle Hold","default","","","")},
            { new MapDataModelS2("M63","Hydro Electric","default","","","")},
            { new MapDataModelS2("M71","Guardian Angels","default","","","")},
            { new MapDataModelS2("M72","Protect and Serve","default","","","")},
            { new MapDataModelS2("M73","Against the Tide","default","","","")},
            { new MapDataModelS2("M81","Lockdown","default","","","")},
            { new MapDataModelS2("M82","Guided Tour","default","","","")},
            { new MapDataModelS2("M63","Doomsday Delivery","default","","","")},
            { new MapDataModelS2("NONE","","default","","","")},
            { new MapDataModelS2("MP10","Blood Lake","bloodlake","MP32","Blood Lake Night","bloodlake_night")},
            { new MapDataModelS2("MP11","Death Trap","deathtrap","MP33","Death Trap Night","deathtrap_night")},
            { new MapDataModelS2("MP12","The Ruins","theruins","MP34","The Ruins Night","theruins_night")},
            { new MapDataModelS2("MP62","Enowapi","enowapi","","","")},
            { new MapDataModelS2("MP8","Rat's Nest","ratsnest","MP30","Rat's Nest Day","ratsnest_day")},
            { new MapDataModelS2("MP53","Fox Hunt","foxhunt","","","")},
            { new MapDataModelS2("MP51","Vigilance","vigilance","","","")},
            { new MapDataModelS2("MP9","Bitter Jungle","bitterjungle","MP31","Bitter Jungle Night","bitterjungle_night")},
            { new MapDataModelS2("MP52","The Mixer","themixer","MP25","The Mixer Night","themixer_night")},
            { new MapDataModelS2("MP71","Fishhook","fishhook","MP23","Fish Hook Night","fishhook_night")},
            { new MapDataModelS2("MP72","Crossroads","crossroads","MP24","Crossroads Night","crossroads_night")},
            { new MapDataModelS2("MP64","Shadow Falls","shadowfalls","MP80","Shadowfalls Day","shadowfalls_day")},
            { new MapDataModelS2("MP61","Sujo","sujo","","","")},
            { new MapDataModelS2("MP81","Chain Reaction","chainreaction","","","")},
            { new MapDataModelS2("MP82","Guidanace","guidance","","","")},
            { new MapDataModelS2("MP83","Requim","requiem","","","")}
        };
    }

    public static class SOCOM3
    {
        //Patch 1.0
        public static IntPtr PLAYER_POINTER_ADDRESS = new IntPtr(0x20649F78);
        public static int PlayerKills = 0x6C4;
        public static int PlayerDeaths = 0x6FC;
        public static int PlayerTeam = 0xD8;
        public static int PlayerHealth = 0x968;

        //Match Information
        public static IntPtr GAME_ENDED_ADDRESS = new IntPtr(0x20887FA4);
        public static IntPtr ROOM_NAME_ADDRESS = new IntPtr(0x206D7100);

        ///I'm still working on finding these addresses , these are leftover from CA for reference
        //public static IntPtr CURRENT_MAP_ADDRESS = new IntPtr(0x20783B78);
        //public static IntPtr SEAL_WIN_COUNTER_ADDRESS = new IntPtr(0x20ccddac);
        //public static IntPtr TERR_WIN_COUNTER_ADDRESS = new IntPtr(0x20CCDDB4);

    }

    public static class SocomCA
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
}

namespace Tools.Helpers
{
    public static class Extensions
    {
        public static IntPtr OffsetToPlaystationMemory(this IntPtr address)
            => address + 0x20000000;
    }
}

