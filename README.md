# Cybersecurity Awareness Bot (Console)

![CI](https://github.com/OWNER/REPO/actions/workflows/dotnet.yml/badge.svg)

Overview

This is a simple C# console chatbot that provides basic cybersecurity guidance. It includes:
- A voice greeting (WAV) played on startup if an audio file is present.
- ASCII-art header and coloured console UI.
- Personalised conversation using the user's name (automatic properties used in Bot.cs).
- Basic responses about password safety, phishing, and safe browsing.
- Input validation and graceful fallbacks.

Getting started

Requirements
- .NET 6.0 SDK or later

Build and run

1. Open a terminal in the repository root.
2. Build: dotnet build src/CyberAwarenessBot
3. Run: dotnet run --project src/CyberAwarenessBot

Convenience scripts

You can also use the provided helper scripts from the repository root:
- Unix: ./run.sh
- Windows PowerShell: .\run.ps1

The application will generate a short example WAV (assets/greeting.wav) at first run if no greeting file is present; place a recorded greeting there to replace it.

Adding the voice greeting

Place a WAV file at assets/greeting.wav (path relative to the executable). The program will attempt to play it on startup. If not present, it will continue silently.

Project structure

- src/CyberAwarenessBot: main project
- assets: place audio file here (not included in repo by default)

Notes for instructors

This project demonstrates:
- Console I/O and validation
- String manipulation and simple NLP-style matching
- Use of automatic properties
- Separation of concerns using classes and helper methods

Assignment checklist

The project implements the following learning outcomes required by the assignment:
- Write a console programme that requires user input (asks for user's name and questions).
- Apply string manipulation to solve a programming problem (Bot.GetResponse uses string matching and normalization).
- Use automatic properties (Bot.UserName and Bot.Topics).
- Play a WAV greeting when available (assets/greeting.wav). A short silent WAV is generated automatically if none is provided.
- Display ASCII art header and use coloured/structured console UI with typing effects and dividers.
- Input validation and fallback responses are implemented.

Notes about audio

The repo does not include a recorded voice WAV by default. To provide a personalised voice greeting, add a WAV file at assets/greeting.wav (recommended WAV, 1-5s). On first run the app creates a short silent WAV so playback is safe even if you do not add your own greeting.

GitHub Actions

A basic workflow file is provided to build the project on each push.

License

This project is provided as-is for educational purposes.
![Uploading Screenshot 2026-04-14 153911.png…]()

