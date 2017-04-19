using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Security;
using System.Security.Cryptography;
using System.IO;

namespace auction_proj
{
    public class encrypt
    {
        public static string encryptPass(string password)
        {
            byte[] data = Encoding.UTF8.GetBytes(password);
            HashAlgorithm hash = new SHA1Managed();

            byte[] hashBytes = hash.ComputeHash(data);
            string hashValue = Convert.ToBase64String(hashBytes);
            return hashValue;
        }
    }
}