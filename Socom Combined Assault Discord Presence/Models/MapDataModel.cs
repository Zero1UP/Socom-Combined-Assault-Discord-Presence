using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socom_Combined_Assault_Discord_Presence
{
    public class MapDataModel
    {
        public string _mapID;
        public string _mapName;
        public string _discordKey;

        public MapDataModel(string mapID, string mapName, string discordID)
        {
            _mapID = mapID;
            _mapName = mapName;
            _discordKey = discordID;
        }
    }
}
