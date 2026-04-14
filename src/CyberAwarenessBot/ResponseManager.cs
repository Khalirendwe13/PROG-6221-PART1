using System;
using System.Collections.Generic;

namespace CyberAwarenessBot
{
    /// <summary>
    /// Manages all cybersecurity-related responses
    /// </summary>
    public class ResponseManager
    {
        private Dictionary<string, string[]> _responses;

        public ResponseManager()
        {
            InitializeResponses();
        }

        /// <summary>
        /// Initializes all predefined responses
        /// </summary>
        private void InitializeResponses()
        {
            _responses = new Dictionary<string, string[]>
            {
                // Greeting responses
                { "1", new[] {
                    "Password Safety is crucial for protecting your personal information.",
                    "",
                    "Key Password Safety Tips:",
                    "• Use strong passwords with at least 12 characters",
                    "• Include uppercase, lowercase, numbers, and symbols",
                    "• Never reuse passwords across different accounts",
                    "• Enable two-factor authentication (2FA) whenever available",
                    "• Never share your passwords with anyone",
                    "• Use a password manager to securely store your credentials",
                    "• Change passwords regularly and after security breaches",
                    "",
                    "Remember: A strong password is your first line of defense!"
                }),

                { "2", new[] {
                    "Phishing is a cyberattack method where attackers trick you into revealing sensitive information.",
                    "",
                    "How to Identify and Avoid Phishing Attacks:",
                    "• Be suspicious of urgent or threatening emails",
                    "• Verify sender email addresses carefully",
                    "• Hover over links to see their actual destination",
                    "• Look for spelling and grammar errors in emails",
                    "• Never click links or download attachments from unknown senders",
                    "• Check for official company logos and contact information",
                    "• When in doubt, contact the company directly using official channels",
                    "• Report suspicious emails to IT security",
                    "",
                    "Stay vigilant - attackers use social engineering to exploit trust!"
                }),

                { "3", new[] {
                    "Safe Browsing practices help protect you from malware and data theft.",
                    "",
                    "Safe Browsing Recommendations:",
                    "• Look for 'HTTPS' and a padlock icon in the address bar",
                    "• Keep your browser and extensions updated",
                    "• Use a reputable antivirus and antimalware software",
                    "• Avoid clicking on suspicious pop-up ads",
                    "• Don't download files from untrusted websites",
                    "• Be cautious when using public WiFi networks",
                    "• Use a VPN for additional privacy protection",
                    "• Regularly clear your browser cache and cookies",
                    "",
                    "Safe browsing is a habit - make it part of your daily routine!"
                }),

                { "how are you", new[] {
                    "Thank you for asking! I'm functioning well and ready to help you learn about cybersecurity.",
                    "How can I assist you today?"
                }),

                { "what's your purpose", new[] {
                    "My purpose is to educate you about cybersecurity awareness and best practices.",
                    "I'm here to help you stay safe online by providing information about:",
                    "• Password safety and management",
                    "• Phishing awareness and prevention",
                    "• Safe browsing habits",
                    "",
                    "What would you like to learn about?"
                }),

                { "what can i ask you about", new[] {
                    "Great question! I can help you with these topics:",
                    "• Password Safety - Learn how to create and manage strong passwords",
                    "• Phishing Awareness - Understand how to identify and avoid phishing attacks",
                    "• Safe Browsing - Tips for staying safe while using the internet",
                    "",
                    "You can also ask me questions like:",
                    "• 'How are you?'",
                    "• 'What's your purpose?'",
                    "• Type 'help' for commands",
                    "",
                    "What topic interests you?"
                })
            };
        }

        /// <summary>
        /// Gets a response based on user input
        /// </summary>
        public string[] GetResponse(string userInput)
        {
            if (string.IsNullOrWhiteSpace(userInput))
            {
                return new[] { "I didn't quite understand that. Could you rephrase?" };
            }

            string inputLower = userInput.ToLower().Trim();

            // Check for exact matches
            if (_responses.ContainsKey(inputLower))
            {
                return _responses[inputLower];
            }

            // Check for partial matches
            foreach (var key in _responses.Keys)
            {
                if (inputLower.Contains(key) || key.Contains(inputLower))
                {
                    return _responses[key];
                }
            }

            // Check for numeric input (1, 2, 3)
            if (inputLower == "1" || inputLower.Contains("password"))
                return _responses["1"];
            if (inputLower == "2" || inputLower.Contains("phishing"))
                return _responses["2"];
            if (inputLower == "3" || inputLower.Contains("browsing") || inputLower.Contains("safe"))
                return _responses["3"];

            // Default response
            return new[] {
                "I didn't quite understand that. Could you rephrase?",
                "",
                "You can ask about:",
                "• 'Password Safety' (or type 1)",
                "• 'Phishing' (or type 2)",
                "• 'Safe Browsing' (or type 3)",
                "• 'How are you?'",
                "• 'What's your purpose?'",
                "• 'What can I ask you about?'",
                "• Type 'help' for all commands"
            };
        }
    }
}
