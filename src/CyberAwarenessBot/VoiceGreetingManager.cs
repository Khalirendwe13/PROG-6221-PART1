using System;
using System.IO;
using System.Media;

namespace CyberAwarenessBot
{
    /// <summary>
    /// Handles audio playback for voice greetings
    /// </summary>
    public class VoiceGreetingManager
    {
        private readonly string _audioFilePath;

        public VoiceGreetingManager(string audioFileName = "greeting.wav")
        {
            _audioFilePath = Path.Combine(Directory.GetCurrentDirectory(), audioFileName);
        }

        /// <summary>
        /// Plays the voice greeting if the audio file exists
        /// </summary>
        public void PlayGreeting()
        {
            ConsoleUIManager.DisplayInfo("Playing voice greeting...");

            if (File.Exists(_audioFilePath))
            {
                try
                {
                    SoundPlayer player = new SoundPlayer(_audioFilePath);
                    player.PlaySync();
                    ConsoleUIManager.DisplayInfo("Voice greeting played successfully!");
                }
                catch (Exception ex)
                {
                    ConsoleUIManager.DisplayError($"Could not play audio file: {ex.Message}");
                    Console.WriteLine("Continuing with text greeting...\n");
                }
            }
            else
            {
                ConsoleUIManager.DisplayInfo($"Audio file not found at: {_audioFilePath}");
                Console.WriteLine("To add voice greeting, record a WAV file and place it in the project directory.\n");
            }
        }

        /// <summary>
        /// Gets the expected audio file path
        /// </summary>
        public string GetAudioFilePath()
        {
            return _audioFilePath;
        }

        /// <summary>
        /// Checks if audio file exists
        /// </summary>
        public bool AudioFileExists()
        {
            return File.Exists(_audioFilePath);
        }
    }
}
