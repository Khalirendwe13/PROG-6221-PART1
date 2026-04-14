using System;
using System.IO;
using System.Threading.Tasks;

namespace CyberAwarenessBot
{
    /// <summary>
    /// Manages audio greeting files and playback with support for both TTS-generated
    /// and user-recorded greetings.
    /// </summary>
    public static class AudioGreetingManager
    {
        private const string AssetsDirectory = "assets";
        private const string GreetingFileName = "greeting.wav";
        private const string CustomGreetingFileName = "custom_greeting.wav";

        static AudioGreetingManager()
        {
            // Ensure assets directory exists
            if (!Directory.Exists(AssetsDirectory))
            {
                Directory.CreateDirectory(AssetsDirectory);
            }
        }

        /// <summary>
        /// Gets the path to the main greeting file.
        /// </summary>
        public static string GetGreetingPath()
        {
            return Path.Combine(AssetsDirectory, GreetingFileName);
        }

        /// <summary>
        /// Gets the path to a custom recorded greeting file.
        /// </summary>
        public static string GetCustomGreetingPath()
        {
            return Path.Combine(AssetsDirectory, CustomGreetingFileName);
        }

        /// <summary>
        /// Checks if a greeting file exists at the specified path.
        /// </summary>
        public static bool GreetingExists(string? path = null)
        {
            path ??= GetGreetingPath();
            return File.Exists(path) && new FileInfo(path).Length > 44; // At least header size
        }

        /// <summary>
        /// Checks if a custom greeting has been recorded.
        /// </summary>
        public static bool HasCustomGreeting()
        {
            return GreetingExists(GetCustomGreetingPath());
        }

        /// <summary>
        /// Gets the size of a greeting file in bytes.
        /// </summary>
        public static long GetGreetingFileSize(string? path = null)
        {
            path ??= GetGreetingPath();
            try
            {
                if (File.Exists(path))
                {
                    return new FileInfo(path).Length;
                }
            }
            catch
            {
                // ignore errors
            }
            return 0;
        }

        /// <summary>
        /// Plays the greeting file asynchronously.
        /// </summary>
        public static async Task<bool> PlayGreetingAsync(string? path = null)
        {
            path ??= GetGreetingPath();

            try
            {
                if (!GreetingExists(path))
                {
                    return false;
                }

                await ConsoleUI.TryPlayGreetingAsync(path);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Plays a custom greeting if available, otherwise plays the default greeting.
        /// </summary>
        public static async Task<bool> PlayCustomOrDefaultGreetingAsync()
        {
            try
            {
                // Try custom first
                if (HasCustomGreeting())
                {
                    return await PlayGreetingAsync(GetCustomGreetingPath());
                }

                // Fall back to default
                return await PlayGreetingAsync(GetGreetingPath());
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Clears the custom greeting file.
        /// </summary>
        public static bool ClearCustomGreeting()
        {
            try
            {
                string customPath = GetCustomGreetingPath();
                if (File.Exists(customPath))
                {
                    File.Delete(customPath);
                    return true;
                }
                return true; // Already cleared
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Gets estimated duration of a WAV file in seconds.
        /// </summary>
        public static double EstimateGreetingDuration(string? path = null)
        {
            path ??= GetGreetingPath();
            try
            {
                if (!File.Exists(path))
                {
                    return 0;
                }

                var fileInfo = new FileInfo(path);
                // Standard WAV: 44100 Hz, 16-bit, mono = 88,200 bytes per second
                long dataSize = fileInfo.Length - 44; // subtract WAV header
                if (dataSize > 0)
                {
                    return dataSize / 88200.0;
                }
            }
            catch
            {
                // ignore errors
            }
            return 0;
        }

        /// <summary>
        /// Gets information about the greeting file.
        /// </summary>
        public static GreetingInfo GetGreetingInfo(string? path = null)
        {
            path ??= GetGreetingPath();
            return new GreetingInfo
            {
                Path = path,
                Exists = GreetingExists(path),
                FileSize = GetGreetingFileSize(path),
                EstimatedDuration = EstimateGreetingDuration(path),
                LastModified = File.Exists(path) ? new FileInfo(path).LastWriteTime : null,
                IsCustom = path == GetCustomGreetingPath()
            };
        }
    }

    /// <summary>
    /// Information about a greeting file.
    /// </summary>
    public class GreetingInfo
    {
        public string? Path { get; set; }
        public bool Exists { get; set; }
        public long FileSize { get; set; }
        public double EstimatedDuration { get; set; }
        public DateTime? LastModified { get; set; }
        public bool IsCustom { get; set; }

        public override string ToString()
        {
            return $"GreetingInfo {{ Path={Path}, Exists={Exists}, Size={FileSize} bytes, Duration≈{EstimatedDuration:F1}s, Modified={LastModified}, Custom={IsCustom} }}";
        }
    }
}
