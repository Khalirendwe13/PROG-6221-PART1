using System;

namespace CybersecurityAwarenessBot
{
    /// <summary>
    /// Handles input validation and user interactions (Learning Unit 1 requirement)
    /// </summary>
    public static class InputManager
    {
        /// <summary>
        /// Gets user name with validation
        /// </summary>
        public static string GetUserName()
        {
            while (true)
            {
                ConsoleUIManager.DisplayUserPrompt("What's your name? ");
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
            return Console.ReadLine() ?? "";
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
            return input.Trim().Equals("exit", StringComparison.OrdinalIgnoreCase) ||
                   input.Trim().Equals("quit", StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Checks if user wants help
        /// </summary>
        public static bool IsHelpCommand(string input)
        {
            string trimmed = input.Trim().ToLower();
            return trimmed == "help" || trimmed == "?" || trimmed == "commands";
        }
    }
}

