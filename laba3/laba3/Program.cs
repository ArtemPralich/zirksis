using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;

namespace laba3
{
    class Program
    {
        static void Main(string[] args)
        {
            Chilkat.Crypt2 crypt = new Chilkat.Crypt2();
            crypt.CryptAlgorithm = "3des";
            crypt.CipherMode = "ecb";
            crypt.KeyLength = 128;
            crypt.PaddingScheme = 3;
            crypt.EncodingMode = "hex";
            crypt.HashAlgorithm = "md5";
            string keyHex = crypt.HashStringENC("secretPassword");
            crypt.SetEncodedKey(keyHex, "hex");

            
            string encStr = crypt.EncryptStringENC(ReadFile("C:\\study\\zirksis\\laba3\\laba3\\file.txt"));
            Console.WriteLine(encStr);

            // Now decrypt:
            string decStr = crypt.DecryptStringENC(encStr);
            Console.WriteLine(decStr);
        }

        public static string ReadFile(string filePath)
        {
            string text = "";
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    text = reader.ReadToEnd();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }

            return text;
        }
    }
}
