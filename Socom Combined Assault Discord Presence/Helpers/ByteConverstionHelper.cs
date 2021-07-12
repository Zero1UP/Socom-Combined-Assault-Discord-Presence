using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocomRichPresence
{
    public static class ByteConverstionHelper
    {
        public static string convertBytesToString(byte[] data)
        {
            if (data != null)
            {
                string result;

                data.Reverse();

                result = Encoding.Default.GetString(data);

                var cleanedString = result.Split(new string[] { "\0" }, StringSplitOptions.None);
                return cleanedString[0].Replace(',', ' ');
            }
            else
            {
                return "";
            }
        }
    }
}
