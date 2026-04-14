# Verify that .NET 8 runtime or SDK is installed
$found = $false
try {
    $runtimes = dotnet --list-runtimes 2>$null
    if ($LASTEXITCODE -ne 0) { throw "dotnet not found" }
    if ($runtimes -match "Microsoft\.NETCore\.App\s+8\.") { $found = $true }
} catch {
    Write-Error "dotnet CLI not found. Install .NET 8 SDK/runtime or use 'dotnet test' from an environment with .NET 8."
    exit 1
}
if (-not $found) {
    Write-Error "Required .NET 8 runtime not found. Please install .NET 8 runtime/SDK (e.g. 8.0.x)."
    Write-Host "dotnet --list-runtimes output:"; dotnet --list-runtimes
    exit 1
}
Write-Host "Found .NET 8 runtime."
exit 0
