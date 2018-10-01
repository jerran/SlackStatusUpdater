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

[Code]
function IsAppRunning(const FileName : string): Boolean;
var
FSWbemLocator: Variant;
FWMIService : Variant;
FWbemObjectSet: Variant;
begin
Result := false;
FSWbemLocator := CreateOleObject('WBEMScripting.SWBEMLocator');
FWMIService := FSWbemLocator.ConnectServer('', 'root\CIMV2', '', '');
FWbemObjectSet := FWMIService.ExecQuery(Format('SELECT Name FROM Win32_Process Where Name="%s"',[FileName]));
Result := (FWbemObjectSet.Count > 0);
FWbemObjectSet := Unassigned;
FWMIService := Unassigned;
FSWbemLocator := Unassigned;
end;

function InitializeSetup: boolean;
begin
result := not IsAppRunning('SlackStatusUpdater.exe');
if not result then
MsgBox('SlackStatusUpdater is running. Please close the application before running the installer ', mbError, MB_OK);
end;

function InitializeUninstall(): Boolean;
begin
result := not IsAppRunning('SlackStatusUpdater.exe');
if not result then
MsgBox('SlackStatusUpdater is running. Please close the application before running the uninstaller ', mbError, MB_OK);
end;