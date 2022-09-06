using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using VegasTools;

public class TSysHelper
{
    public TSysHelper(TVT_Options AOptions)
    {
        FOptions = AOptions;
    }

    TVT_Options FOptions;

    TDeskTop DeskTop = new TDeskTop();

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct TokPriv1Luid
    {
        public int Count;
        public long Luid;
        public int Attr;
    }

    [DllImport("kernel32.dll", ExactSpelling = true)]
    internal static extern IntPtr GetCurrentProcess();

    [DllImport("advapi32.dll", ExactSpelling = true, SetLastError = true)]
    internal static extern bool OpenProcessToken(IntPtr h, int acc, ref IntPtr phtok);

    [DllImport("advapi32.dll", SetLastError = true)]
    internal static extern bool LookupPrivilegeValue(string host, string name, ref long pluid);

    [DllImport("advapi32.dll", ExactSpelling = true, SetLastError = true)]
    internal static extern bool AdjustTokenPrivileges(IntPtr htok, bool disall,
        ref TokPriv1Luid newst, int len, IntPtr prev, IntPtr relen);

    [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
    internal static extern bool ExitWindowsEx(int flg, uint rea);

    public void KillProcess(String AName)
    {
        Process[] Processes = Process.GetProcessesByName(AName);

        foreach (Process p in Processes)
        {
            try
            {
                p.Kill();
            }
            catch
            {

            }
        }
    }

    public bool ShutDown(bool AReboot, bool AForce)
    {
        TokPriv1Luid tp;
        IntPtr hproc = GetCurrentProcess();
        IntPtr htok = IntPtr.Zero;
        OpenProcessToken(hproc, 0x00000020 | 0x00000008, ref htok);
        tp.Count = 1;
        tp.Luid = 0;
        tp.Attr = 0x00000002;
        LookupPrivilegeValue(null, "SeShutdownPrivilege", ref tp.Luid);
        AdjustTokenPrivileges(htok, false, ref tp, 0, IntPtr.Zero, IntPtr.Zero);

        int Flag;

        if (AReboot)
        {
            Flag = 0x00000002;
        }
        else
        {
            Flag = 0x00000001;
        }

        if (AForce)
        {
            Flag += 0x00000004;
        }

        return ExitWindowsEx(Flag, 0x00040000 | 0x000000ff | 0x80000000);
    }

    public string Convert(Encoding ASourceEncoding, Encoding ATargetEncoding, string AText)
    {
        byte[] A = ASourceEncoding.GetBytes(AText);

        A = Encoding.Convert(ASourceEncoding, ATargetEncoding, A);

        return new string(ATargetEncoding.GetChars(A));
    }

    public String MyPath
    {
        get
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\VegasTools\\";
        }
    }

    public int SendMessage(int AHandle, int AMessage, int wParam, int lParam)
    {
        return _SendMessage(AHandle, AMessage, wParam, lParam);
    }

    public void HideWindow(int AHandle)
    {
        if (AHandle > 0)
            _ShowWindow(AHandle, 0);
    }

    public void ShowWindow(int AHandle)
    {
        _ShowWindow(AHandle, 3);
    }

    public void MinimizeWindow(int AHandle)
    {
        _ShowWindow(AHandle, 2);
    }

    public int TryFindWindow(String AClass, String AName)
    {
        return _FindWindow(AClass, AName);
    }

    public int FindWindow(String AClass, String AName, int ATimeOut)
    {
        DateTime Start = DateTime.Now;

        int Handle = 0;

        while (Handle == 0)
        {
            Application.DoEvents();

            Handle = _FindWindow(AClass, AName);

            if ((Handle == 0) && (DateTime.Now > Start.AddMilliseconds(ATimeOut)))
            {
                throw new TimeoutException();
            }

            System.Threading.Thread.Sleep(50);
        }

        return Handle;
    }

    // ∆дем окна вечно
    public int FindWindow(String AClass, String AName)
    {
        return FindWindow(AClass, AName, int.MaxValue);
    }

    public void CloseWindow(int AHandle)
    {
        if (AHandle > 0)
            _SendMessage(AHandle, 16, 0, 0); // WM_Close        
    }

    public void CloseWindow(String AClass, String AName)
    {
        CloseWindow(FindWindow(AClass, AName, int.MaxValue));
    }

    public RegistryKey GetSubKey(String APath)
    {
        RegistryKey Key = Registry.CurrentUser.OpenSubKey(APath, true);

        if (Key == null)
        {
            Registry.CurrentUser.CreateSubKey(APath);
            Key = Registry.CurrentUser.OpenSubKey(APath, true);
        }

        return Key;
    }

    public static void WaitForProcessExit(Process AProcess)
    {        
        while (!AProcess.HasExited)
        {
            Application.DoEvents();
            System.Threading.Thread.Sleep(100);
        }
    }

