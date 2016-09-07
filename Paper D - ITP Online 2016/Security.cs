using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Paper_D___ITP_Online_2016
{
    class Security
    {
        public static string Encrypt(string input)
        {
            MD5CryptoServiceProvider x = new MD5CryptoServiceProvider();
            byte[] bs = Encoding.UTF8.GetBytes(input);
            bs = x.ComputeHash(bs);
            StringBuilder s = new StringBuilder();
            foreach (byte b in bs)
                s.Append(b.ToString("x2").ToLower());
            return s.ToString();
        }
    }
}
