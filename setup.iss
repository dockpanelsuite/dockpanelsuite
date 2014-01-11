#define MyAppID "{2F72D7EF-F6FC-4832-8F21-26DA8E205F50}"
#define MyAppCopyright "Copyright (C) 2007-2013 Weifen Luo and other contributors"
#define MyAppName "DockPanel Suite"
#define MyAppVersion GetFileVersion(".\bin\net20\WeifenLuo.WinFormsUI.Docking.dll")
#define ConflictingProcess "devenv.exe"
#define ConflictingApp "Visual Studio"
#pragma message "Detailed version info: " + MyAppVersion

[Setup]
AppName={#MyAppName}
AppVerName={#MyAppName}
AppPublisher=DockPanel Suite maintainers
AppPublisherURL=http://dockpanelsuite.com
AppSupportURL=http://dockpanelsuite.com
AppUpdatesURL=http://dockpanelsuite.com
DefaultDirName={pf}\{#MyAppName}
DefaultGroupName={#MyAppName}
OutputDir=.
SolidCompression=true
AppCopyright={#MyAppCopyright}
VersionInfoVersion={#MyAppVersion}
VersionInfoCompany=LeXtudio
VersionInfoDescription={#MyAppName} {#MyAppVersion} Setup
VersionInfoTextVersion={#MyAppVersion}
InternalCompressLevel=ultra
VersionInfoCopyright={#MyAppCopyright}
PrivilegesRequired=admin
ShowLanguageDialog=yes
WindowVisible=false
AppVersion={#MyAppVersion}
AppId={{#MyAppID}
UninstallDisplayName={#MyAppName}
CompressionThreads=2
MinVersion=0,5.01sp3

[Languages]
Name: english; MessagesFile: compiler:Default.isl

[Files]
Source: ".\bin\net20\*.*"; DestDir: "{app}\net20"; Flags: ignoreversion
Source: ".\bin\net40\*.*"; DestDir: "{app}\net40"; Flags: ignoreversion
Source: ".\tools\*.*"; DestDir: "{app}"; Flags: ignoreversion

[Icons]
Name: "{group}\{cm:UninstallProgram,{#MyAppName}}"; Filename: "{uninstallexe}";
Name: "{group}\Report A Bug"; Filename: "https://github.com/dockpanelsuite/dockpanelsuite/issues"; 
Name: "{group}\Homepage"; Filename: "https://dockpanelsuite.com";

[Registry]
Root: "HKLM"; Subkey: "SOFTWARE\Microsoft\.NETFramework\v2.0.50727\AssemblyFoldersEx\DockPanelSuite"; ValueType: string; ValueData: "{app}\net20\"; Flags: uninsdeletekey
Root: "HKLM"; Subkey: "SOFTWARE\Microsoft\.NETFramework\v4.0.30319\AssemblyFoldersEx\DockPanelSuite"; ValueType: string; ValueData: "{app}\net40\"; Flags: uninsdeletekey

[Run]
Filename: "{app}\Toolbox.exe"; Parameters: "/vs2008 /installdesktop ""{app}\net20\WeifenLuo.WinFormsUI.Docking.dll"" ""DockPanel Suite"""; WorkingDir: "{app}"; Flags: waituntilterminated
Filename: "{app}\Toolbox.exe"; Parameters: "/vs2010 /installdesktop ""{app}\net20\WeifenLuo.WinFormsUI.Docking.dll"" ""DockPanel Suite"""; WorkingDir: "{app}"; Flags: waituntilterminated
Filename: "{app}\Toolbox.exe"; Parameters: "/vs2012 /installdesktop ""{app}\net20\WeifenLuo.WinFormsUI.Docking.dll"" ""DockPanel Suite"""; WorkingDir: "{app}"; Flags: waituntilterminated

[UninstallRun]
Filename: "{app}\Toolbox.exe"; Parameters: "/vs2008 /uninstall ""DockPanel Suite"""; WorkingDir: "{app}"; Flags: waituntilterminated
Filename: "{app}\Toolbox.exe"; Parameters: "/vs2010 /uninstall ""DockPanel Suite"""; WorkingDir: "{app}"; Flags: waituntilterminated
Filename: "{app}\Toolbox.exe"; Parameters: "/vs2012 /uninstall ""DockPanel Suite"""; WorkingDir: "{app}"; Flags: waituntilterminated

[Code]
// =======================================
// Testing if under Windows safe mode
// =======================================
function GetSystemMetrics( define: Integer ): Integer; external
'GetSystemMetrics@user32.dll stdcall';

Const SM_CLEANBOOT = 67;

function IsSafeModeBoot(): Boolean;
begin
  // 0 = normal boot, 1 = safe mode, 2 = safe mode with networking
 Result := ( GetSystemMetrics( SM_CLEANBOOT ) <> 0 );
end;

// ======================================
// Testing version number string
// ======================================
function GetNumber(var temp: String): Integer;
var
  part: String;
  pos1: Integer;
begin
  if Length(temp) = 0 then
  begin
    Result := -1;
    Exit;
  end;
  pos1 := Pos('.', temp);
  if (pos1 = 0) then
  begin
    Result := StrToInt(temp);
  temp := '';
  end
  else
  begin
  part := Copy(temp, 1, pos1 - 1);
    temp := Copy(temp, pos1 + 1, Length(temp));
    Result := StrToInt(part);
  end;
end;

function CompareInner(var temp1, temp2: String): Integer;
var
  num1, num2: Integer;
begin
  num1 := GetNumber(temp1);
  num2 := GetNumber(temp2);
  if (num1 = -1) or (num2 = -1) then
  begin
    Result := 0;
    Exit;
  end;
  if (num1 > num2) then
  begin
  Result := 1;
  end
  else if (num1 < num2) then
  begin
  Result := -1;
  end
  else
  begin
  Result := CompareInner(temp1, temp2);
  end;
end;

function CompareVersion(str1, str2: String): Integer;
var
  temp1, temp2: String;
begin
  temp1 := str1;
  temp2 := str2;
  Result := CompareInner(temp1, temp2);
end;

function DotNetFrameworkInstalled(): Boolean;
begin
  Result := RegKeyExists(HKLM, 'Software\Microsoft\.NETFramework\policy\v2.0');
end;

function DotNetFramework4Installed(): Boolean;
begin
  Result := RegKeyExists(HKLM, 'Software\Microsoft\.NETFramework\policy\v4.0');
end;

function IsAppRunning(const FileName : string): Boolean;
var
    FSWbemLocator: Variant;
    FWMIService   : Variant;
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

function ProductRunning(): Boolean;
begin       
  Result := IsAppRunning('{#ConflictingApp}');
  Exit;
end;

function ProductInstalled(): Boolean;
begin
  Result := RegKeyExists(HKEY_LOCAL_MACHINE,
  'SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\{#MyAppID}_is1');
end;

function InitializeSetup(): Boolean;
var
  oldVersion: String;
  uninstaller: String;
  ErrorCode: Integer;
  compareResult: Integer;
  ResultCode: Integer;
begin
  if IsSafeModeBoot then
  begin
    MsgBox('Cannot install under Windows Safe Mode.', mbError, MB_OK);
    Result := False;
    Exit;
  end;
  
  while ProductRunning do
  begin
    if MsgBox( '{#ConflictingApp} is running. Click Yes to shut it down and continue installation, or click No to exit.', mbConfirmation, MB_YESNO ) = IDNO then
    begin
      Result := False;
      Exit;
    end;

    Exec('cmd.exe', '/C "taskkill /F /IM {#ConflictingProcess}"', '', SW_HIDE,
     ewWaitUntilTerminated, ResultCode);
  end;

  if not ProductInstalled then
  begin
    Result := True;
    Exit;
  end;

  RegQueryStringValue(HKEY_LOCAL_MACHINE,
    'SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\{#MyAppID}_is1',
    'DisplayVersion', oldVersion);
  compareResult := CompareVersion(oldVersion, '{#MyAppVersion}');
  if (compareResult > 0) then
  begin
    MsgBox('Version ' + oldVersion + ' of {#MyAppName} is already installed. It is newer than {#MyAppVersion}. This installer will exit.',
    mbInformation, MB_OK);
    Result := False;
    Exit;
  end
  else if (compareResult = 0) then
  begin
    if (MsgBox('{#MyAppName} ' + oldVersion + ' is already installed. Do you want to repair it now?',
    mbConfirmation, MB_YESNO) = IDNO) then
  begin
    Result := False;
    Exit;
    end;
  end
  else
  begin
    if (MsgBox('{#MyAppName} ' + oldVersion + ' is already installed. Do you want to override it with {#MyAppVersion} now?',
    mbConfirmation, MB_YESNO) = IDNO) then
  begin
    Result := False;
    Exit;
    end;
  end;
  // remove old version
  RegQueryStringValue(HKEY_LOCAL_MACHINE,
  'SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\{#MyAppID}_is1',
  'UninstallString', uninstaller);
  ShellExec('runas', uninstaller, '/SILENT', '', SW_HIDE, ewWaitUntilTerminated, ErrorCode);
  if (ErrorCode <> 0) then
  begin
  MsgBox( 'Failed to uninstall {#MyAppName} version ' + oldVersion + '. Please restart Windows and run setup again.',
   mbError, MB_OK );
  Result := False;
  Exit;
  end;

  Result := True;
end;

function InitializeUninstall(): Boolean;
var
  ResultCode: Integer;
begin
  if IsSafeModeBoot then
  begin
    MsgBox( 'Cannot uninstall under Windows Safe Mode.', mbError, MB_OK);
    Result := False;
    Exit;
  end;

  while ProductRunning do
  begin
    if MsgBox( '{#ConflictingApp} is running. Click Yes to shut it down and continue installation, or click No to exit.', mbConfirmation, MB_YESNO ) = IDNO then
    begin
      Result := False;
      Exit;
    end;

    Exec('cmd.exe', '/C "taskkill /F /IM {#ConflictingProcess}"', '', SW_HIDE,
     ewWaitUntilTerminated, ResultCode)
  end;

  Result := true;
end;

procedure CurStepChanged(CurStep: TSetupStep);
var
  ErrorCode: Integer;
begin
  if (CurStep = ssPostInstall) then
  begin
    if DotNetFramework4Installed then
    begin
      ShellExec('', ExpandConstant('{app}\gacutil_4.0.exe'),
        ExpandConstant('-i "{app}\net40\WeifenLuo.WinFormsUI.Docking.dll"'), '', SW_HIDE, ewWaitUntilTerminated, ErrorCode);     
    end;

    if DotNetFrameworkInstalled then
    begin
      ShellExec('', ExpandConstant('{app}\gacutil_2.0.exe'),
        ExpandConstant('-i "{app}\net20\WeifenLuo.WinFormsUI.Docking.dll"'), '', SW_HIDE, ewWaitUntilTerminated, ErrorCode);     
    end; 
  end;
end;

procedure CurUninstallStepChanged(CurUninstallStep: TUninstallStep);
var
  ErrorCode: Integer;
begin
  if (CurUninstallStep = usAppMutexCheck) then
  begin
    if DotNetFramework4Installed then
    begin
      ShellExec('', ExpandConstant('{app}\gacutil_4.0.exe'),
        '-u WeifenLuo.WinFormsUI.Docking', '', SW_HIDE, ewWaitUntilTerminated, ErrorCode);    
    end;

    if DotNetFrameworkInstalled then
    begin
      ShellExec('', ExpandConstant('{app}\gacutil_2.0.exe'),
        '-u WeifenLuo.WinFormsUI.Docking', '', SW_HIDE, ewWaitUntilTerminated, ErrorCode);    
    end;
  end;
end;
