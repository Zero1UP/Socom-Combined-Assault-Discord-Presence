
using System;

namespace SOCOM_CA_Discord_Presence
{
    public static class GameHelper
    {
        //Patch 1.0
        public static IntPtr PlayerPointer = new IntPtr(0x206FEB08);
        public static IntPtr GameEndAddress = new IntPtr(0x20948264);
        public static IntPtr CurrentMap = new IntPtr(0x20783B78);
        public static IntPtr SealWins = new IntPtr(0x20ccddac);
        public static IntPtr MercWins = new IntPtr(0x20CCDDB4);
        public static IntPtr RoomName = new IntPtr(0x20C3D9A8);

        //Patch1.4

    }
}
