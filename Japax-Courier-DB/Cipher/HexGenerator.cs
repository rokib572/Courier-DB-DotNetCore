using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Japax_Courier_DB.Cipher
{
    public class HexGenerator
    {
        public string Generate_StringToHex(string InputText)
        {
            byte[] ba = Encoding.Default.GetBytes(InputText);
            var hexString = BitConverter.ToString(ba);
            hexString = hexString.Replace("-", "");
            return hexString;
        }
    }
}
