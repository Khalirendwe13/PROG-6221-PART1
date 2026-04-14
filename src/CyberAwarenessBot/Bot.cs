using System;
using System.Collections.Generic;
using System.Linq;

namespace CyberAwarenessBot
{
    public class Bot
    {
        // Automatic properties
        public string UserName { get; set; } = "User";
        public List<string> Topics { get; } = new List<string> { "Password Safety", "Phishing", "Safe Browsing" };

        // Simple response database
        private readonly Dictionary<string, string> _responses = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            { "how are you", "I'm a Bot — ready to help you learn about staying safe online." },
            { "what's your purpose", "My purpose is to provide guidance about cybersecurity topics like passwords, phishing, and safe browsing." },
            { "what can i ask you about", "You can ask me about password safety, phishing attacks, safe browsing practices, account security, and general online privacy tips." },
            { "password", "Strong passwords are long (12+ characters), unique per account, and preferably generated/stored with a password manager. Use multi-factor authentication where available." },
            { "account security", "Protect accounts with strong unique passwords, enable multi-factor authentication, and review account recovery options regularly." },
            { "two-factor", "Two-factor (2FA) or multi-factor authentication (MFA) adds an extra layer of security beyond a password — use an authenticator app or hardware key when possible." },
            { "mfa", "Two-factor (2FA) or multi-factor authentication (MFA) adds an extra layer of security beyond a password — use an authenticator app or hardware key when possible." },
            { "phishing", "Phishing is a scam where attackers try to trick you into giving sensitive information. Verify senders, check URLs before clicking, and never share passwords via email." },
            { "suspicious link", "If a link looks suspicious, don't click it. Hover to inspect the destination, and when in doubt, navigate to the site directly from your browser." },
            { "safe browsing", "Use HTTPS sites, keep your browser updated, avoid suspicious downloads, and don't enter credentials on sites you don't trust." },
            { "public wifi", "Avoid logging into sensitive accounts on public Wi‑Fi. Use a trusted VPN if you need to access private resources on untrusted networks." },
            { "vpn", "A VPN encrypts your traffic between your device and the VPN server — useful on untrusted networks, but choose a reputable provider and know its limitations." },
            { "malware", "Malware is malicious software that can harm your device or steal data. Keep software updated, avoid unknown downloads, and use reputable security tools." },
            { "ransomware", "Ransomware encrypts your files and demands payment. Protect against it with backups, updates, cautious email habits, and strong access controls." },
            { "backup", "Keep regular backups of important data offline or in a separate cloud account; test restores so backups are reliable if needed." },
        };

        public static string GetOptions()
        {
            return "You can ask me questions like:\n" +
                   " - How are you?\n" +
                   " - What's your purpose?\n" +
                   " - What can I ask you about?\n" +
                   " - Tell me about password safety\n" +
                   " - What is phishing?\n" +
                   " - How do I browse safely?\n" +
                   " - What is multi-factor authentication?\n";
        }

        public static string GetTopicOptions()
        {
            return "Here are some cybersecurity topics you can ask about:\n" +
                   " - Password Safety\n" +
                   " - Phishing\n" +
                   " - Safe Browsing\n" +
                   " - Account Security\n" +
                   " - Two-factor Authentication (2FA/MFA)\n" +
                   " - Public Wi-Fi\n" +
                   " - VPN\n" +
                   " - Malware\n" +
                   " - Ransomware\n" +
                   " - Backups\n";
        }

        public string GetResponse(string input, out bool handled)
        {
            handled = false;
            if (string.IsNullOrWhiteSpace(input)) return string.Empty;

            string normal = input.Trim().ToLowerInvariant();

            // direct matches
            foreach (var key in _responses.Keys)
            {
                if (normal.Contains(key, StringComparison.OrdinalIgnoreCase))
                {
                    handled = true;
                    return _responses[key];
                }
            }

            // small conversational intents
            if (normal.Contains("hello") || normal.Contains("hi"))
            {
                handled = true;
                return $"Hello {UserName}! How can I help you today?";
            }

            if (normal.Contains("help"))
            {
                handled = true;
                return "I can help with topics such as: " + string.Join(", ", Topics) + ". Try asking about 'passwords' or 'phishing'.";
            }

            // If not handled, provide options
            return "I didn't quite understand that. Could you rephrase?\n" + GetOptions();
        }
    }
}
