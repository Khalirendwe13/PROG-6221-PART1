# 🎤 Cybersecurity Awareness Bot with Voice Recording & Playback

## 📋 Overview

The Cybersecurity Awareness Bot now features **complete voice recording and playback capabilities**, allowing users to interact via both text and voice, and receive responses as synthesized audio.

### 🌟 What's New

✨ **Voice Text-to-Speech (TTS)**
- Bot responses played as audio
- Multiple voice options
- Personalized greetings

🎙️ **Speech-to-Text (STT)**  
- Users can speak questions
- Microphone input conversion
- Automatic transcription

🔊 **Audio Management**
- Play/pause voice responses
- Toggle voice on/off
- Select preferred voice
- Auto-cleanup of files

---

## 🚀 Quick Start

### Installation
```bash
# Clone or navigate to project directory
cd your-project-path

# Build the application
dotnet build "src\CyberAwarenessBot\CyberAwarenessBot.csproj"
```

### Running

**Standard (with voice):**
```bash
dotnet run --project "src\CyberAwarenessBot\CyberAwarenessBot.csproj"
```

**Text-only mode:**
```bash
dotnet run --project "src\CyberAwarenessBot\CyberAwarenessBot.csproj" -- --no-voice
```

**List available voices:**
```bash
dotnet run --project "src\CyberAwarenessBot\CyberAwarenessBot.csproj" -- --list-voices
```

---

## 📖 Documentation

| Document | Purpose |
|----------|---------|
| [QUICK_START_VOICE.md](QUICK_START_VOICE.md) | 5-minute getting started guide |
| [VOICE_FEATURES_GUIDE.md](VOICE_FEATURES_GUIDE.md) | Complete feature documentation |
| [VOICE_EXAMPLES.md](VOICE_EXAMPLES.md) | Real-world usage examples |
| [IMPLEMENTATION_SUMMARY.md](IMPLEMENTATION_SUMMARY.md) | Technical implementation details |

---

## 💬 Usage Examples

### Example 1: Text with Voice Response
```
> password
Strong passwords are long (12+ characters)...
[Audio plays the response]
```

### Example 2: Voice Input
```
> voice
Listening... (speak your question)
You said: "How do I protect my account?"
Protect accounts with strong unique...
[Audio plays the response]
```

### Example 3: Toggle Voice
```
> toggle voice
Voice responses: DISABLED
[Subsequent responses display without audio]
```

---

## 🎯 Core Features

### ✅ Interactive Experience
- Asks for user name
- Personalizes all responses
- Displays ASCII art header
- Color-coded console output
- Animated text effects

### ✅ Cybersecurity Topics
- Password Safety
- Phishing Detection
- Safe Browsing
- Account Security (2FA/MFA)
- VPN Usage
- Malware Protection
- Ransomware Prevention
- Backup Strategies
- Public Wi-Fi Safety

### ✅ Voice Capabilities
- **Text-to-Speech:** Bot responses read aloud
- **Speech-to-Text:** Users speak questions
- **Voice Selection:** Multiple voice options
- **Voice Persistence:** Settings saved across sessions

### ✅ Input Validation
- Empty input detection
- Invalid query handling
- Helpful error messages
- Graceful fallback

### ✅ Runtime Commands
| Command | Function |
|---------|----------|
| `voice` | Speak your question |
| `toggle voice` | Enable/disable audio |
| `change voice` | Select different voice |
| `help` | Show commands |
| `exit` | Close bot |

---

## 🔧 Technical Details

### Architecture

```
Program.cs
├── Voice Feature Integration
├── Command Processing
├── User Input Handling
└── Response Management

VoiceResponseHandler
├── Text-to-Speech Synthesis
├── Audio Playback
├── Voice Selection
└── File Management

SpeechRecognitionHandler
├── Microphone Input
├── Speech Recognition
├── Text Conversion
└── Timeout Handling

Bot.cs
├── Response Database
├── Question Matching
└── Personalization

ConsoleUI.cs
├── Display Formatting
├── Color Management
└── User Input Collection
```

### Technology Stack
- **Platform:** Windows 7+ (.NET 8.0)
- **TTS Engine:** System.Speech.Synthesis (Reflection-based)
- **STT Engine:** System.Speech.Recognition (Reflection-based)
- **Audio Playback:** System.Media.SoundPlayer
- **Language:** C# 12

