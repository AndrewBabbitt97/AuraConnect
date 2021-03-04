[Setup]
AppName=AURA Connect
AppVersion=1.1.0
WizardStyle=modern
DefaultDirName={autopf32}\ASUS\AURACONNECT
DefaultGroupName=AURA Connect
UninstallDisplayName=AURA Connect
UninstallDisplayIcon={app}\AuraConnect.exe
Compression=lzma2
SolidCompression=yes
OutputDir=..\bin\Setup\
OutputBaseFilename=AuraConnectSetup
PrivilegesRequired=admin
CloseApplications=force
AppPublisher=ASUSTeK Computer Inc.

[Files]
Source: "..\bin\Release\netcoreapp3.1\win-x86\publish\**"; DestDir: "{app}"; Flags: recursesubdirs ignoreversion

[Run]
Filename: "{sys}\sc.exe"; Parameters: "create AuraConnect start=auto binpath=""{app}\AuraConnect.exe"""; StatusMsg: "Installing AURA Connect Service..."; Flags: runhidden
Filename: "{sys}\sc.exe"; Parameters: "config AuraConnect depend=LightingService"; StatusMsg: "Configuring AURA Connect Service..."; Flags: runhidden
Filename: "{sys}\sc.exe"; Parameters: "start AuraConnect"; StatusMsg: "Starting AURA Connect Service..."; Flags: runhidden

[UninstallRun]
Filename: "{sys}\sc.exe"; Parameters: "stop AuraConnect"; StatusMsg: "Stopping AURA Connect Service..."; Flags: runhidden
Filename: "{sys}\sc.exe"; Parameters: "delete AuraConnect"; StatusMsg: "Uninstalling AURA Connect Service..."; Flags: runhidden
