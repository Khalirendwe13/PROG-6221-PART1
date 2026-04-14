# Cybersecurity Awareness Bot - Voice Features Guide

## Overview

Your Cybersecurity Awareness Bot now includes advanced voice recording and playback capabilities. Users can interact with the bot using both text and voice input, and receive responses as synthesized audio.

---

## 🎙️ Voice Features

### 1. **Voice Greetings**
- The bot plays a personalized voice greeting when it starts
- Uses Text-to-Speech (TTS) synthesis on Windows systems
- Falls back to silent audio on unsupported platforms

### 2. **Voice Responses**
- All bot responses can be played as audio
- Responses are synthesized and played automatically (can be toggled)
- Smooth integration with text output

### 3. **Voice Input (Speech Recognition)**
- Users can speak their questions instead of typing them
- Command: `voice` - triggers speech recognition with 5-second timeout
- Recognized text is displayed for confirmation

### 4. **Voice Management**
- List available voices on your system
- Configure preferred voice for the session
- Voice settings are saved and persisted

---

## 🚀 Running the Application

### Basic Start
```bash
dotnet run --project "src\CyberAwarenessBot\CyberAwarenessBot.csproj"
```

### With Voice Responses Disabled
```bash
dotnet run --project "src\CyberAwarenessBot\CyberAwarenessBot.csproj" -- --no-voice
```

### List Available Voices
```bash
dotnet run --project "src\CyberAwarenessBot\CyberAwarenessBot.csproj" -- --list-voices
```

### Choose a Voice
```bash
dotnet run --project "src\CyberAwarenessBot\CyberAwarenessBot.csproj" -- --choose-voice
```

---

## 💬 Runtime Commands

| Command | Description |
|---------|-------------|
| `help` / `commands` / `?` | Show available commands |
| `voice` | Speak your question instead of typing |
| `change voice` / `voice config` | List voices and change the preferred voice |
| `toggle voice` | Enable/disable voice responses |
| `exit` / `quit` | Exit the application |

### Example Usage:

**Text Input:**
```
Ask me a question (or type 'exit' to quit):
password
Bot: Strong passwords are long (12+ characters)...
[Audio plays the response]
```

**Voice Input:**
```
Ask me a question (or type 'exit' to quit):
voice
Listening... (speak your question)
You said: "How do I protect my account?"
Bot: Protect accounts with strong unique passwords...
[Audio plays the response]
```

---

## 🔊 Voice Components

### VoiceGreetingGenerator
- Generates initial greeting WAV file
- Uses System.Speech.Synthesis (Windows-only)
- Falls back to silent WAV if synthesis unavailable
- Supports voice configuration persistence

### VoiceResponseHandler
- Synthesizes bot responses to audio
- Manages temporary audio files
- Handles playback with SoundPlayer
- Platform-aware (Windows-only playback)

### SpeechRecognitionHandler
- Recognizes speech from microphone
- Uses System.Speech.Recognition (Windows-only)
- 5-second timeout by default
- Gracefully handles recognition failures

---

## 📋 Technical Details

### Supported Platforms
- **Windows**: Full voice support (input + output)
- **macOS/Linux**: Text-only (voice synthesis requires System.Speech)

### Voice Technology
- **Text-to-Speech**: System.Speech.Synthesis (via reflection)
- **Speech Recognition**: System.Speech.Recognition (via reflection)
- **Audio Playback**: System.Media.SoundPlayer

### Audio Files
- Format: WAV (PCM)
- Location: `assets/` directory
- Greeting: `assets/greeting.wav`
- Temporary responses: `assets/temp_response.wav` (auto-cleaned)
- Voice config: `assets/voice.config` (persists voice selection)

---

## 🎯 Features Breakdown

### Personalization
✅ User name collection
✅ Personalized greetings
✅ Voice preference persistence
✅ Custom voice selection

### Cybersecurity Topics Covered
- Password Safety
- Phishing Detection
- Safe Browsing Practices
- Account Security (2FA/MFA)
- VPN Usage
- Malware & Ransomware Protection
- Backup Strategies
- Public Wi-Fi Safety

### Input Validation
✅ Empty input detection
✅ Invalid query handling
✅ Graceful error messages
✅ Help system for guidance

### Interactive Experience
✅ Color-coded console output
✅ ASCII art header
✅ Animated text typing effect
✅ Voice audio playback
✅ Speech recognition
✅ Runtime command system

---

## 🔧 Configuration

### First-Time Setup
On first run, the bot will:
1. Detect available voices
2. Ask to use the default voice
3. Save your preference to `assets/voice.config`

### Changing Voice Later
During runtime:
```
Ask me a question (or type 'exit' to quit):
change voice
Available Voices:
  - Microsoft Zira Desktop
  - Microsoft David Desktop
Enter the exact voice name to save (or press Enter to cancel):
Microsoft David Desktop
```

### Disabling Voice
```
Ask me a question (or type 'exit' to quit):
toggle voice
Voice responses: DISABLED
```

---

## 🛠️ System Requirements

- **.NET 8.0 SDK** or later
- **Windows OS** (for voice features)
  - Windows 7 or later with Text-to-Speech installed
  - Microphone for voice input (optional)
- **Admin privileges** (optional, for system voice installation)

### Check Windows Voices
```powershell
# In PowerShell or CMD:
dotnet run --project "src\CyberAwarenessBot\CyberAwarenessBot.csproj" -- --list-voices
```

---

## 📊 Testing

Run the test suite:
```bash
dotnet test "tests\CyberAwarenessBot.Tests\CyberAwarenessBot.Tests.csproj"
```

Test coverage includes:
- Known question responses
- Password question handling
- Unknown query handling
- Personalization with user names

---

## 🐛 Troubleshooting

### Voice Not Working
- **Issue**: No audio playback
- **Solution**: Check if you're on Windows 7+, ensure speakers are enabled
- **Workaround**: Run with `--no-voice` flag

### Speech Recognition Not Available
- **Issue**: "Voice recognition is not available"
- **Solution**: Voice input only works on Windows with System.Speech installed
- **Workaround**: Use text input instead

### Voices Not Listed
- **Issue**: No voices appear in `--list-voices`
- **Solution**: Install Windows Text-to-Speech voices via Settings
  - Settings → Time & Language → Speech
  - Check "Text to Speech" and install voices

### Audio File Locked Error
- **Issue**: "Cannot delete temp_response.wav"
- **Solution**: Wait a moment between commands, file auto-cleans after playback

---

## 📝 Future Enhancements

- Azure Cognitive Services integration for better voice quality
- Multi-language support
- Advanced NLP for context awareness
- Chat history saving
- Custom knowledge base expansion
- Integration with security alerts

---

## 📄 License

This project is part of the Cybersecurity Awareness Bot initiative.

---

## 🤝 Support

For issues or feature requests:
1. Check troubleshooting section
2. Review console output for error messages
3. Ensure System.Speech components are installed
4. Try running on a different Windows system

---

## 🎓 Learning Resources

The bot covers these key cybersecurity topics:
- Strong password practices
- Multi-factor authentication (MFA)
- Phishing attack recognition
- Safe browsing habits
- VPN usage
- Backup strategies
- Account security best practices

Ask the bot: "What can I ask you about?" to see all available topics!
