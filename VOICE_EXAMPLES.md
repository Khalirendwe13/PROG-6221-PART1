# Voice Features - Complete Examples

## Example 1: Text Interaction with Voice Response

```
C:\> dotnet run --project "src\CyberAwarenessBot\CyberAwarenessBot.csproj"

[ASCII Art Header displays]
────────────────────────────────────────────────────────────────────────────────
Welcome to the Cybersecurity Awareness Bot!
Type 'help' to see available runtime commands.
Please enter your name:
> Sarah

Hello Sarah! I'm your Cybersecurity Awareness assistant.
[Voice plays: "Hello Sarah! I'm your Cybersecurity Awareness assistant."]
────────────────────────────────────────────────────────────────────────────────
Ask me a question (or type 'exit' to quit):
[Type your question or 'voice' to speak]
> How are you?

Hello Sarah! How can I help you today?
[Voice plays the response]
────────────────────────────────────────────────────────────────────────────────
Ask me a question (or type 'exit' to quit):
[Type your question or 'voice' to speak]
> Tell me about passwords

Strong passwords are long (12+ characters), unique per account, and preferably 
generated/stored with a password manager. Use multi-factor authentication where available.
[Voice plays the response]
────────────────────────────────────────────────────────────────────────────────
```

---

## Example 2: Voice Input Interaction

```
Ask me a question (or type 'exit' to quit):
[Type your question or 'voice' to speak]
> voice

[Microphone activates]
Listening... (speak your question)

[User speaks: "How do I protect my account?"]

You said: "How do I protect my account?"

Protect accounts with strong unique passwords, enable multi-factor authentication, 
and review account recovery options regularly.
[Voice plays the response]
────────────────────────────────────────────────────────────────────────────────
```

---

## Example 3: Runtime Commands

```
Ask me a question (or type 'exit' to quit):
[Type your question or 'voice' to speak]
> help

Available runtime commands:
 - help / commands / ? : show this help
 - voice : speak your question instead of typing
 - change voice / voice config : list voices and change the voice
 - toggle voice : enable/disable voice responses
 - exit / quit : exit the application
 - You can also type cybersecurity questions like 'password' or 'phishing' to get advice.
────────────────────────────────────────────────────────────────────────────────
```

---

## Example 4: Changing Voice

```
Ask me a question (or type 'exit' to quit):
[Type your question or 'voice' to speak]
> change voice

Available Voices:
  - Microsoft Zira Desktop
  - Microsoft David Desktop

Enter the exact voice name to save (or press Enter to cancel):
> Microsoft David Desktop

Saved voice: Microsoft David Desktop
[New greeting plays with David voice]
────────────────────────────────────────────────────────────────────────────────
```

---

## Example 5: Toggling Voice Responses

```
Ask me a question (or type 'exit' to quit):
[Type your question or 'voice' to speak]
> toggle voice

Voice responses: DISABLED
────────────────────────────────────────────────────────────────────────────────
Ask me a question (or type 'exit' to quit):
[Type your question or 'voice' to speak]
> phishing

Phishing is a scam where attackers try to trick you into giving sensitive information. 
Verify senders, check URLs before clicking, and never share passwords via email.
[NO voice plays - disabled]
────────────────────────────────────────────────────────────────────────────────
Ask me a question (or type 'exit' to quit):
[Type your question or 'voice' to speak]
> toggle voice

Voice responses: ENABLED
────────────────────────────────────────────────────────────────────────────────
```

---

## Example 6: Error Handling

```
Ask me a question (or type 'exit' to quit):
[Type your question or 'voice' to speak]
> [blank - just press Enter]

I didn't quite understand that. Could you rephrase?
[Voice plays error message]
────────────────────────────────────────────────────────────────────────────────
Ask me a question (or type 'exit' to quit):
[Type your question or 'voice' to speak]
> xyz123notarealquestion

I didn't quite understand that. Could you rephrase?
[Voice plays error message]
────────────────────────────────────────────────────────────────────────────────
```

---

## Example 7: Exit with Voice

```
Ask me a question (or type 'exit' to quit):
[Type your question or 'voice' to speak]
> exit

Goodbye! Stay safe online.
[Voice plays: "Goodbye! Stay safe online."]

C:\> _
```

---

## Example 8: Command Line Flags

### List Available Voices
```
C:\> dotnet run --project "src\CyberAwarenessBot\CyberAwarenessBot.csproj" -- --list-voices

Available Voices:
  - Microsoft Zira Desktop
  - Microsoft David Desktop

C:\> _
```

### Choose and Save a Voice
```
C:\> dotnet run --project "src\CyberAwarenessBot\CyberAwarenessBot.csproj" -- --choose-voice

Available Voices:
  - Microsoft Zira Desktop
  - Microsoft David Desktop

Enter the exact voice name to save (or press Enter to cancel):
> Microsoft David Desktop

Saved voice: Microsoft David Desktop

C:\> _
```

