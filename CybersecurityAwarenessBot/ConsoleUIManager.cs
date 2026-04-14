using System;
using System.Threading;

namespace CybersecurityAwarenessBot
{
    /// <summary>
    /// Handles all console UI formatting, colors, ASCII art, and visual elements
    /// </summary>
    public static class ConsoleUIManager
    {
        private static readonly ConsoleColor HeaderColor = ConsoleColor.Cyan;
        private static readonly ConsoleColor BotColor = ConsoleColor.Green;
        private static readonly ConsoleColor UserPromptColor = ConsoleColor.Yellow;
        private static readonly ConsoleColor ErrorColor = ConsoleColor.Red;
        private static readonly ConsoleColor InfoColor = ConsoleColor.Magenta;

        /// <summary>
        /// Displays ASCII art cybersecurity logo (Assignment requirement 2)
        /// </summary>
        public static void DisplayLogo()
        {
            Console.ForegroundColor = HeaderColor;
            Console.WriteLine(@"
╔══════════════════════════════════════════════════════════════╗
║                                                              ║
║    🛡️  CYBERSECURITY AWARENESS BOT  🛡️                      ║
║                                                              ║
║  Protecting Your Digital Life • Stay Safe Online            ║
║                                                              ║
╚══════════════════════════════════════════════════════════════╝
");
            Console.ResetColor();
            Console.WriteLine();
        }

        /// <summary>
        /// Displays section header with borders (Requirement 6)
        /// </summary>
        public static void DisplaySectionHeader(string title)
        {
            Console.ForegroundColor = HeaderColor;
            Console.WriteLine("\n" + new string('═', 60));
            Console.WriteLine($"  {title.PadRight(58)} ║");
            Console.WriteLine(new string('═', 60));
            Console.ResetColor();
            Console.WriteLine();
        }

        /// <summary>
        /// Displays divider
        /// </summary>
        public static void DisplayDivider()
        {
            Console.ForegroundColor = HeaderColor;
            Console.WriteLine(new string('─', 60));
            Console.ResetColor();
        }

        /// <summary>
        /// Displays bot message with green color (Requirement 6)
        /// </summary>
        public static void DisplayBotMessage(string message)
        {
            Console.ForegroundColor = BotColor;
            Console.WriteLine($"🤖 Bot: {message}");
            Console.ResetColor();
        }

        /// <summary>
        /// Displays user prompt with yellow color
        /// </summary>
        public static void DisplayUserPrompt(string prompt = "")
        {
            Console.ForegroundColor = UserPromptColor;
            Console.Write($"👤 You{prompt}: ");
            Console.ResetColor();
        }

        /// <summary>
        /// Displays error message in red (Requirement 5)
        /// </summary>
        public static void DisplayError(string message)
        {
            Console.ForegroundColor = ErrorColor;
            Console.WriteLine($"⚠️  {message}");
            Console.ResetColor();
        }

        /// <summary>
        /// Displays info message in magenta
        /// </summary>
        public static void DisplayInfo(string message)
        {
            Console.ForegroundColor = InfoColor;
            Console.WriteLine($"ℹ️  {message}");
            Console.ResetColor();
        }

        /// <summary>
        /// Displays welcome menu with borders (Requirement 6)
        /// </summary>
        public static void DisplayWelcomeMenu()
        {
            Console.ForegroundColor = BotColor;
            Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
            Console.WriteLine("║              Select a Cybersecurity Topic             ║");
            Console.WriteLine("╠═══════════════════════════════════════════════════════╣");
            Console.WriteLine("║  1. Password Safety                                   ║");
            Console.WriteLine("║  2. Phishing Awareness                                ║");
            Console.WriteLine("║  3. Safe Browsing                                     ║");
            Console.WriteLine("║                                                       ║");
            Console.WriteLine("║  'help'  - Show commands                              ║");
            Console.WriteLine("║  'exit'  - Quit chatbot                               ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════╝");
            Console.ResetColor();
        }

        /// <summary>
        /// Typing effect for conversational feel (Requirement 6)
        /// </summary>
        public static void TypeMessage(string message, int delayMs = 20)
        {
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(delayMs);
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Displays formatted list
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

