using System;
using System.IO;
using Chilkat;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        
        const string fileName = "input.txt";
        const string filePath = "./../../../";
        static void Main(string[] args)
        {

            Crypt2 crypt = new Crypt2();
            crypt.EncodingMode = "hex";
            crypt.HashAlgorithm = "md2";

            List<string> lines = ReadFile(filePath + fileName);
            List<string> hashes = new List<string>();

            foreach (var line in lines)
            {
                var hash1 = crypt.HashStringENC(line);
                hashes.Add(hash1);
                Console.Write(hash1);
                Console.Write(" - ");
                Console.WriteLine(line);
            }
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("");
            Console.Write("Enter str: ");
            var str = Console.ReadLine();

            var hash = crypt.HashStringENC(str);
            Console.WriteLine("MD2: " + hash);

            if (hashes.Contains(hash))
                Console.WriteLine(str + " contains in file");
            else
                Console.WriteLine(str + " not contains in file");
        }

        public static List<string> ReadFile(string fileName)
        {
            List<string> strs = new List<string>();
            strs.AddRange(File.ReadAllLines(fileName));
            return strs;
        }
    }
}
