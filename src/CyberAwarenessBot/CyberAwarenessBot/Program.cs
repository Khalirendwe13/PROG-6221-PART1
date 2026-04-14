using System;

namespace CyberAwarenessBot
{
    /// <summary>
    /// Main entry point for the Cybersecurity Awareness Chatbot
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize managers
            ConsoleUIManager uiManager = new ConsoleUIManager();
            VoiceGreetingManager voiceManager = new VoiceGreetingManager();
            ResponseManager responseManager = new ResponseManager();
            InputManager inputManager = new InputManager();

            // Display logo
            ConsoleUIManager.DisplayLogo();
            
            // Play voice greeting
            voiceManager.PlayGreeting();

            // Get user name
            Console.WriteLine();
            ConsoleUIManager.DisplayBotMessage("Welcome to the Cybersecurity Awareness Bot!");
            ConsoleUIManager.DisplayBotMessage("Type 'help' to see available commands.");
            Console.WriteLine();
            ConsoleUIManager.DisplayBotMessage("What's your name?");
            string userName = InputManager.GetUserName();
            
            // Create user object
            User currentUser = new User(userName);
            
            // Display welcome message
            Console.WriteLine();
            ConsoleUIManager.DisplayBotMessage(currentUser.GetWelcomeMessage());
            ConsoleUIManager.DisplayDivider();

            // Main interaction loop
            bool running = true;
            while (running)
            {
                Console.WriteLine();
                ConsoleUIManager.DisplayWelcomeMenu();
                
                string userInput = InputManager.GetUserInput();

                // Check for invalid input
                if (!InputManager.IsValidInput(userInput))
                {
                    ConsoleUIManager.DisplayError("I didn't quite understand that. Could you please enter a valid choice.");
                    continue;
                }

                // Check for exit command
                if (InputManager.IsExitCommand(userInput))
                {
                    HandleExit(currentUser);
                    running = false;
                    break;
                }

                // Check for help command
                if (InputManager.IsHelpCommand(userInput))
                {
                    DisplayHelp();
                    continue;
                }

                // Get and display response
                string[] responses = responseManager.GetResponse(userInput);
                
                Console.WriteLine();
                foreach (string response in responses)
                {
                    if (string.IsNullOrEmpty(response))
                    {
                        Console.WriteLine();
                    }
                    else
                    {
                        ConsoleUIManager.DisplayBotMessage(response);
                    }
                }

                // Increment topics if valid menu choice
                if (userInput == "1" || userInput == "2" || userInput == "3")
                {
                    currentUser.IncrementTopicsLearned();
                }
            }
        }

        /// <summary>
        /// Displays help menu with all available commands
        /// </summary>
        static void DisplayHelp()
        {
            Console.WriteLine();
            ConsoleUIManager.DisplaySectionHeader("Available Commands");
            
            string[] helpItems = new[]
            {
                "1 - Learn about Password Safety",
                "2 - Learn about Phishing Awareness",
                "3 - Learn about Safe Browsing",
                "help - Show this help menu",
                "exit - Exit the chatbot",
                "",
                "You can also ask:",
                "• How are you?",
                "• What's your purpose?",
                "• What can I ask you about?"
            };

            ConsoleUIManager.DisplayFormattedList(helpItems);
        }

        /// <summary>
        /// Handles exit procedure
        /// </summary>
        static void HandleExit(User user)
        {
            Console.WriteLine();
            ConsoleUIManager.DisplayBotMessage($"Thank you for chatting with me, {user.Name}!");
            ConsoleUIManager.DisplayBotMessage("Remember: Stay safe online! 🛡️");
            Console.WriteLine();
            ConsoleUIManager.DisplayInfo($"Session Summary: {user.GetUserInfo()}");
            Console.WriteLine();
            ConsoleUIManager.DisplayInfo("Goodbye!");
        }
    }
}
