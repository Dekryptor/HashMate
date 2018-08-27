using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using System.Threading;


namespace HashMate
{
    class Program
    {
        static string passBook = @"rockyou.txt";
        static string[] allPass = File.ReadAllLines(passBook);

        static string Hash;
        static string Password;
        static int Count = 0;
        static bool loop = true;

        static void Main(string[] args)
        {
            Console.WriteLine("Enter your MD5 hash");
            Console.Write("> ");
            Hash = Console.ReadLine();
            if (loop == true)
            {
                foreach (string pass in allPass)
                {
                    Count++;
                    string hashed = CalculateMD5Hash(pass);
                    if (Hash == hashed)
                    {
                        HaskFound(pass);
                        loop = false;
                    }
                }
            }
            else
            {
                HashNotFound();
                loop = false;
            }
        }


        private static void HaskFound(string password)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Hash has beeen found\n");

            Console.WriteLine("Hash: " + Hash);
            Console.WriteLine("Password: " + password);
            Console.WriteLine("Count: " + Count);
            Console.WriteLine("\n");
            

            Console.WriteLine("Press any button to exit");
            Console.ReadKey();
            Environment.Exit(1);
        }

        private static void HashNotFound()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Hash not found");
            Console.WriteLine("Press any button to exit");
            Console.ReadKey();
            Environment.Exit(1);
        }

        public static string CalculateMD5Hash(string input)
        {

            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));

            }
            return sb.ToString();

        }


    }
}
