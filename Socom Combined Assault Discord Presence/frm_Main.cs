using DiscordRPC;
using Binarysharp.MemoryManagement;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace SocomRichPresence
{
    public partial class frm_Main : Form
    {
        [DllImport("user32", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private extern static bool EnumThreadWindows(int threadId, EnumWindowsProc callback, IntPtr lParam);
        [DllImport("user32", SetLastError = true, CharSet = CharSet.Auto)]
        private extern static int GetWindowText(IntPtr hWnd, StringBuilder text, int maxCount);
        private delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);


        private const string PCSX2PROCESSNAME = "pcsx2dis";
        bool pcsx2Running;
        MemorySharp m = null;
        bool gameStarted = false;
        GameDataModel selectedGame;
        public DiscordRpcClient client;
        List<GameDataModel> socomGameObjects = new List<GameDataModel>();

        private static RichPresence presence = new RichPresence()
        {
            Details = "Not currently in a game.",
            State = "Room: Not in a room.",
            Assets = new Assets()
            {
                LargeImageKey = "default",
                LargeImageText = "Not in a room.",
                SmallImageKey = "default"
            }
        };

        
        public frm_Main()
        {

            InitializeComponent();
            PopulateGameObject();
            string crc = GetCRC(Process.GetProcessesByName(PCSX2PROCESSNAME).First());

            selectedGame = socomGameObjects.Where(g => g.GameCRC == crc).FirstOrDefault();
            if(selectedGame == null)
            {
                MessageBox.Show("Make sure PCSX2's console log window is enabled and you are playing a SOCOM game.");
                return;
            }
            lbl_SelectedGame.Text = selectedGame.GameName + " detected";

            client = new DiscordRpcClient("662019219030016001");
            client.Initialize();
            client.SetPresence(presence);
        }

        private void PopulateGameObject()
        {

            GameDataModel gdm = new GameDataModel();
            List<MapDataModel> mapInfo;

            // SOCOM 2 R0004
            gdm.GameCRC = "0F6FC6CF";
            gdm.GameName = "SOCOM II";
            gdm.PlayerPointerAddress = new IntPtr(0x20435618);
            gdm.GameEndedAddress = new IntPtr(0x20694C44);
            gdm.CurrentMapAddress = new IntPtr(0x204417C0);
            gdm.SealWinCounterAddress = new IntPtr(0x20695388);
            gdm.TerroristWinCounterAddress = new IntPtr(0x2069539C);
            gdm.PlayerKillsOffset = 0;
            gdm.PlayerDeathsOffset = 0;

            //This includes the day time maps and Single player maps, however neither of these are properly supported on the server yet.
            mapInfo = new List<MapDataModel>
            {
                { new MapDataModel("MP1","Blizzard","blizzard","MP26","Blizzard Day","blizzard_day")},
                { new MapDataModel("MP2","Frost Fire","frostfire","MP27","Frostfire Day","frostfire_day")},
                { new MapDataModel("MP5","Abandoned","abandoned","MP21","Abandoned Day","abandoned_day")},
                { new MapDataModel("MP73","Sand Storm","sandstorm","MP89","Sandstorm Day","sandstorm_day")},
                { new MapDataModel("MP7","Night Stalker","nightstalker","MP29","Nightstalker Day","nightstalker_day")},
                { new MapDataModel("MP6","Desert Glory","desertglory","MP28","Desert Glory Night","desertglory_night")},
                { new MapDataModel("M51","Seeding Chaos","seedingchaos","","","")},
                { new MapDataModel("M52","Terminal Transaction","terminaltransaction","","","")},
                { new MapDataModel("M53","Upland Assault","default","","","")},
                { new MapDataModel("M61","Urban Sweep","default","","","")},
                { new MapDataModel("M62","Strangle Hold","default","","","")},
                { new MapDataModel("M63","Hydro Electric","default","","","")},
                { new MapDataModel("M71","Guardian Angels","default","","","")},
                { new MapDataModel("M72","Protect and Serve","default","","","")},
                { new MapDataModel("M73","Against the Tide","default","","","")},
                { new MapDataModel("M81","Lockdown","default","","","")},
                { new MapDataModel("M82","Guided Tour","default","","","")},
                { new MapDataModel("M63","Doomsday Delivery","default","","","")},
                { new MapDataModel("NONE","","default","","","")},
                { new MapDataModel("MP10","Blood Lake","bloodlake","MP32","Blood Lake Night","bloodlake_night")},
                { new MapDataModel("MP11","Death Trap","deathtrap","MP33","Death Trap Night","deathtrap_night")},
                { new MapDataModel("MP12","The Ruins","theruins","MP34","The Ruins Night","theruins_night")},
                { new MapDataModel("MP62","Enowapi","enowapi","","","")},
                { new MapDataModel("MP8","Rat's Nest","ratsnest","MP30","Rat's Nest Day","ratsnest_day")},
                { new MapDataModel("MP53","Fox Hunt","foxhunt","","","")},
                { new MapDataModel("MP51","Vigilance","vigilance","","","")},
                { new MapDataModel("MP9","Bitter Jungle","bitterjungle","MP31","Bitter Jungle Night","bitterjungle_night")},
                { new MapDataModel("MP52","The Mixer","themixer","MP25","The Mixer Night","themixer_night")},
                { new MapDataModel("MP71","Fishhook","fishhook","MP23","Fish Hook Night","fishhook_night")},
                { new MapDataModel("MP72","Crossroads","crossroads","MP24","Crossroads Night","crossroads_night")},
                { new MapDataModel("MP64","Shadow Falls","shadowfalls","MP80","Shadowfalls Day","shadowfalls_day")},
                { new MapDataModel("MP61","Sujo","sujo","","","")},
                { new MapDataModel("MP81","Chain Reaction","chainreaction","","","")},
                { new MapDataModel("MP82","Guidanace","guidance","","","")},
                { new MapDataModel("MP83","Requim","requiem","","","")}
            };
            gdm.MapData = mapInfo;
            socomGameObjects.Add(gdm);

            //SOCOM 1 (DISK 1) I am not really sure I want to bother supporting the 9 zillion versions (assuming this sort of stuff changed)
            gdm = new GameDataModel();
            gdm.GameCRC = "6F4056DB";
            gdm.PlayerPointerAddress = new IntPtr(0x2048D548);
            gdm.GameEndedAddress = new IntPtr(0x205D708C);
            gdm.CurrentMapAddress = new IntPtr(0x0); // Don't seem to have this
            gdm.SealWinCounterAddress = new IntPtr(0x205D7514);
            gdm.TerroristWinCounterAddress = new IntPtr(0x205D7528);
            gdm.PlayerKillsOffset = 0;
            gdm.PlayerDeathsOffset = 0;
            gdm.MapData = mapInfo;

            socomGameObjects.Add(gdm);

            //Socom CA - Patch 1.0
            gdm = new GameDataModel();
            gdm.GameCRC = "";
            gdm.GameName = "SOCOM CA";
            gdm.PlayerPointerAddress = new IntPtr(0x206FEB08);
            gdm.GameEndedAddress = new IntPtr(0x20948264);
            gdm.CurrentMapAddress = new IntPtr(0x20783B78);
            gdm.SealWinCounterAddress = new IntPtr(0x20ccddac);
            gdm.TerroristWinCounterAddress = new IntPtr(0x20CCDDB4);
            gdm.PlayerKillsOffset = 0;
            gdm.PlayerDeathsOffset = 0;
            // These aren't entirely correct since other maps exist in other files (a small map will exist in a large map type of thing) it's going to display the first item.
            mapInfo = new List<MapDataModel>
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
            gdm.MapData = mapInfo;
            socomGameObjects.Add(gdm);


        }

        private string GetCRC(Process proc)
        {
            foreach (string item in GetWindowText(proc))
            {
                if (item.Contains("Status"))
                {
                    string[] splitText = item.Split('[');
                    string[] crc = splitText[2].Split(']');
                    return crc[0];             
                }
            }
            return "";
        }

        //https://www.codeproject.com/Questions/802305/How-to-get-the-Title-Bar-Text-of-a-EXE-by-its-Proc
        private IEnumerable<string> GetWindowText(Process p)
        {
            List<string> titles = new List<string>();
            foreach (ProcessThread t in p.Threads)
            {
                EnumThreadWindows(t.Id, (hWnd, lParam) =>
                {
                    StringBuilder text = new StringBuilder(200);
                    GetWindowText(hWnd, text, 200);
                    titles.Add(text.ToString());

                    return true;
                }, IntPtr.Zero);
            }
            return titles;
        }

        private void setPresence(int sealWins, int mercWins, short PlayerKills, short PlayerDeaths, string mapID)
        {

            MapDataModel mapInfo = selectedGame.MapData.Find(x => x._mapID.ToUpper() == mapID.ToUpper());

            if (sealWins == -1 && mercWins == -1)
            {
                presence.Details = "Not currently in a game.";
                presence.State = "";
            }
            else
            {
                presence.Details = "Seals: " + sealWins.ToString() + " || Mercs: " + mercWins.ToString();
                presence.State = "Kills: " + PlayerKills + " || Deaths: " + PlayerDeaths;
            }

            //presence.State = "Room: " + roomName;

            presence.Assets = new Assets();

            presence.Assets.LargeImageKey = "default";
            presence.Assets.SmallImageKey = "default";
            //presence.Assets.LargeImageText = mapInfo._mapName; // IM HAVING AN ISSUE HERE
            //presence.Assets.SmallImageText = mapInfo._mapName; //

            client.SetPresence(presence);
        }


        private void tmr_CheckPCSX2_Tick(object sender, EventArgs e)
        {
            Process[] pcsx2 = Process.GetProcessesByName(PCSX2PROCESSNAME);

            if (pcsx2.Length > 0)
            {
                lbl_PCSX2.Text = "PCSX2 Detected";
                lbl_PCSX2.ForeColor = Color.FromArgb(20, 192, 90);
                pcsx2Running = true;
                return;
            }

            lbl_PCSX2.Text = "Waiting for PCSX2...";
            lbl_PCSX2.ForeColor = Color.FromArgb(120, 120, 120);
            pcsx2Running = false;
        }

        private void tmr_GetPCSX2Data_Tick(object sender, EventArgs e)
        {
            if (!pcsx2Running)
            {
                return;
            }
            m = new MemorySharp(Process.GetProcessesByName(PCSX2PROCESSNAME).First());
            //Check to make sure that the user is even in a game to begin with
            if ((m.Read<byte>(selectedGame.PlayerPointerAddress, 4, false) != null) && (!m.Read<byte>(selectedGame.PlayerPointerAddress, 4, false).SequenceEqual(new byte[] { 0, 0, 0, 0 })))
            {
                if (m.Read<byte>(selectedGame.GameEndedAddress, false) == 0)
                {
                    string roomName = m.ReadString(selectedGame.RoomNameAddress, Encoding.Default, false, 4); // This is probably not sticking around
                    IntPtr playerObjectAddress = new IntPtr(m.Read<int>(selectedGame.PlayerPointerAddress, false)) + 20000000;
                    short PlayerKills = m.Read<short>(playerObjectAddress + selectedGame.PlayerKillsOffset, false);
                    short PlayerDeaths = m.Read<short>(playerObjectAddress + selectedGame.PlayerDeathsOffset, false);
                    string mapID = m.ReadString(selectedGame.CurrentMapAddress, Encoding.Default, false, 4);
                    int sealsRoundsWon = m.Read<byte>(selectedGame.SealWinCounterAddress, false);
                    int terroristRoundsWon = m.Read<byte>(selectedGame.TerroristWinCounterAddress, false);
                    if (!gameStarted)
                    {
                        presence.Timestamps = new Timestamps()
                        {
                            Start = DateTime.UtcNow

                        };

                        gameStarted = true;
                    }
                    setPresence(sealsRoundsWon, terroristRoundsWon, PlayerKills, PlayerDeaths, mapID);
                    return;
                }
            }
            m.Write<byte>(selectedGame.GameEndedAddress, new byte[] { 0x00 }, false);
            presence.Timestamps = null;
            setPresence(-1, -1, -1, -1, "NONE");
            gameStarted = false;

        }
    }
}
