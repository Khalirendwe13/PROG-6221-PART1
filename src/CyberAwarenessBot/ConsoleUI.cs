using System;
using System.Threading;

namespace CyberAwarenessBot
{
    public static class ConsoleUI
    {
        private static readonly string AsciiArt = @"
   ____       _               _                 _   
  / ___|  ___| |__   ___  ___| |_ _ __ ___  ___| |_ 
 | |    / _ \ '_ \ / _ \/ __| __| '__/ _ \/ __| __|
 | |___|  __/ |_) |  __/ (__| |_| | |  __/ (__| |_ 
  \____|\___|_.__/ \___|\___|\__|_|  \___|\___|\__|
";

        public static void ClearAndDrawHeader()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(AsciiArt);
            Console.ResetColor();
            WriteDivider();
        }

        public static void WriteDivider()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(new string('-', 60));
            Console.ResetColor();
        }

        public static void WriteColoredLine(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        public static string ReadNonEmptyLine(string fieldName)
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input)) return input.Trim();
                WriteColoredLine($"{fieldName} cannot be empty. Please try again:", ConsoleColor.Red);
            }
        }

        public static void TypeWrite(string text, int msDelay = 20)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(msDelay);
            }
        }
    }
}