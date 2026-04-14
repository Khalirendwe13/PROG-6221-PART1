using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace CyberAwarenessBot
{
    /// <summary>
    /// Handles voice synthesis and playback of bot responses.
    /// Uses System.Speech.Synthesis via reflection to avoid compile-time dependency.
    /// </summary>
    public static class VoiceResponseHandler
    {
        private static string? _preferredVoice;

        public static void SetPreferredVoice(string? voiceName)
        {
            _preferredVoice = voiceName;
        }

        /// <summary>
        /// Synthesize and play a bot response as audio.
        /// </summary>
        public static async Task SynthesizeAndPlayResponseAsync(string responseText, bool enableVoice = true)
        {
            if (!enableVoice || string.IsNullOrWhiteSpace(responseText))
                return;

            try
            {
                string tempWavPath = Path.Combine("assets", "temp_response.wav");
                Directory.CreateDirectory("assets");

                // Try to synthesize using System.Speech
                if (!SynthesizeResponse(responseText, tempWavPath))
                {
                    return; // Synthesis failed, just skip voice
                }

                // Play the synthesized response
                if (File.Exists(tempWavPath) && new FileInfo(tempWavPath).Length > 44)
                {
                    await PlayAudioAsync(tempWavPath);

                    // Clean up temp file after playback
                    try
                    {
                        await Task.Delay(500); // Small delay to ensure file isn't locked
                        File.Delete(tempWavPath);
                    }
                    catch
                    {
                        // Ignore cleanup errors
                    }
                }
            }
            catch
            {
                // Silently fail - voice is optional
            }
        }

        private static bool SynthesizeResponse(string text, string outputPath)
        {
            try
            {
                // Load System.Speech assembly
                Assembly? asm = null;
                try
                {
                    asm = Assembly.Load("System.Speech");
                }
                catch
                {
                    return false;
                }

                if (asm == null)
                    return false;

                var synthType = asm.GetType("System.Speech.Synthesis.SpeechSynthesizer");
                if (synthType == null)
                    return false;

                object? synth = Activator.CreateInstance(synthType);
                if (synth == null)
                    return false;

                var setOutput = synthType.GetMethod("SetOutputToWaveFile", new Type[] { typeof(string) });
                var selectVoice = synthType.GetMethod("SelectVoice", new Type[] { typeof(string) });
                var speak = synthType.GetMethod("Speak", new Type[] { typeof(string) });

                if (setOutput == null || speak == null)
                    return false;

                // Set output to WAV file
                setOutput.Invoke(synth, new object[] { outputPath });

                // Try to select preferred voice if available
                if (!string.IsNullOrWhiteSpace(_preferredVoice) && selectVoice != null)
                {
                    try
                    {
                        selectVoice.Invoke(synth, new object[] { _preferredVoice });
                    }
                    catch
                    {
                        // Voice not available, continue with default
                    }
                }

                // Synthesize the text
                speak.Invoke(synth, new object[] { text });

                // Dispose
                if (synth is IDisposable disposable)
                    disposable.Dispose();

                return true;
            }
            catch
            {
                return false;
            }
        }

        private static async Task PlayAudioAsync(string path)
        {
            try
            {
                if (!File.Exists(path))
                    return;

                // Only attempt playback on Windows
                if (!System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(
                    System.Runtime.InteropServices.OSPlatform.Windows))
                    return;

                using var player = new System.Media.SoundPlayer(path);
                player.Play();
                await Task.Delay(500); // Give audio time to play
            }
            catch
            {
                // Silently fail
            }
        }

        /// <summary>
        /// List all installed voices on the system.
        /// </summary>
        public static void ListInstalledVoices()
        {
            try
            {
                Assembly? asm = Assembly.Load("System.Speech");
                if (asm == null)
                {
                    Console.WriteLine("System.Speech assembly not found.");
                    return;
                }

                var synthType = asm.GetType("System.Speech.Synthesis.SpeechSynthesizer");
                if (synthType == null)
                    return;

                object? synth = Activator.CreateInstance(synthType);
                if (synth == null)
                    return;

                var getInstalledVoices = synthType.GetMethod("GetInstalledVoices", Type.EmptyTypes);
                var voices = getInstalledVoices?.Invoke(synth, null) as System.Collections.IEnumerable;

                if (voices == null)
                {
                    Console.WriteLine("No voices found.");
                    return;
                }

                Console.WriteLine("\nAvailable Voices:");
                int count = 0;
                foreach (var v in voices)
                {
                    var vType = v.GetType();
                    var voiceInfoProp = vType.GetProperty("VoiceInfo");
                    var voiceInfo = voiceInfoProp?.GetValue(v);
                    var infoType = voiceInfo?.GetType();
                    var nameProp = infoType?.GetProperty("Name");
                    var name = nameProp?.GetValue(voiceInfo) as string;

                    if (!string.IsNullOrWhiteSpace(name))
                    {
                        Console.WriteLine($"  - {name}");
                        count++;
                    }
                }

                if (count == 0)
                    Console.WriteLine("  (No voices available)");

                if (synth is IDisposable disposable)
                    disposable.Dispose();
            }
            catch
            {
                Console.WriteLine("Error listing voices.");
            }
        }
    }
}
