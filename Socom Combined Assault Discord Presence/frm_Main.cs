using DiscordRPC;
using Binarysharp.MemoryManagement;
using Tools.Helpers;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Socom_Combined_Assault_Discord_Presence
{
    public partial class frm_Main : Form
    {
        private const string PCSX2PROCESSNAME = "pcsx2";
        bool pcsx2Running;
        MemorySharp m = null;
        bool gameStarted = false;

        //SOCOM 1 Discord RPC
        private static RichPresence presenceS1 = new RichPresence()
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
        public DiscordRpcClient clientS1; // SOCOM 1 Discord RPC 
        
        //SOCOM 2 Discord RPC
        private static RichPresence presenceS2 = new RichPresence()
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
        public DiscordRpcClient clientS2; // SOCOM 2 Discord RPC 

        //SOCOM 3 Discord RPC
        private static RichPresence presenceS3 = new RichPresence()
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
        public DiscordRpcClient clientS3; // SOCOM 3 Discord RPC 
        
        //SOCOM CA Discord RPC
        private static RichPresence presenceCA = new RichPresence()
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
        public DiscordRpcClient clientCA; // SOCOM CA Discord RPC

        public frm_Main()
        {
            InitializeComponent();

            //SOCOM 1 Discord RPC
            clientS1 = new DiscordRpcClient("774372334701248522");
            clientS1.Initialize();
            //clientS1.SetPresence(presenceS1);

            //SOCOM 2 Discord RPC
            clientS2 = new DiscordRpcClient("657060473849643018");
            clientS2.Initialize();
            //clientS2.SetPresence(presenceS2);

            //SOCOM 3 Discord RPC
            clientS3 = new DiscordRpcClient("841862202305544222");
            clientS3.Initialize();
            //clientS3.SetPresence(presenceS3);

            //SOCOM CA Discord RPC
            clientCA = new DiscordRpcClient("662019219030016001");
            clientCA.Initialize();
            //clientCA.SetPresence(presenceCA);
        }

        //SOCOM 1 Discord RPC
        private void setPresenceS1(int sealWins, int terrorWins, short kills, short deaths)
        {
            if (CheckBoxS1.Checked)
            {
                if (sealWins == -1 && terrorWins == -1)
                {
                    presenceS1.Details = "Not currently in a game.";
                }
                else
                {
                    presenceS1.Details = "Seals: " + sealWins + " || Terrorist: " + terrorWins;
                    presenceS1.State = "Kills: " + kills + " || Deaths: " + deaths;
                }
                presenceS1.Assets = new Assets();
                presenceS1.Assets.LargeImageKey = "1";
                presenceS1.Assets.SmallImageKey = "green";
                //presence.Assets.LargeImageText = 
                //presence.Assets.SmallImageText = 
                clientS1.SetPresence(presenceS1);
            }
        }

        //SOCOM 2 Discord RPC
        private void setPresenceS2(int sealWins, int terrorWins, string mapID, short kills, short deaths)
        {
            MapDataModelS2 mapInfo = SOCOM2.mapInfo.Find(x => x._mapID == mapID.ToUpper());

            if (sealWins == -1 && terrorWins == -1)
            {
                presenceS2.Details = "Not currently in a game.";
            }
            else
            {
                presenceS2.Details = "Seals: " + sealWins + " || Terrorist: " + terrorWins;
                presenceS2.State = "Kills: " + kills + " || Deaths: " + deaths;
            }
            presenceS2.Assets = new Assets();
            presenceS2.Assets.LargeImageKey = mapInfo._discordKey;
            presenceS2.Assets.SmallImageKey = mapInfo._discordKey;
            presenceS2.Assets.LargeImageText = mapInfo._mapName;
            presenceS2.Assets.SmallImageText = mapInfo._mapName;
            clientS2.SetPresence(presenceS2);
            //if (customMap == 1)
            //{
            //    presence.Assets.LargeImageKey = mapInfo._altDiscordKey;
            //    presence.Assets.SmallImageKey = mapInfo._altDiscordKey;
            //    presence.Assets.LargeImageText = mapInfo._altMapName;
            //    presence.Assets.SmallImageText = mapInfo._altMapName;

            //}
            //else
        }

        //SOCOM 3 Discord RPC
        private void setPresenceS3(short PlayerKills, short PlayerDeaths)
        {
            if (PlayerKills == -1 && PlayerDeaths == -1)
            {
                presenceS3.Details = "Not currently in a game.";
            }
            else
            {
                presenceS3.Details = "Currently Playing";
                presenceS3.State = "Kills: " + PlayerKills + " || Deaths: " + PlayerDeaths;
            }
            presenceS3.Assets = new Assets();
            presenceS3.Assets.LargeImageKey = "main";
            presenceS3.Assets.SmallImageKey = "green";
            //presence.Assets.LargeImageText =
            //presence.Assets.SmallImageText =
            clientS3.SetPresence(presenceS3);
        }

        //SOCOM CA Discord RPC
        private void setPresenceCA(int sealWins, int mercWins, short PlayerKills, short PlayerDeaths, string mapID)
        {

            MapDataModel mapInfo = SocomCA.mapInfo.Find(x => x._mapID.ToUpper() == mapID.ToUpper());
            if (CheckBoxCA.Checked)
            {
                if (sealWins == -1 && mercWins == -1)
                {
                    presenceCA.Details = "Not currently in a game.";
                    presenceCA.State = "";
                }
                else
                {
                    presenceCA.Details = "Seals: " + sealWins.ToString() + " || Mercs: " + mercWins.ToString();
                    presenceCA.State = "Kills: " + PlayerKills + " || Deaths: " + PlayerDeaths;
                }

                //presence.State = "Room: " + roomName;

                presenceCA.Assets = new Assets();

                presenceCA.Assets.LargeImageKey = "default";
                presenceCA.Assets.SmallImageKey = "default";
                //presence.Assets.LargeImageText = mapInfo._mapName; // IM HAVING AN ISSUE HERE
                //presence.Assets.SmallImageText = mapInfo._mapName; //

                clientCA.SetPresence(presenceCA);
            }
        }

        private void resetPresenceS1()
        {
            presenceS1.Timestamps = null;
            setPresenceS1(-1, -1, -1, -1);
            gameStarted = false;
        }

        private void resetPresenceS2()
        {
            presenceS2.Timestamps = null;
            setPresenceS2(-1, -1, "NONE", -1, -1);
            gameStarted = false;
        }

        private void resetPresenceS3()
        {
            presenceS3.Timestamps = null;
            setPresenceS3(-1, -1);
            gameStarted = false;
        }

        private void tmr_CheckPCSX2_Tick(object sender, EventArgs e)
        {
            Process[] pcsx2 = Process.GetProcessesByName(PCSX2PROCESSNAME);

            if (pcsx2.Length > 0)
            {
                lbl_PCSX2.Text = "PCSX2 Detected";
                lbl_PCSX2.ForeColor = Color.FromArgb(20, 192, 90);
                pcsx2Running = true;
            }
            else
            {
                lbl_PCSX2.Text = "Waiting for PCSX2...";
                lbl_PCSX2.ForeColor = Color.FromArgb(192, 20, 50);
                pcsx2Running = false;
            }
        }

        private void tmr_GetPCSX2Data_Tick(object sender, EventArgs e)
        {
            if (!pcsx2Running)
            {
                return;
            }
            m = new MemorySharp(Process.GetProcessesByName(PCSX2PROCESSNAME).First());

            //SOCOM 1 Discord RPC
            if (CheckBoxS1.Checked)
            {
                try
                {
                    if ((m.Read<byte>(SOCOM1.PLAYER_POINTER_ADDRESS, 4, false) != null) && (!m.Read<byte>(SOCOM1.PLAYER_POINTER_ADDRESS, 4, false).SequenceEqual(new byte[] { 0, 0, 0, 0 })))
                    {
                        if (m.Read<byte>(SOCOM1.GAME_ENDED_ADDRESS, false) == 0)
                        {
                            IntPtr playerObjectAddress = new IntPtr(m.Read<int>(SOCOM1.PLAYER_POINTER_ADDRESS, false)).OffsetToPlaystationMemory();
                            short kills = m.Read<short>(playerObjectAddress + SOCOM1.PlayerKills, false);
                            short deaths = m.Read<short>(playerObjectAddress + SOCOM1.PlayerDeaths, false);
                            //string mapID = m.ReadString(GameHelper.CURRENT_MAP_ADDRESS, Encoding.Default, false, 4);
                            int sealsRoundsWon = m.Read<byte>(SOCOM1.SEAL_WIN_COUNTER_ADDRESS, false);
                            int terroristRoundsWon = m.Read<byte>(SOCOM1.TERR_WIN_COUNTER_ADDRESS, false);
                            if (!gameStarted)
                            {
                                presenceS1.Timestamps = new Timestamps()
                                {
                                    Start = DateTime.UtcNow

                                };

                                gameStarted = true;
                            }
                            lbl_RPC.Text = "Displaying SOCOM 1";
                            lbl_RPC.ForeColor = Color.FromArgb(192, 90, 20);
                            setPresenceS1(sealsRoundsWon, terroristRoundsWon, kills, deaths);
                        }
                        else
                        {
                            m.Write<byte>(SOCOM1.GAME_ENDED_ADDRESS, new byte[] { 0x00 }, false);
                            resetPresenceS1();
                        }
                    }
                    else
                    {
                        m.Write<byte>(SOCOM1.GAME_ENDED_ADDRESS, new byte[] { 0x00 }, false);
                        resetPresenceS1();
                    }
                }
                catch (Exception)
                {
                    //This only happens if the game isn't actually running but pcsx2 is. It would result in a crash but there's no reason to inform the user
                    resetPresenceS1();
                }
            }

            //SOCOM 2 Discord RPC
            if (CheckBoxS2.Checked)
            {
                try
                {
                    //Check to make sure that the user is even in a game to begin with
                    if ((m.Read<byte>(SOCOM2.PLAYER_POINTER_ADDRESS, 4, false) != null) && (!m.Read<byte>(SOCOM2.PLAYER_POINTER_ADDRESS, 4, false).SequenceEqual(new byte[] { 0, 0, 0, 0 })))
                    {
                        if (m.Read<byte>(SOCOM2.GAME_ENDED_ADDRESS, false) == 0)
                        {
                            IntPtr playerObjectAddress = new IntPtr(m.Read<int>(SOCOM2.PLAYER_POINTER_ADDRESS, false)).OffsetToPlaystationMemory();
                            short kills = m.Read<short>(playerObjectAddress + SOCOM2.PLAYER_KILLS_OFFSET, false);
                            short deaths = m.Read<short>(playerObjectAddress + SOCOM2.PLAYER_DEATHS_OFFSET, false);
                            string mapID = m.ReadString(SOCOM2.CURRENT_MAP_ADDRESS, Encoding.Default, false, 4);
                            //int customMap = m.readByte(GameHelper.CUSTOM_MAP_ADDRESS);
                            int sealsRoundsWon = m.Read<byte>(SOCOM2.SEAL_WIN_COUNTER_ADDRESS, false);
                            int terroristRoundsWon = m.Read<byte>(SOCOM2.TERRORIST_WIN_COUNTER_ADDRESS, false);
                            if (!gameStarted)
                            {
                                presenceS2.Timestamps = new Timestamps()
                                {
                                    Start = DateTime.UtcNow

                                };

                                gameStarted = true;
                            }
                            lbl_RPC.Text = "Displaying SOCOM 2";
                            lbl_RPC.ForeColor = Color.FromArgb(192, 90, 20);
                            setPresenceS2(sealsRoundsWon, terroristRoundsWon, mapID, kills, deaths);
                        }
                        else
                        {
                            m.Write<byte>(SOCOM2.GAME_ENDED_ADDRESS, new byte[] { 0x00 }, false);
                            resetPresenceS2();
                        }
                    }
                    else
                    {
                        m.Write<byte>(SOCOM2.GAME_ENDED_ADDRESS, new byte[] { 0x00 }, false);
                        resetPresenceS2();
                    }
                }
                catch (Exception)
                {
                    //This only happens if the game isn't actually running but pcsx2 is. It would result in a crash but there's no reason to inform the user
                    resetPresenceS2();
                }
            }

            //SOCOM 3 Discord RPC (MISSING VITAL INFORMATION | Game End Address and Team Win Counters)
            if (CheckBoxS3.Checked)
            {
                if ((m.Read<byte>(SOCOM3.PLAYER_POINTER_ADDRESS, 4, false) != null) && (!m.Read<byte>(SOCOM3.PLAYER_POINTER_ADDRESS, 4, false).SequenceEqual(new byte[] { 0, 0, 0, 0 })))
                {
                    IntPtr playerObjectAddress = new IntPtr(m.Read<int>(SOCOM3.PLAYER_POINTER_ADDRESS, false)).OffsetToPlaystationMemory();
                    short PlayerKills = m.Read<short>(playerObjectAddress + SOCOM3.PlayerKills, false);
                    short PlayerDeaths = m.Read<short>(playerObjectAddress + SOCOM3.PlayerDeaths, false);
                    //int sealsRoundsWon = m.Read<byte>(SOCOM3.SEAL_WIN_COUNTER_ADDRESS, false);
                    //int terroristRoundsWon = m.Read<byte>(SOCOM3.TERR_WIN_COUNTER_ADDRESS, false);
                    if (!gameStarted)
                    {
                        presenceS3.Timestamps = new Timestamps()
                        {
                            Start = DateTime.UtcNow
                        };

                        gameStarted = true;
                    }
                    lbl_RPC.Text = "Displaying SOCOM 3";
                    lbl_RPC.ForeColor = Color.FromArgb(192, 90, 20);
                    setPresenceS3(PlayerKills, PlayerDeaths);
                }
            }

            //SOCOM Combined Assault Discord RPC
            if (CheckBoxCA.Checked)
            {
                //Check to make sure that the user is even in a game to begin with
                if ((m.Read<byte>(SocomCA.PLAYER_POINTER_ADDRESS, 4, false) != null) && (!m.Read<byte>(SocomCA.PLAYER_POINTER_ADDRESS, 4, false).SequenceEqual(new byte[] { 0, 0, 0, 0 })))
                {
                    if (m.Read<byte>(SocomCA.GAME_ENDED_ADDRESS, false) == 0)
                    {
                        //string roomName = ByteConverstionHelper.convertBytesToString(m.Read<byte>(GameHelper.ROOM_NAME_ADDRESS, 22, false));
                        string roomName = m.ReadString(SocomCA.ROOM_NAME_ADDRESS, Encoding.Default, false, 4);
                        IntPtr playerObjectAddress = new IntPtr(m.Read<int>(SocomCA.PLAYER_POINTER_ADDRESS, false)).OffsetToPlaystationMemory();
                        short PlayerKills = m.Read<short>(playerObjectAddress + SocomCA.PlayerKills, false);
                        short PlayerDeaths = m.Read<short>(playerObjectAddress + SocomCA.PlayerDeaths, false);
                        string mapID = m.ReadString(SocomCA.CURRENT_MAP_ADDRESS, Encoding.Default, false, 4);
                        int sealsRoundsWon = m.Read<byte>(SocomCA.SEAL_WIN_COUNTER_ADDRESS, false);
                        int terroristRoundsWon = m.Read<byte>(SocomCA.MERC_WIN_COUNTER_ADDRESS, false);
                        if (!gameStarted)
                        {
                            presenceCA.Timestamps = new Timestamps()
                            {
                                Start = DateTime.UtcNow

                            };

                            gameStarted = true;
                        }
                        setPresenceCA(sealsRoundsWon, terroristRoundsWon, PlayerKills, PlayerDeaths, mapID);
                        lbl_RPC.Text = "Displaying SOCOM CA";
                        lbl_RPC.ForeColor = Color.FromArgb(192, 90, 20);
                    }
                    else
                    {
                        m.Write<byte>(SocomCA.GAME_ENDED_ADDRESS, new byte[] { 0x00 }, false);
                        presenceCA.Timestamps = null;
                        setPresenceCA(-1, -1, -1, -1, "NONE");
                        gameStarted = false;
                    }
                }
                else
                {
                    m.Write<byte>(SocomCA.GAME_ENDED_ADDRESS, new byte[] { 0x00 }, false);
                    presenceCA.Timestamps = null;
                    setPresenceCA(-1, -1, -1, -1, "NONE");
                    gameStarted = false;
                }
            }
        }
    }
}
