using System;

namespace CyberAwarenessBot
{
    /// <summary>
    /// Handles input validation and user interactions
    /// </summary>
    public class InputManager
    {
        /// <summary>
        /// Gets user name with validation
        /// </summary>
        public static string GetUserName()
        {
            while (true)
            {
                ConsoleUIManager.DisplayUserPrompt();
                string input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input))
                {
                    return input.Trim();
                }

                ConsoleUIManager.DisplayError("Please enter a valid name.");
            }
        }

        /// <summary>
        /// Gets user input with basic validation
        /// </summary>
        public static string GetUserInput()
        {
            ConsoleUIManager.DisplayUserPrompt();
            return Console.ReadLine();
        }

        /// <summary>
        /// Validates if input is not empty or just whitespace
        /// </summary>
        public static bool IsValidInput(string input)
        {
            return !string.IsNullOrWhiteSpace(input);
        }

        /// <summary>
        /// Checks if user wants to exit
        /// </summary>
        public static bool IsExitCommand(string input)
        {
            return input.Equals("exit", StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Checks if user wants help
        /// </summary>
        public static bool IsHelpCommand(string input)
        {
            return input.Equals("help", StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Checks if input is a valid menu choice
        /// </summary>
        public static bool IsValidMenuChoice(string input)
        {
            return input == "1" || input == "2" || input == "3" || 
                   IsHelpCommand(input) || IsExitCommand(input);
        }
    }
}
