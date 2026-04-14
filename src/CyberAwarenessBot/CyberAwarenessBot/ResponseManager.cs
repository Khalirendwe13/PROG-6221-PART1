using System;
using System.Collections.Generic;

namespace CyberAwarenessBot
{
    public class ResponseManager
    {
        private Dictionary<string, string[]> _responses;

        public ResponseManager()
        {
            InitializeResponses();
        }

        private void InitializeResponses()
        {
            _responses = new Dictionary<string, string[]>
            {
                { "1", new[] {
                    "Password Safety is crucial for protecting your personal information.",
                    "",
                    "Key Password Safety Tips:",
                    "- Use strong passwords with at least 12 characters",
                    "- Include uppercase, lowercase, numbers, and symbols",
                    "- Never reuse passwords across different accounts",
                    "- Enable two-factor authentication (2FA) whenever available",
                    "- Never share your passwords with anyone",
                    "- Use a password manager to securely store your credentials",
                    "",
                    "Remember: A strong password is your first line of defense!"
                }),

                { "2", new[] {
                    "Phishing is a cyberattack method where attackers trick you into revealing sensitive information.",
                    "",
                    "How to Identify and Avoid Phishing Attacks:",
                    "- Be suspicious of urgent or threatening emails",
                    "- Verify sender email addresses carefully",
                    "- Hover over links to see their actual destination",
                    "- Look for spelling and grammar errors in emails",
                    "- Never click links or download attachments from unknown senders",
                    "- Check for official company logos and contact information",
                    "",
                    "Stay vigilant - attackers use social engineering to exploit trust!"
                }),

                { "3", new[] {
                    "Safe Browsing practices help protect you from malware and data theft.",
                    "",
                    "Safe Browsing Recommendations:",
                    "- Look for 'HTTPS' and a padlock icon in the address bar",
                    "- Keep your browser and extensions updated",
                    "- Use a reputable antivirus and antimalware software",
                    "- Avoid clicking on suspicious pop-up ads",
                    "- Don't download files from untrusted websites",
                    "- Be cautious when using public WiFi networks",
                    "",
                    "Safe browsing is a habit - make it part of your daily routine!"
                }),

                { "how are you", new[] {
                    "Thank you for asking! I'm functioning well and ready to help you learn about cybersecurity.",
                    "How can I assist you today?"
                }),

                { "whats your purpose", new[] {
                    "My purpose is to educate you about cybersecurity awareness.",
                    "I'm here to help you stay safe online."
                })
            };
        }

        public string[] GetResponse(string userInput)
        {
            if (string.IsNullOrWhiteSpace(userInput))
            {
                return new[] { "I didn't quite understand that. Could you rephrase?" };
            }

            string inputLower = userInput.ToLower().Trim();

            if (_responses.ContainsKey(inputLower))
            {
                return _responses[inputLower];
            }

            if (inputLower == "1" || inputLower.Contains("password"))
                return _responses["1"];
            if (inputLower == "2" || inputLower.Contains("phishing"))
                return _responses["2"];
            if (inputLower == "3" || inputLower.Contains("browsing") || inputLower.Contains("safe"))
                return _responses["3"];

            return new[] {
                "I didn't quite understand that. Could you rephrase?",
                "",
                "You can ask about: 1, 2, 3 or type 'help'"
            };
        }
    }
}
