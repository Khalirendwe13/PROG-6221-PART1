# Voice Features Architecture & Flow Diagrams

## 🏗️ System Architecture

```
┌─────────────────────────────────────────────────────────────────────┐
│                    CYBERSECURITY AWARENESS BOT                       │
└─────────────────────────────────────────────────────────────────────┘

┌──────────────────┐
│   User Input     │
├──────────────────┤
│ • Text (Console) │
│ • Voice (Mic)    │
│ • Commands       │
└────────┬─────────┘
         │
         ▼
┌──────────────────────────────────────────────────┐
│          PROGRAM.CS - Main Controller            │
│  ┌──────────────────────────────────────────┐   │
│  │ • Parse Commands                         │   │
│  │ • Route to Handlers                      │   │
│  │ • Manage Flow Control                    │   │
│  │ • Coordinate Components                  │   │
│  └──────────────────────────────────────────┘   │
└──────┬──────────────────────────┬──────────────┘
       │                          │
       ▼                          ▼
  ┌─────────────┐    ┌──────────────────────┐
  │   Bot.cs    │    │  ConsoleUI.cs        │
  │             │    │                      │
  │ • Response  │    │ • Display Text       │
  │   Database  │    │ • Color Output       │
  │ • Question  │    │ • Collect Input      │
  │   Matching  │    │ • Format Display     │
  │ • Personal- │    │ • Animations         │
  │   ization   │    │                      │
  └─────────────┘    └──────────────────────┘
       │
       ▼
┌──────────────────────────────┐
│   Bot Response Generated     │
└──────┬───────────────────────┘
       │
       ▼
┌──────────────────────────────────────────────────┐
│  VOICE RESPONSE HANDLER (New Component)          │
│  ┌──────────────────────────────────────────┐   │
│  │ • Synthesis Response Text                │   │
│  │ • Create WAV File                        │   │
│  │ • Play Audio (SoundPlayer)               │   │
│  │ • Cleanup Temp Files                     │   │
│  └──────────────────────────────────────────┘   │
│           │                      │               │
│           ▼                      ▼               │
│      System.Speech            temp_response.wav │
│      .Synthesis               (Auto-cleaned)    │
│                                                  │
└──────────────────────────────────────────────────┘
       │
       ▼
  ┌─────────────┐
  │  Speakers   │
  │   (Audio)   │
  └─────────────┘

                    ▲
                    │
         ┌──────────┴──────────┐
         │                     │
    ┌────────────────┐   ┌─────────────┐
    │ VOICE INPUT    │   │ TEXT INPUT  │
    │ (New Feature)  │   │ (Existing)  │
    ├────────────────┤   └─────────────┘
    │ • Microphone   │
    │ • Speech       │
    │   Recognition  │
    │ • Convert to   │
    │   Text         │
    └────────────────┘

```

---

## 🔄 User Interaction Flow

```
START
  │
  ▼
┌─────────────────────────────────┐
│  Initialize Application         │
│  • Load Config                  │
│  • Setup Speech Recognition     │
│  • Create Assets Directory      │
└────────────┬────────────────────┘
             │
             ▼
┌─────────────────────────────────┐
│  Play Voice Greeting            │
│  • Synthesize greeting          │
│  • Play WAV file                │
│  • Wait for audio playback      │
└────────────┬────────────────────┘
             │
             ▼
┌─────────────────────────────────┐
│  Collect User Name              │
│  • Display prompt               │
│  • Store for personalization    │
└────────────┬────────────────────┘
             │
             ▼
┌─────────────────────────────────┐
│  Main Interaction Loop          │
│                                 │
│  ┌─────────────────────────┐    │
│  │ PROMPT USER             │    │
│  │ "Ask a question..."     │    │
│  └──────────┬──────────────┘    │
│             │                   │
│    ┌────────┴────────┐          │
│    │                 │          │
│    ▼                 ▼          │
│  TEXT INPUT     VOICE COMMAND   │
│    │                 │          │
│    ├─ Text Cmd ──┐   ├─ "voice"─┤
│    │             │   │          │
│    ▼             │   ▼          │
│  "password"      │   LISTEN     │
│    │             │   (5 sec)    │
│    │             │   │          │
│    ▼             │   ▼          │
│  Query Bot ◄──────┘ RECOGNIZE   │
│    │                 │          │
│    └─────────┬───────┘          │
│              │                  │
│              ▼                  │
│         ┌─────────────┐         │
│         │ Generate    │         │
│         │ Response    │         │
│         └────┬────────┘         │
│              │                  │
│              ▼                  │
│         ┌─────────────┐         │
│         │ Display     │         │
│         │ Response    │         │
│         └────┬────────┘         │
│              │                  │
│              ▼                  │
│         ┌─────────────────┐     │
│         │ Play Voice?     │     │
│         │ If Enabled      │     │
│         └────┬────┬───────┘     │
│              │    │             │
│          YES ▼    ▼ NO          │
│         SYNTH   SKIP            │
│           │      │              │
│           └──┬───┘              │
│              │                  │
│              ▼                  │
│         ┌─────────────┐         │
│         │ Continue?   │         │
│         └────┬────────┘         │
│              │                  │
│         ┌────┴────┐             │
│         │          │            │
│       YES         NO            │
│         │          │            │
│         └──┬─      BREAK        │
│            │                    │
└────────────┼────────────────────┘
             │
             ▼
┌─────────────────────────────────┐
│  Exit Application               │
│  • Display goodbye message      │
│  • Play voice goodbye           │
│  • Cleanup resources            │
│  • Save preferences             │
└─────────────────────────────────┘
END

```

