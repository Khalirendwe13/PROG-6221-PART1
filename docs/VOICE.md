Recording and installing a custom WAV greeting

This project includes a helper to write a recorded WAV file (base64) into `assets/greeting.wav` and a small PowerShell script to automate the process.

Recommended WAV format
- PCM 16-bit, mono or stereo
- 8000 or 16000 Hz are safe; SoundPlayer supports common PCM formats

Options

1) Quick manual (recommended)
- Record using Windows Voice Recorder, Audacity, etc.
- Export as WAV (PCM 16-bit)
- Copy the file to `assets/greeting.wav`

2) Use the included PowerShell helper (automated)
- Convert your WAV to base64 (PowerShell):
  ```powershell
  [Convert]::ToBase64String([IO.File]::ReadAllBytes('C:\path\to\your.wav')) | Set-Clipboard
  ```
- Run the script to write from clipboard:
  ```powershell
  .\scripts\write-greeting.ps1 -FromClipboard
  ```
- Or save the base64 to a file and run:
  ```powershell
  .\scripts\write-greeting.ps1 -Base64File .\mywav.base64
  ```

3) Programmatic (C# helper)
- The project contains `WriteGreetingFromBase64` at `src/CyberAwarenessBot/WriteGreetingFromBase64.cs`.
- Call it once from your code or a small one-off program:
  ```csharp
  // paste the base64 string into base64String variable
  CyberAwarenessBot.Tools.WriteGreetingFromBase64.Write(base64String);
  ```

After writing `assets/greeting.wav`, start the application on Windows; the app will play the WAV at startup using `System.Media.SoundPlayer`.

Notes
- Playback only attempted on Windows; on other platforms the app will silently skip playback.
- If `System.Speech` TTS is available, the app may synthesize greetings automatically and persist the voice choice in `assets/voice.config`.

