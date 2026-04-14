using System;
using System.IO;

namespace CyberAwarenessBot
{
    public static class GreetingGenerator
    {
        // Generates a simple silent WAV file if it doesn't exist. This ensures the app has a compatible WAV to play.
        /// <summary>
        /// Ensure the greeting audio file exists. If missing, create a short silent WAV so the
        /// application has a compatible file to attempt playback. This prevents errors when the
        /// audio asset is not provided in the repository.
        /// </summary>
        public static void EnsureGreetingFileExists(string path, int seconds = 1, int sampleRate = 8000)
        {
            try
            {
                var file = new FileInfo(path);
                if (file.Exists && file.Length > 44) return; // likely valid

                Directory.CreateDirectory(file.DirectoryName ?? "assets");

                using var fs = new FileStream(path, FileMode.Create, FileAccess.Write);
                using var bw = new BinaryWriter(fs);

                short channels = 1;
                short bitsPerSample = 16;
                int byteRate = sampleRate * channels * bitsPerSample / 8;
                int blockAlign = (short)(channels * bitsPerSample / 8);
                int dataSize = sampleRate * channels * bitsPerSample / 8 * seconds;
                int fmtChunkSize = 16;
                int riffChunkSize = 4 + (8 + fmtChunkSize) + (8 + dataSize);

                // RIFF header
                bw.Write(System.Text.Encoding.ASCII.GetBytes("RIFF"));
                bw.Write(riffChunkSize);
                bw.Write(System.Text.Encoding.ASCII.GetBytes("WAVE"));

                // fmt subchunk
                bw.Write(System.Text.Encoding.ASCII.GetBytes("fmt "));
                bw.Write(fmtChunkSize);
                bw.Write((short)1); // PCM
                bw.Write(channels);
                bw.Write(sampleRate);
                bw.Write(byteRate);
                bw.Write((short)blockAlign);
                bw.Write(bitsPerSample);

                // data subchunk
                bw.Write(System.Text.Encoding.ASCII.GetBytes("data"));
                bw.Write(dataSize);

                // write silence
                for (int i = 0; i < dataSize / 2; i++) // 2 bytes per sample
                {
                    bw.Write((short)0);
                }

                bw.Flush();
            }
            catch
            {
                // ignore errors; app will continue without audio
            }
        }
    }
}
