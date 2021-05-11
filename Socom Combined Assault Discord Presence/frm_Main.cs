using DiscordRPC;
using Binarysharp.MemoryManagement;
using Tools.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Socom_Combined_Assault_Discord_Presence
{
    public partial class frm_Main : Form
    {
        private const string PCSX2PROCESSNAME = "pcsx2";
        bool pcsx2Running;
        MemorySharp m = null;
        bool gameStarted = false;
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
        public DiscordRpcClient client;

        public frm_Main()
        {
            InitializeComponent();
            client = new DiscordRpcClient("662019219030016001");

            client.Initialize();
            client.SetPresence(presence);
        }

        //ORIGINAL 
        // private void setPresence(string roomName, int sealWins, int mercWins, string mapID)
        private void setPresence(int sealWins, int mercWins, short PlayerKills, short PlayerDeaths, string mapID)
        {

            MapDataModel mapInfo = GameHelper.mapInfo.Find(x => x._mapID.ToUpper() == mapID.ToUpper());

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
            }
            else
            {
                lbl_PCSX2.Text = "Waiting for PCSX2...";
                lbl_PCSX2.ForeColor = Color.FromArgb(120, 120, 120);
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
            //Check to make sure that the user is even in a game to begin with
            if ((m.Read<byte>(GameHelper.PLAYER_POINTER_ADDRESS, 4, false) != null) && (!m.Read<byte>(GameHelper.PLAYER_POINTER_ADDRESS, 4, false).SequenceEqual(new byte[] { 0, 0, 0, 0 })))
            {
                if (m.Read<byte>(GameHelper.GAME_ENDED_ADDRESS, false) == 0)
                {
                    //string roomName = ByteConverstionHelper.convertBytesToString(m.Read<byte>(GameHelper.ROOM_NAME_ADDRESS, 22, false));
                    string roomName = m.ReadString(GameHelper.ROOM_NAME_ADDRESS, Encoding.Default, false, 4);
                    IntPtr playerObjectAddress = new IntPtr(m.Read<int>(GameHelper.PLAYER_POINTER_ADDRESS, false)).OffsetToPlaystationMemory();
                    short PlayerKills = m.Read<short>(playerObjectAddress + GameHelper.PlayerKills, false);
                    short PlayerDeaths = m.Read<short>(playerObjectAddress + GameHelper.PlayerDeaths, false);
                    string mapID = m.ReadString(GameHelper.CURRENT_MAP_ADDRESS, Encoding.Default, false, 4);
                    int sealsRoundsWon = m.Read<byte>(GameHelper.SEAL_WIN_COUNTER_ADDRESS, false);
                    int terroristRoundsWon = m.Read<byte>(GameHelper.MERC_WIN_COUNTER_ADDRESS, false);
                    if (!gameStarted)
                    {
                        presence.Timestamps = new Timestamps()
                        {
                            Start = DateTime.UtcNow

                        };

                        gameStarted = true;
                    }
                    setPresence(sealsRoundsWon, terroristRoundsWon, PlayerKills, PlayerDeaths, mapID);
                }
                else
                {
                    m.Write<byte>(GameHelper.GAME_ENDED_ADDRESS, new byte[] { 0x00 }, false);
                    presence.Timestamps = null;
                    setPresence(-1, -1, -1, -1, "NONE");
                    gameStarted = false;
                }
            }
            else
            {
                m.Write<byte>(GameHelper.GAME_ENDED_ADDRESS, new byte[] { 0x00 }, false);
                presence.Timestamps = null;
                setPresence(-1, -1, -1, -1, "NONE");
                gameStarted = false;
            }
           
        }
    }
}