    struct STARTUPINFO
    {
        public Int32 cb;
        public string lpReserved;
        public string lpDesktop;
        public string lpTitle;
        public Int32 dwX;
        public Int32 dwY;
        public Int32 dwXSize;
        public Int32 dwYSize;
        public Int32 dwXCountChars;
        public Int32 dwYCountChars;
        public Int32 dwFillAttribute;
        public Int32 dwFlags;
        public Int16 wShowWindow;
        public Int16 cbReserved2;
        public byte lpReserved2;
        public int hStdInput;
        public int hStdOutput;
        public int hStdError;
    }

    struct PROCESS_INFORMATION
    {
        public int hProcess;
        public int hThread;
        public Int16 dwProcessId;
        public Int16 dwThreadId;
    }

    [DllImport("kernel32.dll")]
    private static extern bool CreateProcess(
       string lpApplicationName,
       string lpCommandLine,
       IntPtr lpProcessAttributes,
       IntPtr lpThreadAttributes,
       bool bInheritHandles,
       int dwCreationFlags,
       IntPtr lpEnvironment,
       string lpCurrentDirectory,
       ref STARTUPINFO lpStartupInfo,
       ref PROCESS_INFORMATION lpProcessInformation);

    public Process Launch(String AAppPath, String AParams, bool AWait, TLog ALog, bool AHidden)
    {
        Process p = new Process();

        p.StartInfo.Arguments = AParams;
        p.StartInfo.FileName = AAppPath;

        if (AHidden)
        {
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.StartInfo.CreateNoWindow = true;
        }

        //p.StartInfo.UseShellExecute = false;
        //p.StartInfo.RedirectStandardOutput = true;
        //p.StartInfo.RedirectStandardError = true;
        //p.StartInfo.RedirectStandardInput = true;
        p.StartInfo.UseShellExecute = true;

        p.Start();

        ALog.SetCurProcess(p, AAppPath, AParams);

        if (AWait)
        {
            WaitForProcessExit(p);
            ALog.SetCurProcess(null, "", "");
        }

        return p;
    }

    [DllImport("user32.dll", SetLastError = true, EntryPoint = "FindWindow")]
    static extern int _FindWindow(string lpClassName, string lpWindowName);

    [DllImport("user32.dll", SetLastError = true, EntryPoint = "ShowWindow")]
    private static extern bool _ShowWindow(int Window, int Cmd);

    [DllImport("user32.dll", EntryPoint = "BringWindowToTop")]
    public static extern int _BringWindowToTop(int hwnd);

    [DllImport("user32.dll", EntryPoint = "SendMessage")]
    public static extern int _SendMessage(
          int hWnd,      // handle to destination window
          int Msg,       // message
          int wParam,  // first message parameter
          int lParam   // second message parameter
          );
}

public class TDeskTop
{
    [DllImport("user32", EntryPoint = "CreateWindowStation")]
    public static extern int CreateWindowStation(string lpwinsta, int dwFlags, int dwDesiredAccess, int lpsa);

    [DllImport("user32", EntryPoint = "SetProcessWindowStation")]
    public static extern bool SetProcessWindowStation(int AHandle);

    [DllImport("user32", EntryPoint = "CreateDesktop")]
    public static extern int CreateDesktop(string lpszDesktop, string lpszDevice, int pDevmode, int dwFlags, int dwDesiredAccess, int lpsa);

    [DllImport("user32", EntryPoint = "OpenDesktop")]
    public static extern int OpenDesktop(string lpszDesktop, Int16 Flags, bool Inherit, int dwDesiredAccess);

    [DllImport("user32", EntryPoint = "CloseDesktop")]
    public static extern bool CloseDesktop(int AHandle);

    [DllImport("user32", EntryPoint = "SwitchDesktop")]
    public static extern bool SwitchDesktop(int AHandle);

    [DllImport("user32", EntryPoint = "SetThreadDesktop")]
    public static extern bool SetThreadDesktop(int AHandle);

    private int FHandle;

    public TDeskTop()
    {
        String DesktopName = "Hidden";

        FHandle = OpenDesktop(DesktopName, 0, false, 0x0001 | 0x0002 | 0x0040 | 0x0080 | 0x0100 | 0x0008);

        if (FHandle == 0)
        {
            FHandle = CreateDesktop(DesktopName, null, 0, 1, 0x0001 | 0x0002 | 0x0040 | 0x0080 | 0x0100 | 0x0008, 0);
        }

        if (FHandle == 0)
        {
            throw new ArgumentNullException();
        }
    }

    ~TDeskTop()
    {
        CloseDesktop(FHandle);
    }

    public void SwitchTo()
    {
        if (!SwitchDesktop(FHandle))
        {
            throw new ArgumentNullException();
        }
    }

    public void SetTo()
    {
        if (!SetThreadDesktop(FHandle))
        {
            throw new ArgumentNullException();
        }
    }
}