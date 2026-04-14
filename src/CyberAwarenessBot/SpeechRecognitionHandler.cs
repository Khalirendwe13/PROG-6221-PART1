using System;
using System.Reflection;
using System.Threading.Tasks;

namespace CyberAwarenessBot
{
    /// <summary>
    /// Handles speech recognition using System.Speech.Recognition via reflection.
    /// Allows users to speak queries instead of typing them.
    /// </summary>
    public static class SpeechRecognitionHandler
    {
        private static object? _recognizer;
        private static Type? _recognizerType;
        private static string? _lastRecognizedText;

        public static void Initialize()
        {
            try
            {
                var asm = Assembly.Load("System.Speech");
                _recognizerType = asm.GetType("System.Speech.Recognition.SpeechRecognitionEngine");

                if (_recognizerType != null)
                {
                    _recognizer = Activator.CreateInstance(_recognizerType);
                }
            }
            catch
            {
                // Speech recognition not available
            }
        }

        /// <summary>
        /// Attempt to recognize speech from microphone with timeout.
        /// Returns the recognized text or null if recognition failed or is not supported.
        /// </summary>
        public static async Task<string?> RecognizeSpeechAsync(int timeoutSeconds = 5)
        {
            if (_recognizer == null || _recognizerType == null)
                return null;

            try
            {
                ConsoleUI.WriteColoredLine("Listening... (speak your question)", ConsoleColor.Cyan);

                var recognizeMethod = _recognizerType.GetMethod("Recognize", 
                    new Type[] { typeof(TimeSpan) });

                if (recognizeMethod == null)
                    return null;

                // Create timeout timespan
                var timeoutSpan = typeof(TimeSpan).GetMethod("FromSeconds", 
                    System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public)
                    ?.Invoke(null, new object[] { timeoutSeconds });

                if (timeoutSpan == null)
                    return null;

                // Run recognition in a task to avoid blocking
                var recognitionTask = Task.Run(() =>
                {
                    try
                    {
                        var result = recognizeMethod.Invoke(_recognizer, new object[] { timeoutSpan });
                        if (result == null)
                            return null;

                        var resultType = result.GetType();
                        var textProperty = resultType.GetProperty("Text");
                        var text = textProperty?.GetValue(result) as string;

                        if (!string.IsNullOrWhiteSpace(text))
                        {
                            _lastRecognizedText = text;
                            ConsoleUI.WriteColoredLine($"You said: \"{text}\"", ConsoleColor.Cyan);
                            return text;
                        }

                        return null;
                    }
                    catch
                    {
                        return null;
                    }
                });

                // Wait with timeout
                if (await Task.WhenAny(recognitionTask, Task.Delay(timeoutSeconds * 1000 + 1000)) == recognitionTask)
                {
                    return await recognitionTask;
                }

                ConsoleUI.WriteColoredLine("Recognition timeout. Please try again or type your question.", ConsoleColor.Yellow);
                return null;
            }
            catch
            {
                return null;
            }
        }

        public static bool IsAvailable => _recognizer != null;

        public static string? LastRecognizedText => _lastRecognizedText;
    }
}
