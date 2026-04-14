# Quick Start - Voice Features

## 🎬 5-Minute Quick Start

### Step 1: Build the Application
```bash
dotnet build "src\CyberAwarenessBot\CyberAwarenessBot.csproj"
```

### Step 2: Run the Application
```bash
dotnet run --project "src\CyberAwarenessBot\CyberAwarenessBot.csproj"
```

### Step 3: Interact with the Bot

**Example conversation:**

```
Welcome to the Cybersecurity Awareness Bot!
Type 'help' to see available runtime commands.
Please enter your name:
> John

Hello John! I'm your Cybersecurity Awareness assistant.
────────────────────────────────────────────────────────────────────────────────
Ask me a question (or type 'exit' to quit):
[Type your question or 'voice' to speak]
> password

Strong passwords are long (12+ characters), unique per account, and preferably 
generated/stored with a password manager. Use multi-factor authentication where available.

[Voice plays the response]
────────────────────────────────────────────────────────────────────────────────
Ask me a question (or type 'exit' to quit):
[Type your question or 'voice' to speak]
> voice

Listening... (speak your question)
You said: "How do I protect my account?"

Protect accounts with strong unique passwords, enable multi-factor authentication, 
and review account recovery options regularly.

[Voice plays the response]
```

---

## 🎙️ Voice Commands Quick Reference

| Command | What It Does |
|---------|------------|
| `voice` | Speak instead of typing (5-second listening window) |
| `toggle voice` | Turn bot audio responses on/off |
| `change voice` | Select different voice for audio |
| `help` | Show all available commands |
| `exit` / `quit` | Close the application |

---

## 📝 First Run Experience

1. **Voice Greeting Plays** 🔊
   - "Hello! Welcome to the Cybersecurity Awareness Bot..."

2. **Ask for Your Name** 👤
   - Bot personalizes all responses with your name

3. **Your Customized Greeting** 🎤
   - "Hello [Your Name]! I'm your Cybersecurity Awareness assistant."
   - This is spoken aloud and displayed

4. **Ready for Questions** 💬
   - Type or speak your cybersecurity questions
   - Receive text AND audio responses

---

## 🔊 Using Voice Features

### Enable Voice Input
```
> voice
Listening... (speak your question)
You said: "What about phishing?"
```

### Toggle Voice Responses
```
> toggle voice
Voice responses: ENABLED
```

### Change Voice
```
> change voice
Available Voices:
  - Microsoft Zira Desktop
  - Microsoft David Desktop
Enter the exact voice name: Microsoft David Desktop
Saved voice: Microsoft David Desktop
```

---

## 💡 Tips & Tricks

1. **Natural Speaking**
   - Speak clearly and at normal pace
   - The bot captures best with standard English
   - Try: "Tell me about passwords" or "How do I stay safe online?"

2. **Cybersecurity Topics**
   - "password" - Password best practices
   - "phishing" - Phishing attack recognition
   - "safe browsing" - Browser security tips
   - "2FA" or "mfa" - Multi-factor authentication
   - "vpn" - VPN usage and benefits
   - "backup" - Data backup strategies
   - "malware" - Malware protection
   - "ransomware" - Ransomware awareness

3. **Getting Help**
   - Type `help` to see all available commands
   - Type `?` for quick command reference
   - Ask the bot: "What can I ask you about?"

---

## ❌ Troubleshooting

### Voice Not Playing?
- Check if speakers are connected and volume is on
- Ensure Windows Text-to-Speech is installed
- Try: `--no-voice` flag to run text-only mode

### Can't Speak?
- Microphone must be working and enabled
- Windows 10+ required for speech recognition
- If unavailable, just use text input

### No Voices Available?
- Install voices via: Settings → Time & Language → Speech → Text to Speech
- Then restart the bot

---

## 🏃 Commands Cheat Sheet

```
START SCREEN:
  Press Enter to enter your name

DURING CHAT:
  voice           → Speak your question
  toggle voice    → Turn audio on/off
  change voice    → Pick different voice
  help            → Show all commands
  exit            → Close bot

STARTUP FLAGS:
  --list-voices   → Show available voices
  --choose-voice  → Pick and save a voice
  --no-voice      → Disable voice features
```

---

## 🎯 Use Cases

### For Learning
- Ask about cybersecurity topics
- Get voice explanations
- Read along with audio for better retention

### For Accessibility
- Hear responses aloud
- Speak questions instead of typing
- Get personalized, friendly guidance

### For Testing
- Voice input testing (speak naturally)
- Voice output verification
- Audio playback confirmation

---

## 📊 Supported Topics

The bot can answer questions about:
✅ Password Safety
✅ Phishing Attacks  
✅ Safe Browsing
✅ Account Security
✅ Multi-Factor Authentication
✅ VPN Usage
✅ Malware Protection
✅ Ransomware Prevention
✅ Backup Strategies
✅ Public Wi-Fi Safety

---

## 🎉 Next Steps

1. **Run the bot**: `dotnet run --project "src\CyberAwarenessBot\CyberAwarenessBot.csproj"`
2. **Enter your name** when prompted
3. **Try voice input**: type `voice` to speak
4. **Ask questions** about cybersecurity
5. **Toggle features**: type `toggle voice` or `change voice`

Enjoy your interactive cybersecurity learning experience! 🚀