### Audio Format
- **Type:** WAV (PCM)
- **Bitrate:** Standard quality
- **Location:** `assets/` directory
- **Cleanup:** Automatic

---

## 📋 System Requirements

- **Operating System:** Windows 7 or later
- **.NET Runtime:** .NET 8.0 or compatible
- **Audio Output:** Speakers/Headphones (optional)
- **Audio Input:** Microphone (optional, for voice input)
- **RAM:** 100 MB minimum
- **Disk:** 50 MB free space

---

## 🎮 Interactive Features

### Personalization
```
"Please enter your name:"
> John
"Hello John! I'm your Cybersecurity Awareness assistant."
```

### Voice Input
```
"Ask me a question (or type 'exit' to quit):"
> voice
"Listening... (speak your question)"
[User speaks: "How do I stay safe online?"]
```

### Voice Toggle
```
> toggle voice
"Voice responses: DISABLED"
[Subsequent responses are text-only]
```

### Help System
```
> help
"Available runtime commands:"
" - help / commands / ? : show this help"
" - voice : speak your question instead of typing"
" - toggle voice : enable/disable voice responses"
```

---

## 🛠️ Implementation Files

### New Files
- **VoiceResponseHandler.cs** - Handles TTS and audio playback
- **SpeechRecognitionHandler.cs** - Handles STT and voice input
- **VOICE_FEATURES_GUIDE.md** - Complete documentation
- **QUICK_START_VOICE.md** - Quick reference
- **VOICE_EXAMPLES.md** - Usage examples
- **IMPLEMENTATION_SUMMARY.md** - Technical details

### Modified Files
- **Program.cs** - Integrated voice features

### Unchanged Files
- **Bot.cs** - Response database
- **ConsoleUI.cs** - UI utilities
- **VoiceGreetingGenerator.cs** - Greeting synthesis
- **WriteGreetingFromBase64.cs** - WAV utilities

---

## 🧪 Testing

### Build Verification
```bash
dotnet build "src\CyberAwarenessBot\CyberAwarenessBot.csproj"
# Expected: Build succeeded, 0 errors
```

### Runtime Testing
1. **Launch:** Run the application
2. **Test Text:** Type "password" and verify voice plays
3. **Test Voice:** Type "voice" and speak a question
4. **Test Toggle:** Type "toggle voice" and verify silence
5. **Test Change:** Type "change voice" and select new voice
6. **Test Exit:** Type "exit" and verify goodbye message

---

## 📊 File Structure

```
CyberAwarenessBot/
├── src/
│   └── CyberAwarenessBot/
│       ├── Program.cs                  [UPDATED]
│       ├── Bot.cs
│       ├── ConsoleUI.cs
│       ├── VoiceGreetingGenerator.cs
│       ├── VoiceResponseHandler.cs    [NEW]
│       ├── SpeechRecognitionHandler.cs [NEW]
│       ├── WriteGreetingFromBase64.cs
│       └── CyberAwarenessBot.csproj
│
├── tests/
│   └── CyberAwarenessBot.Tests/
│       ├── BotTests.cs
│       ├── AdditionalBotTests.cs
│       └── CyberAwarenessBot.Tests.csproj
│
├── assets/
│   ├── greeting.wav
│   ├── voice.config
│   └── temp_response.wav
│
└── Documentation/
    ├── VOICE_FEATURES_GUIDE.md
    ├── QUICK_START_VOICE.md
    ├── VOICE_EXAMPLES.md
    ├── IMPLEMENTATION_SUMMARY.md
    └── README.md (this file)
```

---

## 🎓 Cybersecurity Topics Covered

The bot provides guidance on:

| Topic | Coverage |
|-------|----------|
| **Passwords** | Length, complexity, managers, MFA |
| **Phishing** | Detection, verification, safety |
| **Browsing** | HTTPS, updates, trusted sites |
| **Account Security** | 2FA/MFA, recovery options |
| **Network** | Public Wi-Fi, VPN usage |
| **Malware** | Prevention, detection, tools |
| **Ransomware** | Protection, backups, response |
| **Backups** | Strategy, testing, recovery |

---

## 🐛 Troubleshooting

### Voice Not Playing
**Issue:** No audio on responses
- Check speakers/volume
- Verify Windows TTS installed
- Try: `--no-voice` flag

