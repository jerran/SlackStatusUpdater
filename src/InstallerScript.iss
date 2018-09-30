;Compile to create an executable installer after doing a Release build of the project

#define ApplicationName 'SlackStatusUpdater'
#define ApplicationVersion GetFileVersion('SlackStatusUpdater.exe')

[Setup]
AppName={#ApplicationName}
AppVerName={#ApplicationName} {#ApplicationVersion}
DefaultDirName={pf}\{#ApplicationName}
DisableProgramGroupPage=yes
UninstallDisplayIcon={app}\SlackStatusUpdater.exe
OutputDir=Installer
OutputBaseFilename=Setup{#ApplicationName}
PrivilegesRequired=admin
SourceDir=SlackStatusUpdater\bin\Release
DefaultGroupName=SlackStatusUpdater

[Files]
Source: "*"; DestDir: "{app}"; Excludes:"*.pdb"

[Tasks]
Name: autostart; Description: "Set SlackStatusUpdater to start automatically when Windows starts (can be changed later in settings)"
Name: startmenu; Description: "Add to Start Menu"; Flags: unchecked
Name: desktopshortcut; Description: "Create a desktop shortcut"; Flags: unchecked

[Icons]
Name: "{group}\SlackStatusUpdater"; Filename: "{app}\SlackStatusUpdater.exe"; WorkingDir: "{app}"; Tasks: startmenu
Name: "{group}\Uninstall SlackStatusUpdater"; Filename: "{uninstallexe}"; Tasks:startmenu
Name: "{commondesktop}\SlackStatusUpdater"; Filename: "{app}\SlackStatusUpdater.exe"; WorkingDir: "{app}"; Tasks: desktopshortcut

[Registry]
Root: HKCU; Subkey: "SOFTWARE\Microsoft\Windows\CurrentVersion\Run"; ValueType: string; ValueName: "SlackStatusUpdater"; ValueData: "{app}\SlackStatusUpdater.exe"; Flags: uninsdeletevalue; Tasks: autostart

[Run]
Filename: "{app}\SlackStatusUpdater.exe"; Description: "Launch application"; Flags: postinstall nowait skipifsilent
