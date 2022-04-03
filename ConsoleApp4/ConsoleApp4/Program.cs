using System;
using System.IO;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace ConsoleApp4
{
    public class Program
    {
        const string fileName = "input.txt";
        public static void Main(string[] args)
        {
            var str = ReadFile(fileName);
            using (var sha1 = SHA1.Create())
            {
                var byteString = Encoding.ASCII.GetBytes(str);
                var hash = sha1.ComputeHash(byteString);
                //Console.WriteLine(Encoding.Unicode.GetString(hash));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    builder.Append(hash[i].ToString("x2"));
                }
                Console.WriteLine(builder.ToString());

                // BitConverter can also be used to put all bytes into one string  
                string bitString = BitConverter.ToString(hash);
                Console.WriteLine(bitString);

                // UTF conversion - String from bytes  
                string utfString = Encoding.UTF8.GetString(hash, 0, hash.Length);
                Console.WriteLine(utfString);

            //    // ASCII conversion - string from bytes  
            //    string asciiString = Encoding.ASCII.GetString(hash, 0, hash.Length);
            //    Console.WriteLine(asciiString);
            
            }

        } 
        public static string ReadFile(string fileName)
        {
            using (StreamReader fileReader = new StreamReader("./../../../" + fileName))
            {
                return fileReader.ReadToEnd();
            }
        }
    }
}
