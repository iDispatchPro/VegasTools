#define Ver "20.1"
#define T "{commonappdata}\Vegas Pro\20.0\Application extensions"
#define VP64 "{pf64}\Vegas\Vegas Pro 20"
#define AVS "{pf}\AviSynth 2.5"

[Setup]
AppId={{D07BF374-5FB2-4287-8ABA-A0EE7CEE96FE}
VersionInfoVersion={#Ver}
AppName=VegasTools
AppVerName=VegasTools {#Ver}
CreateAppDir=no
DisableReadyPage=yes
OutputDir=..
OutputBaseFilename=VegasTools {#Ver}
SetupIconFile=..\»конки\VegasTools.ico
UninstallDisplayIcon={#T}\VegasTools.ico
Compression=lzma
SolidCompression=yes

[Languages]
Name: "russian"; MessagesFile: "compiler:Languages\Russian.isl"

[Files]
Source: "Target\*.*"; DestDir: "{#T}"; Flags: ignoreversion recursesubdirs sortfilesbyextension

Source: "..\VegasTools\obj\VegasTools.dll"; DestDir: "{#T}"; Flags: ignoreversion

Source: "..\»конки\VegasTools.ico"; DestDir: "{#T}";

#Source: "Tools\AVISynth\System32\*.*"; DestDir: "{sys}"; Flags: regserver noregerror sortfilesbyextension
#Source: "Tools\AVISynth\Plugins\*.*"; DestDir: "{#AVS}\Plugins"; Flags: regserver noregerror sortfilesbyextension
#Source: "Tools\fssetup\VP\*.*"; DestDir: "{#VP64}"; Flags: noregerror sortfilesbyextension;
#Source: "Tools\fssetup\Sys\*.*"; DestDir: "{sys}"; Flags: noregerror sortfilesbyextension

Source: "File Templates\*.*"; DestDir: "{userappdata}\Sony\Render Templates\"; Flags: recursesubdirs sortfilesbyextension

[INI]
#Filename: "{#VP64}\Frameserver.x64.fio2007-config"; Section: "FileIO Plug-Ins"; Key: "frameserver"; String: "{#VP64}\dfscVegasV264Out.dll";

[Registry]
#Root: HKLM; Subkey: "SOFTWARE\AviSynth"; ValueType: string; ValueName: "plugindir2_5"; ValueData: {#AVS}\Plugins; Flags: uninsdeletekey
#Root: HKLM; Subkey: "SOFTWARE\Classes\.avs"; ValueType: string; ValueName: ""; ValueData: avsfile; Flags: uninsdeletekey
#Root: HKCR; Subkey: ".avs"; ValueType: string; ValueName: ""; ValueData: avs_auto_file; Flags: uninsdeletekey
#Root: HKCR; Subkey: "CLSID\{{E6D6B700-124D-11D4-86F3-DB80AFD98778}"; ValueType: string; ValueName: ""; ValueData: AviSynth; Flags: uninsdeletekey
#Root: HKCR; Subkey: "CLSID\{{E6D6B700-124D-11D4-86F3-DB80AFD98778}\InProcServer32"; ValueType: string; ValueName: ""; ValueData: AviSynth.dll; Flags: uninsdeletekey
#Root: HKCR; Subkey: "avifile\Extensions\avs"; ValueType: string; ValueName: ""; ValueData: {{E6D6B700-124D-11D4-86F3-DB80AFD98778}; Flags: uninsdeletekey
#Root: HKCR; Subkey: "Media Type\Extensions\.avs"; ValueType: string; ValueName: "Source Filter"; ValueData: {{D3588AB0-0781-11CE-B03A-0020AF0BA770}; Flags: uninsdeletekey
#Root: HKCR; Subkey: "CLSID\{{E6D6B700-124D-11D4-86F3-DB80AFD98778}\InProcServer32"; ValueType: string; ValueName: "ThreadingModel"; ValueData: Apartment; Flags: uninsdeletekey
#Root: HKCR; Subkey: ".avs"; ValueType: string; ValueName: ""; ValueData: avsfile; Flags: uninsdeletekey
#Root: HKCR; Subkey: "avsfile"; ValueType: string; ValueName: ""; ValueData: AviSynth Script; Flags: uninsdeletekey

#Root: HKLM64; Subkey: "SOFTWARE\DebugMode\FrameServer"; ValueType: string; ValueName: "InstallDir"; ValueData: {#VP64}; Flags: uninsdeletekey;

#Root: HKLM; Subkey: "Software\Microsoft\Windows NT\CurrentVersion\drivers.desc"; ValueType: string; ValueName: "dfsc.dll"; ValueData: "DebugMode FSVFWC (internal use)"; Flags: uninsdeletekey
#Root: HKLM; Subkey: "Software\Microsoft\Windows NT\CurrentVersion\drivers32"; ValueType: string; ValueName: "vidc.dfsc"; ValueData: "dfsc.dll"; Flags: uninsdeletekey

[UninstallDelete]
Type: files; Name: "{#T}\VegasTools\*.*"
