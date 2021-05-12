using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socom_Combined_Assault_Discord_Presence
{
    public class MapDataModelS2
    {
        public string _mapID;
        public string _mapName;
        public string _discordKey;
        public string _altMapID;
        public string _altMapName;
        public string _altDiscordKey;

        public MapDataModelS2(string mapID, string mapName, string discordID, string altMapID, string altMapName, string altDiscordKey)
        {
            _mapID = mapID;
            _mapName = mapName;
            _discordKey = discordID;
            _altMapID = altMapID;
            _altMapName = altMapName;
            _altDiscordKey = altDiscordKey;
        }
    }
}