---

## 🎙️ Voice Response Processing

```
User Question
    │
    ▼
┌──────────────────────────────┐
│ Bot.GetResponse()            │
│ • Search response database   │
│ • Match question             │
│ • Return answer              │
└────────┬─────────────────────┘
         │
         ▼
    Response String
    "Strong passwords are..."
         │
         ▼
┌──────────────────────────────────────────┐
│ Display Response (ConsoleUI)             │
│ • Color-coded output                     │
│ • Formatted text                         │
│ • Animated typing effect                 │
└────────┬───────────────────────────────┬─┘
         │                               │
         ▼                               ▼
      Console                    Check if Voice Enabled?
     (Text Display)              
                                        │
                                   ┌────┴────┐
                                   │          │
                                NO ▼         ▼ YES
                               SKIP      ┌─────────────┐
                                │        │ Synthesize  │
                                │        │ Response    │
                                │        │ Text→Speech │
                                │        │ (System.    │
                                │        │  Speech)    │
                                │        └────┬────────┘
                                │             │
                                │             ▼
                                │        ┌─────────────┐
                                │        │ Save WAV    │
                                │        │ File        │
                                │        │ (temp)      │
                                │        └────┬────────┘
                                │             │
                                │             ▼
                                │        ┌─────────────┐
                                │        │ Play Audio  │
                                │        │ (Sound      │
                                │        │  Player)    │
                                │        └────┬────────┘
                                │             │
                                │             ▼
                                │        ┌─────────────┐
                                │        │ Cleanup     │
                                │        │ Temp File   │
                                │        └────┬────────┘
                                │             │
                                └─────┬───────┘
                                      │
                                      ▼
                                   DONE

```

---

## 🗣️ Voice Input Processing

```
User Command: "voice"
    │
    ▼
┌──────────────────────────┐
│ Recognize Voice Input    │
│ (SpeechRecognitionHandler)
└────────┬─────────────────┘
         │
         ▼
┌──────────────────────────┐
│ Initialize Recognizer   │
│ • Load Assembly          │
│ • Create Instance        │
│ • Set Timeout (5 sec)    │
└────────┬─────────────────┘
         │
         ▼
    ┌────────────────────┐
    │ LISTENING STATE    │
    │ (5 Second Window)  │
    └────┬───────────────┘
         │
    ┌────┴──────┐
    │            │
    ▼            ▼
SPEECH      SILENCE
DETECTED    (TIMEOUT)
    │            │
    ▼            ▼
┌───────────┐  ┌─────────────────┐
│ Process   │  │ Return NULL     │
│ Audio     │  │ Prompt retry    │
│ Frame     │  └─────────────────┘
└────┬──────┘
     │
     ▼
┌──────────────────────┐
│ Recognize Text       │
│ • Speech→Text Engine │
│ • Match Words        │
│ • Confidence Check   │
└────┬────────────────┘
     │
     ▼
Recognized String
"How do I stay safe?"
     │
     ▼
┌─────────────────────────┐
│ Display Result          │
│ "You said: ..."         │
│ (User Confirmation)     │
└────┬────────────────────┘
     │
     ▼
Return to Main Loop
(Treat as Text Input)

```

---

## ⚙️ Voice Configuration Management

