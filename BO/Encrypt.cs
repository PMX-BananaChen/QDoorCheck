using System;
using System.Collections.Generic;
using System.Text;
using Utility.Common;

namespace BO
{
    class Encrypt
    {
        private static readonly string pwdKey = "QDoorCheck";
        private static EncryptionUtil encrypt = new EncryptionUtil(pwdKey);

        public static string DoEncrypt(string inStr)
        {
            lock (encrypt)
            {
                return encrypt.EncryptData(string.IsNullOrEmpty(inStr) ? string.Empty : inStr);
            }
        }

        public static string DoDecrypt(string inStr)
        {
            lock (encrypt)
            {
                return encrypt.DecryptData(inStr);
            }
        }
    }
}
