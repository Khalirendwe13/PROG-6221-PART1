using System;
using System.IO;

namespace CyberAwarenessBot.Tools
{
    // Helper to write a recorded WAV from a base64 string into assets/greeting.wav.
    // Replace the BASE64_WAV constant or call Write with your own base64 string.
    public static class WriteGreetingFromBase64
    {
        // Optional: embed a small placeholder base64 (empty string) to avoid large diffs.
        private const string BASE64_WAV = "";

        public static void Write(string base64, string outPath = "assets/greeting.wav")
        {
            if (string.IsNullOrWhiteSpace(base64)) throw new ArgumentException("base64 must not be empty.", nameof(base64));

            Directory.CreateDirectory(Path.GetDirectoryName(outPath) ?? "assets");
            byte[] data = Convert.FromBase64String(base64);
            File.WriteAllBytes(outPath, data);
            Console.WriteLine($"Wrote greeting WAV: {outPath} ({data.Length} bytes)");
        }

        // Convenience overload that uses the embedded constant if present.
        public static void Write(string outPath = "assets/greeting.wav")
        {
            if (string.IsNullOrWhiteSpace(BASE64_WAV)) throw new InvalidOperationException("No embedded base64 WAV is provided. Use Write(string base64, string outPath) instead.");
            Write(BASE64_WAV, outPath);
        }
    }
}                   