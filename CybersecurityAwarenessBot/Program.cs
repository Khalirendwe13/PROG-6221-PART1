using System;
using System.Media;
using System.IO;
using System.Threading.Tasks;
using System.Threading;

namespace CybersecurityAwarenessBot
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Assignment Requirement 1: Play voice greeting
            await PlayVoiceGreetingAsync();

            // Requirement 2: Display ASCII logo
            ConsoleUIManager.DisplayLogo();

            // Requirement 3: Text greeting and user interaction
            Console.WriteLine();
            ConsoleUIManager.DisplayBotMessage("Welcome to the Cybersecurity Awareness Bot!");
            ConsoleUIManager.DisplayBotMessage("Type 'help' to see available commands.");
            Console.WriteLine();
            ConsoleUIManager.DisplayBotMessage("What's your name?");

            // Get user name with validation (Requirement 3, 5)
            string userName = InputManager.GetUserName();

            // Create user with automatic properties (Learning Unit 2)
            User currentUser = new User(userName);

            // Personalized welcome (Requirement 3)
            Console.WriteLine();
            ConsoleUIManager.DisplayBotMessage(currentUser.GetWelcomeMessage());
            ConsoleUIManager.DisplayDivider();

            // Main interaction loop (Requirements 4, 5)
            bool running = true;
            while (running)
            {
                ConsoleUIManager.DisplayWelcomeMenu();
                string userInput = InputManager.GetUserInput();

                // Input validation (Requirement 5)
                if (!InputManager.IsValidInput(userInput))
                {
                    ConsoleUIManager.DisplayError("I didn't quite understand that. Could you rephrase?");
                    continue;
                }

                // Exit command
                if (InputManager.IsExitCommand(userInput))
                {
                    HandleExit(currentUser);
                    running = false;
                    continue;
                }

                // Help command
                if (InputManager.IsHelpCommand(userInput))
                {
                    DisplayHelp();
                    continue;
                }

                // Get response using string manipulation (Learning Unit 1)
                ResponseManager responseManager = new ResponseManager();
                string[] responses = responseManager.GetResponse(userInput);

                // Display responses (Requirement 4, 6)
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
                        ConsoleUIManager.TypeMessage(response, 10); // Typing effect (Req 6)
                    }
                }

                // Track topics for menu choices
                if (userInput == "1" || userInput == "2" || userInput == "3")
                {
                    currentUser.IncrementTopicsLearned();
                }
            }
        }

        /// <summary>
        /// Plays voice greeting WAV file (Requirement 1)
        /// Generates placeholder if missing
        /// </summary>
        static async Task PlayVoiceGreetingAsync()
        {
            string greetingPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "greeting.wav");
            
            ConsoleUIManager.DisplayInfo("Playing voice greeting...");

            if (!File.Exists(greetingPath))
            {
                ConsoleUIManager.DisplayInfo("No greeting.wav found - generating placeholder...");
                CreatePlaceholderGreeting(greetingPath);
            }

            try
            {
                using var player = new SoundPlayer(greetingPath);
                player.PlaySync();
                ConsoleUIManager.DisplayInfo("Voice greeting complete!");
            }
            catch (Exception ex)
            {
                ConsoleUIManager.DisplayError($"Audio playback failed: {ex.Message}");
                Console.WriteLine("Continuing with text interface...\n");
            }

            await Task.CompletedTask; // Make Main async
        }

        /// <summary>
        /// Creates a short silent WAV placeholder (1 second)
        /// </summary>
        static void CreatePlaceholderGreeting(string path)
        {
            try
            {
                using var writer = new BinaryWriter(File.OpenWrite(path));
                // RIFF header for 1s silent WAV (8kHz, 16bit mono)
                writer.Write("RIFF".ToCharArray());
                writer.Write(36 + 8000); // File size
                writer.Write("WAVE".ToCharArray());
                writer.Write("fmt ".ToCharArray());
                writer.Write(16); // Subchunk size
                writer.Write((short)1); // PCM
                writer.Write((short)1); // Mono
                writer.Write(8000); // Sample rate
                writer.Write(8000 * 2); // Byte rate
                writer.Write((short)2); // Block align
                writer.Write((short)16); // Bits per sample
                writer.Write("data".ToCharArray());
                writer.Write(8000 * 2); // Data size
                // Silent data (zeros)
                for (int i = 0; i < 8000 * 2; i++)
                    writer.Write((byte)0);
            }
            catch
            {
                // Ignore generation errors
            }
        }

        /// <summary>
        /// Displays help menu (Requirement 4)
        /// </summary>
        static void DisplayHelp()
        {
            ConsoleUIManager.DisplaySectionHeader("Available Commands");
            string[] helpItems = {
                "1 - Password Safety",
                "2 - Phishing Awareness", 
                "3 - Safe Browsing",
                "help / ? / commands - Show this help",
                "exit / quit - Exit chatbot",
                "",
                "Or ask free-text questions:",
                "• How are you?",
                "• What's your purpose?",
                "• What can I ask you about?"
            };
            ConsoleUIManager.DisplayFormattedList(helpItems);
        }

        /// <summary>
        /// Handles graceful exit
        /// </summary>
        static void HandleExit(User user)
        {
            ConsoleUIManager.DisplaySectionHeader("Session Complete");
            ConsoleUIManager.DisplayBotMessage($"Thank you {user.Name}! Stay safe online 🛡️");
            ConsoleUIManager.DisplayInfo(user.GetUserInfo());
            Console.WriteLine();
        }
    }
}

