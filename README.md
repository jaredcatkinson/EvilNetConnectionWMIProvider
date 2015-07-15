Evil Network Connection WMI Provider
- Returns Netstat like Information when queried
- Contains a RunPs Method that executes arbitrary PowerShell as System

To install:
- Download and unzip project
- Open administrator prompt
- cd to directory containing EvilNetConnectionWMIProvider.dll (<downloadpath>\EvilNetConnectionWMIProvider-master\EvilNetConnectionWMIProvider\bin\Debug)
- run "InstallUtil.exe /i EvilNetConnectionWMIProvider.dll"
-- Uninstall "InstallUtil.exe /u EvilNetConnectionWMIProvider.dll"

To use:
- Open PowerShell
- Query Network Connections: Get-WMIObject Win32_NetConnection
- Arbitrary POSH: Invoke-WMIMethod -Class Win32_NetConnection -Name RunPs -ArgumentList "<powershell command>", $NULL

Examples:
- Invoke-WMIMethod -Class Win32_NetConnection -Name RunPs -ArgumentList "whoami", $NULL
- Invoke-WMIMethod -Class Win32_NetConnection -Name RunPs -ArgumentList "Get-Process", $NULL