```
┌─────────────────────────────────────────┐
│  Application Start                      │
└────────────┬────────────────────────────┘
             │
             ▼
┌─────────────────────────────────────────┐
│  Check voice.config File                │
│  Location: assets/voice.config          │
└────┬───────────────────────────┬────────┘
     │                           │
   EXISTS                    NOT EXISTS
     │                           │
     ▼                           ▼
┌──────────────┐         ┌───────────────┐
│ Read Saved   │         │ Probe for     │
│ Voice Name   │         │ Default Voice │
└──────┬───────┘         │ (Zira Desktop)│
       │                 └───────┬───────┘
       │                         │
       ▼                         ▼
┌──────────────────────┐  ┌─────────────┐
│ Use Saved Voice      │  │ Voice Found?│
│ for Responses        │  └────┬───┬────┘
└──────────────────────┘       │   │
                            YES│   │NO
                               │   │
                      ┌────────┘   │
                      │            ▼
                      │      ┌──────────────┐
                      │      │ Use Default  │
                      │      │ (Zira)       │
                      │      └──────┬───────┘
                      │             │
                      │      ┌──────┴─────────┐
                      │      │                │
                      │      ▼                ▼
                      │    ASK USER    SAVE CONFIG
                      │    "Use this   
                      │     voice?"
                      │
                      ▼
            ┌─────────────────────┐
            │ Set Preferred Voice │
            │ VoiceResponseHandler│
            │ .SetPreferredVoice()│
            └─────────────────────┘
                     │
                     ▼
            ┌─────────────────────┐
            │ Use for All         │
            │ Responses & Greetings
            └─────────────────────┘

```

---

## 🔊 Component Interaction Diagram

```
┌─────────────────────────────────────────────────────────────────┐
│                          PROGRAM.CS                              │
│  (Central Controller & Main Loop)                               │
│                                                                  │
│  ┌──────────────────────────────────────────────────────────┐   │
│  │ INITIALIZATION                                           │   │
│  │ • Setup voice preferences                               │   │
│  │ • Load voice config                                     │   │
│  │ • Initialize speech recognition                         │   │
│  │ • Create greeting WAV                                   │   │
│  └──────────────────────────────────────────────────────────┘   │
│                                                                  │
│  ┌──────────────────────────────────────────────────────────┐   │
│  │ MAIN LOOP                                                │   │
│  │                                                          │   │
│  │  Gets Input ──┬─────────────────────────────────────┐   │   │
│  │               │                                     │   │   │
│  │               ▼                                     ▼   │   │
│  │         ┌──────────────┐           ┌──────────────┐    │   │
│  │         │  Text Input  │           │ Voice Input  │    │   │
│  │         │  from Console│           │  from Mic    │    │   │
│  │         └──────┬───────┘           └──────┬───────┘    │   │
│  │                │                          │            │   │
│  │                └──────────────┬───────────┘            │   │
│  │                               │                        │   │
│  │                 ┌─────────────▼──────────────┐         │   │
│  │                 │  Process Input/Command    │         │   │
│  │                 │  • Parse user input       │         │   │
│  │                 │  • Route to handler       │         │   │
│  │                 └─────────────┬──────────────┘         │   │
│  │                               │                        │   │
│  │        ┌──────────────────────┼──────────────────┐    │   │
│  │        │                      │                  │    │   │
│  │        ▼                      ▼                  ▼    │   │
│  │   ┌──────────┐      ┌──────────────┐      ┌────────┐ │   │
│  │   │  Command │      │  Question    │      │ Action │ │   │
│  │   │ (help,   │      │  (regular    │      │ (voice,│ │   │
│  │   │ exit,    │      │  query)      │      │ toggle)│ │   │
│  │   │ toggle)  │      │              │      │        │ │   │
│  │   └────┬─────┘      └────┬─────────┘      └───┬────┘ │   │
│  │        │                 │                    │      │   │
│  │        ▼                 ▼                    ▼      │   │
│  │   ┌─────────────┐   ┌─────────────┐    ┌─────────┐  │   │
│  │   │ConsoleUI    │   │BOT.CS       │    │Special  │  │   │
│  │   │(Display)    │   │(Respond)    │    │Handler  │  │   │
│  │   └──────┬──────┘   └──────┬──────┘    └────┬────┘  │   │
│  │          │                 │                │       │   │
│  │          └─────────┬───────┘                │       │   │
│  │                    │                        │       │   │
│  │              ┌─────▼───────────────────────┘       │   │
│  │              │                                     │   │
│  │              ▼                                     │   │
│  │        ┌──────────────────────────────┐           │   │
│  │        │ VoiceResponseHandler         │           │   │
│  │        │ • Synthesize response        │           │   │
│  │        │ • Play audio (if enabled)    │           │   │
│  │        │ • Cleanup files              │           │   │
│  │        └──────────┬───────────────────┘           │   │
│  │                   │                               │   │
│  │                   ▼                               │   │
│  │              SPEAKERS (Output)                    │   │
│  │                                                   │   │
│  │        ┌──────────────────────────────┐           │   │
│  │        │ Loop until EXIT              │           │   │
│  │        └──────────────────────────────┘           │   │
│  └──────────────────────────────────────────────────────┘   │
│                                                              │
└──────────────────────────────────────────────────────────────┘

```

