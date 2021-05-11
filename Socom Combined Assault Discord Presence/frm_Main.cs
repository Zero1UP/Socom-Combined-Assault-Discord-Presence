using System;
using DiscordRPC;
using System.Drawing;
using System.Linq;
using System.Text;
using Binarysharp.MemoryManagement;
using System.Windows.Forms;
using System.Diagnostics;

namespace SOCOM_CA_Discord_Presence
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// MemorySharp //Start
        /// </summary>
        MemorySharp m = null;
        private const string PCSX2PROCESSNAME = "pcsx2";
        bool pcsx2Running;

        /// <summary>
        /// Discord Presence //Start
        /// </summary>

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

        public Form1()
        {
            InitializeComponent();
            client = new DiscordRpcClient("");
            client.Initialize();
            client.SetPresence(presence);
        }

        private void setPresence(string roomName, int sealWins, int mercWins)
        {
            if (sealWins == -1 && mercWins == -1)
            {
                presence.Details = "Not currently in a game.";
            }
            else
            {
                presence.Details = "Seals: " + sealWins.ToString() + " || Mercs: " + mercWins.ToString();
            }
            presence.State = "Room: " + roomName;
            presence.Assets = new Assets();
            presence.Assets.LargeImageKey = "1";
            presence.Assets.SmallImageKey = "green";
            //presence.Assets.LargeImageText =
            //presence.Assets.SmallImageText =
            client.SetPresence(presence);
        }

        private void resetPresence()
        {
            presence.Timestamps = null;
            setPresence("", -1, -1);
            gameStarted = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!pcsx2Running)
            {
                return;
            }
            m = new MemorySharp(Process.GetProcessesByName(PCSX2PROCESSNAME).First());
        }


        private void ProcessTimer_Tick(object sender, EventArgs e)
        {
            Process[] pcsx2 = Process.GetProcessesByName(PCSX2PROCESSNAME);
            if (pcsx2.Length > 0)
            {
                //Color Status +Label Text ON
                pcsx2Status.Text = "PCSX2 CONNECTED";
                pnl_PCSX2Detected.BackColor = Color.FromArgb(75, 100, 0);
                pcsx2Running = true;
                return;
            }
            //Color Status +Label Text OFF
            pcsx2Status.Text = "PCSX2 NOT CONNECTED";
            pnl_PCSX2Detected.BackColor = Color.FromArgb(100, 3, 0);
            pcsx2Running = false;
        }

        private void MemoryTimer_Tick(object sender, EventArgs e)
        {
            if (!pcsx2Running)
            {
                return;
            }
            m = new MemorySharp(Process.GetProcessesByName(PCSX2PROCESSNAME).First());
            try
            {
                if ((m.Read<byte>(GameHelper.PlayerPointer, 4, false) != null) && (!m.Read<byte>(GameHelper.PlayerPointer, 4, false).SequenceEqual(new byte[] { 0, 0, 0, 0 })))
                {
                    if (m.Read<byte>(GameHelper.GameEndAddress, false) == 0)
                    {
                        IntPtr playerObjectAddress = new IntPtr(m.Read<int>(GameHelper.PlayerPointer, false)) + 0x20000000;
                        //string roomName = ByteConverstionHelper.convertBytesToString(m.Read<byte>(GameHelper.RoomName, 22));
                        string roomName = m.ReadString(GameHelper.RoomName, Encoding.Default, false, 4);
                        string mapID = m.ReadString(GameHelper.CurrentMap, Encoding.Default, false, 4);
                        int sealsRoundsWon = m.Read<byte>(GameHelper.SealWins, false);
                        int terroristRoundsWon = m.Read<byte>(GameHelper.MercWins, false);
                        if (!gameStarted)
                        {
                            presence.Timestamps = new Timestamps()
                            {
                                Start = DateTime.UtcNow

                            };

                            gameStarted = true;
                        }
                        setPresence(roomName, sealsRoundsWon, terroristRoundsWon);
                    }
                    else
                    {
                        m.Write<byte>(GameHelper.GameEndAddress, new byte[] { 0x00 }, false);
                        resetPresence();
                    }
                }
                else
                {
                    m.Write<byte>(GameHelper.GameEndAddress, new byte[] { 0x00 }, false);
                    resetPresence();
                }
            }
            catch (Exception)
            {
                //This only happens if the game isn't actually running but pcsx2 is. It would result in a crash but there's no reason to inform the user
                resetPresence();
            }
        }
    }
}
