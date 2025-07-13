using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Password_Manager
{
    public class Encryption_Utility
    {
        private static readonly string Original = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        private static readonly string Alternative = "QWERT0YUIOP2ASDFG3HJKLZ4XCVBN5M6qwert7yuiop8asdfg9hjklzxcvbnm";
        public static string Encrypt(string Password)
        {
            var sb = new StringBuilder();
            foreach (var Char in Password)
            {
                var Char_Index = Original.IndexOf(Char);
                sb.Append(Alternative[Char_Index]);
            }
            return sb.ToString();
        }
        public static string Decrypt(string Password)
        {
            var sb = new StringBuilder();
            foreach (var Char in Password)
            {
                var Char_Index = Alternative.IndexOf(Char);
                sb.Append(Original[Char_Index]);
            }
            return sb.ToString();

        }
    }
}
