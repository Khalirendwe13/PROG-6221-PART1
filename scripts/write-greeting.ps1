param(
    [Parameter(Mandatory=$false)]
    [string]$Base64File,

    [Parameter(Mandatory=$false)]
    [switch]$FromClipboard,

    [Parameter(Mandatory=$false)]
    [string]$OutPath = "assets/greeting.wav"
)

if (-not $FromClipboard -and -not $Base64File) {
    Write-Error "Provide -Base64File <path> or -FromClipboard to read base64 from the clipboard."
    exit 1
}

try {
    if ($FromClipboard) {
        $base64 = Get-Clipboard -TextFormatType Text
    }
    else {
        if (-not (Test-Path $Base64File)) {
            Write-Error "Base64 file not found: $Base64File"
            exit 1
        }
        $base64 = Get-Content -Raw -Path $Base64File
    }

    if ([string]::IsNullOrWhiteSpace($base64)) {
        Write-Error "Base64 input is empty."
        exit 1
    }

    $bytes = [Convert]::FromBase64String($base64)
    $dir = Split-Path -Parent $OutPath
    if (-not [string]::IsNullOrWhiteSpace($dir)) { New-Item -ItemType Directory -Force -Path $dir | Out-Null }
    [IO.File]::WriteAllBytes($OutPath, $bytes)
    Write-Host "Wrote greeting WAV: $OutPath ($($bytes.Length) bytes)"
}
catch {
    Write-Error "Failed to write greeting WAV: $_"
    exit 1
}