---

## 📊 Data Flow: Text Response with Voice

```
User Input: "password"
    │
    ├─→ Bot.GetResponse("password", out handled)
    │       │
    │       ▼
    │   Find "password" in dictionary
    │       │
    │       ▼
    │   return: "Strong passwords are long..."
    │           handled = true
    │
    ├─→ ConsoleUI.TypeWriteAsync(response)
    │       │
    │       ▼
    │   Display: "Strong passwords are long..."
    │       │
    │       ▼
    │   User sees: colored text, animated effect
    │
    └─→ if (enableVoiceResponses)
            │
            ▼
        VoiceResponseHandler.SynthesizeAndPlayResponseAsync(response)
            │
            ├─→ SynthesizeResponse(response, "assets/temp_response.wav")
            │       │
            │       ▼
            │   Assembly.Load("System.Speech")
            │       │
            │       ▼
            │   SpeechSynthesizer synth = new()
            │       │
            │       ▼
            │   synth.SetOutputToWaveFile("assets/temp_response.wav")
            │       │
            │       ▼
            │   synth.Speak("Strong passwords are...")
            │       │
            │       ▼
            │   return File exists && > 44 bytes
            │
            └─→ PlayAudioAsync("assets/temp_response.wav")
                    │
                    ▼
                SoundPlayer player = new(path)
                    │
                    ▼
                player.Play()
                    │
                    ▼
                await Task.Delay(500)
                    │
                    ▼
                Audio plays to speakers
                    │
                    ▼
                File cleanup (auto-delete)

```

---

## 🎯 Command Processing Flow

```
User Input: "toggle voice"
    │
    ▼
Program.cs checks input
    │
    ├─ Is "help"?           → Show commands → Continue loop
    │
    ├─ Is "change voice"?   → List voices → Get selection → Continue loop
    │
    ├─ Is "toggle voice"?   ──┐
    │                         │
    │                         ▼
    │                  enableVoiceResponses = !enableVoiceResponses
    │                         │
    │                         ▼
    │                  Display: "Voice responses: ENABLED/DISABLED"
    │                         │
    │                         ▼
    │                  Continue loop
    │
    ├─ Is "exit"/"quit"?   → Goodbye → Break loop → Exit
    │
    └─ Is "voice"?         → SpeechRecognition.RecognizeSpeech()
                                    │
                                    ▼
                            Return recognized text
                                    │
                                    ▼
                            Process as regular input

```

---

## 🔐 Error Handling Flow

```
Operation Attempts
    │
    ├─→ Synthesis fails (no System.Speech)
    │       │
    │       ▼
    │   Return false, skip voice
    │   Continue with text only
    │
    ├─→ Voice not available
    │       │
    │       ▼
    │   Use default or skip
    │   No crash, text continues
    │
    ├─→ Recognition timeout
    │       │
    │       ▼
    │   Return null
    │   Show: "Recognition timeout"
    │   Prompt: "Please try again"
    │
    ├─→ Microphone unavailable
    │       │
    │       ▼
    │   SpeechRecognitionHandler.IsAvailable = false
    │   Show: "Voice recognition not available"
    │   Prompt: "Use text input instead"
    │
    ├─→ Empty input
    │       │
    │       ▼
    │   Validate early
    │   Show: "I didn't understand"
    │   Prompt: "Could you rephrase?"
    │
    └─→ Audio file locked
            │
            ▼
        Wait & retry
        Auto-cleanup delayed
        No crash, continues

```

---

This comprehensive architecture shows how all voice components work together seamlessly with the existing bot system!