### Run Without Voice
```
C:\> dotnet run --project "src\CyberAwarenessBot\CyberAwarenessBot.csproj" -- --no-voice

[All responses display as text only - no audio playback]
```

---

## Example 9: Full Conversation Flow

```
🎤 Detected voice: Microsoft Zira Desktop
❓ Use this voice for greetings and responses? (Y/n)
> y

✅ Saved voice configuration
🔊 Playing greeting...

[ASCII Art displays]
────────────────────────────────────────────────────────────────────────────────
Welcome to the Cybersecurity Awareness Bot!
Type 'help' to see available runtime commands.
Please enter your name:
> Alex

👋 Hello Alex! I'm your Cybersecurity Awareness assistant.
[Voice plays personalized greeting]
────────────────────────────────────────────────────────────────────────────────
🎤 Ask me a question (or type 'exit' to quit):
[Type your question or 'voice' to speak]
> voice

🎙️ Listening... (speak your question)
✅ You said: "What is phishing?"

🔒 Phishing is a scam where attackers try to trick you into giving sensitive information. 
Verify senders, check URLs before clicking, and never share passwords via email.
[Voice plays the response]
────────────────────────────────────────────────────────────────────────────────
🎤 Ask me a question (or type 'exit' to quit):
[Type your question or 'voice' to speak]
> What about MFA?

🔐 Two-factor (2FA) or multi-factor authentication (MFA) adds an extra layer of security 
beyond a password — use an authenticator app or hardware key when possible.
[Voice plays the response]
────────────────────────────────────────────────────────────────────────────────
🎤 Ask me a question (or type 'exit' to quit):
[Type your question or 'voice' to speak]
> exit

👋 Goodbye! Stay safe online.
[Voice plays goodbye message]

✅ Application closed
C:\> _
```

---

## Example 10: Accessibility Scenario

**User with hearing impairment uses text-only mode:**

```
C:\> dotnet run --project "src\CyberAwarenessBot\CyberAwarenessBot.csproj" -- --no-voice

────────────────────────────────────────────────────────────────────────────────
Welcome to the Cybersecurity Awareness Bot!
Type 'help' to see available runtime commands.
Please enter your name:
> Jordan

Hello Jordan! I'm your Cybersecurity Awareness assistant.
[No audio - pure text interaction]
────────────────────────────────────────────────────────────────────────────────
Ask me a question (or type 'exit' to quit):
[Type your question or 'voice' to speak]
> password

Strong passwords are long (12+ characters), unique per account, and preferably 
generated/stored with a password manager. Use multi-factor authentication where available.
[Clear text response, no audio interference]
────────────────────────────────────────────────────────────────────────────────
```

---

## Key Features Demonstrated

✅ **Voice Greeting** - Personalized audio welcome
✅ **Voice Responses** - All bot answers read aloud
✅ **Voice Input** - Users can speak questions
✅ **Voice Management** - Change/list available voices
✅ **Toggle Control** - Enable/disable voice at runtime
✅ **Error Handling** - Graceful handling of invalid input
✅ **Personalization** - All responses use user's name
✅ **Accessibility** - Text-only mode available
✅ **Runtime Configuration** - Voice selection during operation
✅ **Command System** - Help, commands, exit functionality

---

## Platform Notes

- All examples assume **Windows 7+** with text-to-speech installed
- Voice input requires **microphone** (not needed for text mode)
- Speech recognition is Windows-only (text input always available)
- Automatic fallback to text if voice unavailable
- Cross-platform text functionality fully supported

---

## Testing Voice Features

### Test Text-to-Speech
```bash
dotnet run --project "src\CyberAwarenessBot\CyberAwarenessBot.csproj" -- --list-voices
```

### Test Voice Input
1. Run bot normally
2. Type `voice` at prompt
3. Speak clearly: "How do I stay safe online?"
4. Confirm recognized text

### Test Toggle
1. Type `toggle voice` to disable
2. Type `toggle voice` again to enable

### Test Voice Change
1. Type `change voice`
2. Select different voice
3. Verify next response uses new voice

---

## Common Interaction Patterns

**Pattern 1: Learning Mode**
- Enable voice responses
- Type cybersecurity questions
- Listen while reading (dual input)

**Pattern 2: Voice Input Mode**
- Type `voice` at each prompt
- Speak naturally
- Get spoken and text responses

**Pattern 3: Text-Only Mode**
- Run with `--no-voice`
- Pure text-based interaction
- No audio overhead

**Pattern 4: Accessibility Mode**
- Large font, high contrast (console settings)
- Text-only responses
- Keyboard navigation