### Speech Not Recognized
**Issue:** Voice input fails
- Microphone must be enabled
- Speak clearly and naturally
- Windows 10+ required

### No Voices Listed
**Issue:** `--list-voices` shows nothing
- Install voices: Settings → Time & Language → Speech
- Restart application

### Timeout Error
**Issue:** Voice input times out
- Speak within 5-second window
- Speak before microphone timeout

---

## 🔐 Privacy & Security

✅ **No Internet Required**
- All processing is local
- No cloud connectivity
- User data stays on device

✅ **Voice Storage**
- Voice config saved locally
- Temporary files auto-deleted
- No remote logging

✅ **Accessibility**
- Text-only mode available
- No forced voice usage
- User controls enabled

---

## 📈 Performance

| Operation | Time |
|-----------|------|
| Synthesis | 1-3 seconds (first time) |
| Playback | Varies (3-15 sec per response) |
| Recognition | Up to 5 seconds |
| Total Memory | 50-100 MB |
| Disk Usage | ~2 MB (auto-cleaned) |

---

## ✨ Features at a Glance

| Feature | Status |
|---------|--------|
| Voice Greeting | ✅ Implemented |
| Text Responses | ✅ Implemented |
| Voice Responses | ✅ Implemented |
| Speech Input | ✅ Implemented |
| Voice Selection | ✅ Implemented |
| Voice Persistence | ✅ Implemented |
| Error Handling | ✅ Implemented |
| Personalization | ✅ Implemented |
| Help System | ✅ Implemented |
| Runtime Commands | ✅ Implemented |
| Cross-Platform | ✅ Text-only on non-Windows |
| Accessibility | ✅ Fully supported |

---

## 🚀 Getting Started

### Step 1: Build
```bash
dotnet build "src\CyberAwarenessBot\CyberAwarenessBot.csproj"
```

### Step 2: Run
```bash
dotnet run --project "src\CyberAwarenessBot\CyberAwarenessBot.csproj"
```

### Step 3: Interact
```
Enter your name:
> Your Name

Ask me a question (or type 'exit' to quit):
> voice
[Speak your question]
```

### Step 4: Explore
```
> help              # See all commands
> toggle voice      # Control audio
> change voice      # Select different voice
```

---

## 📚 Documentation

**For detailed information, see:**

- 📖 [QUICK_START_VOICE.md](QUICK_START_VOICE.md) - Start here!
- 🎯 [VOICE_FEATURES_GUIDE.md](VOICE_FEATURES_GUIDE.md) - Complete reference
- 💡 [VOICE_EXAMPLES.md](VOICE_EXAMPLES.md) - Real examples
- 🔧 [IMPLEMENTATION_SUMMARY.md](IMPLEMENTATION_SUMMARY.md) - Technical details

---

## 🎉 What You Can Do Now

✅ **Type cybersecurity questions**
- Ask about passwords, phishing, browsing safety, etc.

✅ **Listen to responses**
- All bot replies are spoken aloud (when enabled)

✅ **Speak your questions**
- Use voice input instead of typing

✅ **Manage voice settings**
- Toggle audio, change voices, list options

✅ **Learn cybersecurity**
- Get personalized, interactive guidance

✅ **Enjoy accessibility**
- Text-only mode, customizable, user-friendly

---

## 🤝 Support

For issues:
1. Check troubleshooting section above
2. Review documentation files
3. Verify system requirements
4. Check console error messages

---

## 📄 License

This project is part of the Cybersecurity Awareness Bot initiative.

---

## 🎯 Next Steps

1. ✅ **Build the application**
   ```bash
   dotnet build "src\CyberAwarenessBot\CyberAwarenessBot.csproj"
   ```

2. ✅ **Run the bot**
   ```bash
   dotnet run --project "src\CyberAwarenessBot\CyberAwarenessBot.csproj"
   ```

3. ✅ **Try voice input**
   - Type `voice` to speak
   - Ask natural questions
   - Listen to responses

4. ✅ **Explore features**
   - Type `help` for commands
   - Type `toggle voice` to control audio
   - Type `change voice` to select voices

5. ✅ **Learn cybersecurity**
   - Ask about any security topic
   - Get personalized guidance
   - Enjoy interactive learning

---

**🎤 Your interactive cybersecurity chatbot with voice capabilities is ready to use!**

**Start with:** `dotnet run --project "src\CyberAwarenessBot\CyberAwarenessBot.csproj"`
