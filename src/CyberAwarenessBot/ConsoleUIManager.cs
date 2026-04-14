using System;
using System.Threading;

namespace CyberAwarenessBot
{
    /// <summary>
    /// Handles all console UI formatting and display operations
    /// </summary>
    public class ConsoleUIManager
    {
        // Color constants for consistent styling
        private static readonly ConsoleColor HeaderColor = ConsoleColor.Cyan;
        private static readonly ConsoleColor BotColor = ConsoleColor.Green;
        private static readonly ConsoleColor UserPromptColor = ConsoleColor.Yellow;
        private static readonly ConsoleColor ErrorColor = ConsoleColor.Red;
        private static readonly ConsoleColor InfoColor = ConsoleColor.Magenta;

        /// <summary>
        /// Displays the ASCII art logo for the chatbot
        /// </summary>
        public static void DisplayLogo()
        {
            Console.ForegroundColor = HeaderColor;
            Console.WriteLine("\n");
            Console.WriteLine("╔════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                                                        ║");
            Console.WriteLine("║       🛡️  CYBERSECURITY AWARENESS BOT  🛡️            ║");
            Console.WriteLine("║                                                        ║");
            Console.WriteLine("║         Stay Safe • Stay Secure • Stay Smart          ║");
            Console.WriteLine("║                                                        ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════╝");
            Console.WriteLine();
            Console.ResetColor();
        }

        /// <summary>
        /// Displays a section header with formatting
        /// </summary>
        public static void DisplaySectionHeader(string title)
        {
            Console.ForegroundColor = HeaderColor;
            Console.WriteLine("\n" + new string('═', 60));
            Console.WriteLine($"  {title}");
            Console.WriteLine(new string('═', 60));
            Console.ResetColor();
            Console.WriteLine();
        }

        /// <summary>
        /// Displays a divider line
        /// </summary>
        public static void DisplayDivider()
        {
            Console.ForegroundColor = HeaderColor;
            Console.WriteLine(new string('─', 60));
            Console.ResetColor();
        }

        /// <summary>
        /// Displays bot message with formatting
        /// </summary>
        public static void DisplayBotMessage(string message)
        {
            Console.ForegroundColor = BotColor;
            Console.WriteLine($"🤖 Bot: {message}");
            Console.ResetColor();
        }

        /// <summary>
        /// Displays user prompt
        /// </summary>
        public static void DisplayUserPrompt()
        {
            Console.ForegroundColor = UserPromptColor;
            Console.Write("👤 You: ");
            Console.ResetColor();
        }

        /// <summary>
        /// Displays an error message
        /// </summary>
        public static void DisplayError(string message)
        {
            Console.ForegroundColor = ErrorColor;
            Console.WriteLine($"⚠️  {message}");
            Console.ResetColor();
        }

        /// <summary>
        /// Displays an info message
        /// </summary>
        public static void DisplayInfo(string message)
        {
            Console.ForegroundColor = InfoColor;
            Console.WriteLine($"ℹ️  {message}");
            Console.ResetColor();
        }

        /// <summary>
        /// Displays welcome menu
        /// </summary>
        public static void DisplayWelcomeMenu()
        {
            Console.ForegroundColor = BotColor;
            Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
            Console.WriteLine("║          Available Topics                             ║");
            Console.WriteLine("╠═══════════════════════════════════════════════════════╣");
            Console.WriteLine("║  1. Password Safety                                   ║");
            Console.WriteLine("║  2. Phishing Awareness                                ║");
            Console.WriteLine("║  3. Safe Browsing                                     ║");
            Console.WriteLine("║                                                       ║");
            Console.WriteLine("║  'help'  - Show available commands                    ║");
            Console.WriteLine("║  'exit'  - Exit the chatbot                           ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════╝");
            Console.ResetColor();
        }

        /// <summary>
        /// Simulates typing effect for messages
        /// </summary>
        public static void TypeMessage(string message, int delayMs = 30)
        {
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(delayMs);
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Clears the console with a delay
        /// </summary>
        public static void ClearConsoleWithDelay(int delayMs = 500)
        {
            Thread.Sleep(delayMs);
            Console.Clear();
        }

        /// <summary>
        /// Displays a formatted list of items
        /// </summary>
        public static void DisplayFormattedList(string[] items)
        {
            Console.ForegroundColor = BotColor;
            foreach (string item in items)
            {
                Console.WriteLine($"  • {item}");
            }
            Console.ResetColor();
        }
    }
}
