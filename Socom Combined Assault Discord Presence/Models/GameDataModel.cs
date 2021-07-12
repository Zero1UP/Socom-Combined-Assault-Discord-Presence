using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocomRichPresence
{
    public  class GameDataModel
    {
        public string GameCRC { get; set; }
        public string GameName { get; set; }
        public  IntPtr PlayerPointerAddress { get; set; }
        public  IntPtr GameEndedAddress { get; set; }
        public  IntPtr CurrentMapAddress { get; set; }
        public  IntPtr SealWinCounterAddress { get; set; }
        public  IntPtr TerroristWinCounterAddress { get; set; }
        public  IntPtr RoomNameAddress { get; set; }
        public  int PlayerKillsOffset { get; set; }
        public  int PlayerDeathsOffset { get; set; }
        public List<MapDataModel> MapData { get; set; }

    }

}
