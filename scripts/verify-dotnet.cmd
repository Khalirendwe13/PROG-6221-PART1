@echo off
REM Verify .NET 8 runtime is installed
dotnet --list-runtimes > "%TEMP%\dotnet-runtimes.txt" 2>nul
if %ERRORLEVEL% neq 0 (
  echo dotnet CLI not found. Install .NET 8 SDK/runtime.
  exit /b 1
)
findstr /R "Microsoft.NETCore.App 8\." "%TEMP%\dotnet-runtimes.txt" >nul
if %ERRORLEVEL% neq 0 (
  echo Required .NET 8 runtime not found. Please install .NET 8.
  type "%TEMP%\dotnet-runtimes.txt"
  del "%TEMP%\dotnet-runtimes.txt" >nul 2>nul
  exit /b 1
)
echo Found .NET 8 runtime.
del "%TEMP%\dotnet-runtimes.txt" >nul 2>nul
exit /b 0
