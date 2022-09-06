using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using ScriptPortal.Vegas;
using Microsoft.Win32;

namespace VegasTools
{
    #region Типы

    public enum CvgRenderMode
    {
        rmCBR,
        rmCQ,
        rmVBR
    }

    public enum CvgFieldOrder
    {
        foProgressive,
        foUpper,
        foLower
    }

    public enum CvgScaleMode
    {
        smStrech,
        smInside,
        smCrop
    }

    public enum TAudioMode
    {
        amPCM,
        amStandart,
        amCompact
    }

    public enum TAspectRatio
    {
        ar4_3,
        ar16_9,
        ar1_1
    }

    #endregion

    public abstract class TSourceMode
    {
        public abstract void Process(Vegas AVegas, TRenderer ARenderer, TLog ALog);

        public String FileName
        {
            get
            {
                return FFileName;
            }
        }

        protected String FFileName;
    }

    public class TSourceMode_Selection : TSourceMode
    {
        public override void Process(Vegas AVegas, TRenderer ARenderer, TLog ALog)
        {
            ALog.Message("[Обработка выделения]", TLogEventType.leInfo);

            FFileName = Path.GetFileNameWithoutExtension(AVegas.Project.FilePath) + " [Selection]";

            ARenderer.Start = AVegas.SelectionStart;
            ARenderer.Length = AVegas.SelectionLength;
            ARenderer.DoProceed();
        }
    }

    public class TSourceMode_Project : TSourceMode
    {
        public override void Process(Vegas AVegas, TRenderer ARenderer, TLog ALog)
        {
            ALog.Message("[Обработка проекта]", TLogEventType.leInfo);

            FFileName = Path.GetFileNameWithoutExtension(AVegas.Project.FilePath) + " [Project]";

            ARenderer.Start = new Timecode(0);
            ARenderer.Length = AVegas.Project.Length;
            ARenderer.DoProceed();
        }
    }

    public class TSourceMode_Regions : TSourceMode
    {
        public override void Process(Vegas AVegas, TRenderer ARenderer, TLog ALog)
        {
            ALog.SetTotal(AVegas.Project.Regions.Count);
            ALog.Message("[Обработка регионов]", TLogEventType.leInfo);

            foreach (Region R in AVegas.Project.Regions)
            {
                FFileName = "R" + (R.Index + 1) + ") " + R.Label;

                ARenderer.Start = R.Position;
                ARenderer.Length = R.Length;
                ARenderer.DoProceed();

                if (ALog.HasErrors())
                    return;
            }
        }
    }

    public class TSourceMode_Events : TSourceMode
    {
        public override void Process(Vegas AVegas, TRenderer ARenderer, TLog ALog)
        {
            ALog.Message("[Обработка эвентов на выделенных треках]", TLogEventType.leInfo);

            foreach (Track T in AVegas.Project.Tracks)
            {
                if (T.Selected)
                {
                    ALog.SetTotal(T.Events.Count);

                    foreach (TrackEvent E in T.Events)
                    {
                        FFileName = E.ActiveTake.Name;

                        ARenderer.Start = E.Start;
                        ARenderer.Length = E.Length;
                        ARenderer.DoProceed();

                        if (ALog.HasErrors())
                            return;
                    }
                }
            }
        }
    }

    public class TSourceMode_SelectedEvents : TSourceMode
    {
        public override void Process(Vegas AVegas, TRenderer ARenderer, TLog ALog)
        {
            ALog.Message("[Обработка выделенных эвентов]", TLogEventType.leInfo);

            foreach (Track T in AVegas.Project.Tracks)
            {
                if (T.Selected)
                {
                    ALog.SetTotal(T.Events.Count);

                    foreach (TrackEvent E in T.Events)
                    {
                        if (E.Selected)
                        {
                            FFileName = E.ActiveTake.Name;

                            ARenderer.Start = E.Start;
                            ARenderer.Length = E.Length;
                            ARenderer.DoProceed();

                            if (ALog.HasErrors())
                                return;
                        }
                    }
                }
            }
        }
    }

    public abstract class TRenderer
    {
        public TRenderer()
        {
            Width = 720;
            Height = 576;
            SourceMode = new TSourceMode_Project();
            AspectRatio = TAspectRatio.ar16_9;
            Mode = CvgRenderMode.rmCBR;
        }

        public void CreateTempFile(String AFileName)
        {
            FTempFileSW = new StreamWriter(FSysHelper.MyPath + AFileName);
        }

        public void AppendTempFile(String AText)
        {
            FTempFileSW.WriteLine(AText);
        }

        public void CloseTempFile()
        {
            FTempFileSW.Flush();
            FTempFileSW.Close();
            FTempFileSW = null;
        }

        public virtual String AVSColorConvert()
        {
            if (FFieldOrder == CvgFieldOrder.foProgressive)
                return "ConvertToYUY2(matrix=\"PC.601\")";
            else
                return "ConvertToYUY2(matrix=\"PC.601\", interlaced = true)";
        }

        virtual public TLogEventType Icon()
        {
            return TLogEventType.leAVI;
        }

        virtual public String Caption()
        {
            return "";
        }

        abstract public String CompactAudioPresetName();

        abstract public String StandartAudioPresetName();

        protected virtual String FullTargetFileName()
        {
            return TargetFileName;
        }

        protected virtual void ExecuteVideoCompressor()
        {

        }

        protected virtual void ExecuteAudioCompressor()
        {

        }

        virtual public void Muxing()
        {

        }

        virtual public bool ForceAVS()
        {
            return false;
        }

        public abstract int MaxBitrate { get; }
        public abstract int MinBitrate { get; }

        public virtual void Cancel()
        {
            FSysHelper.CloseWindow(FSysHelper.TryFindWindow("#32770", "FrameServer - (Status)"));
        }

        public void CheckFile(String APath, bool AWrite)
        {
            while (!FLog.HasErrors())
            {
                try
                {
                    FileStream FS;

                    if (AWrite)
                    {
                        FS = File.OpenWrite(APath);
                    }
                    else
                    {
                        FS = File.OpenRead(APath);
                    }

                    FS.Close();
                    FS.Dispose();
                    break;
                }
                catch
                {
                    Application.DoEvents();
                }
            }
        }

        public void DeleteFile(String AFileName)
        {
            if (File.Exists(AFileName))
            {
                try
                {
                    CheckFile(AFileName, true);
                    File.Delete(AFileName);
                }
                catch
                {

                }
            }
        }

        public void DeleteFiles(String APath, String AMask)
        {
            String[] Files = Directory.GetFiles(APath, AMask);

            foreach (String F in Files)
                DeleteFile(F);
        }

        protected void RenderLossLess(String ATarget)
        {
            CreateTempFile("VirtualDub.jobs");

            AppendTempFile("// VirtualDub job list (Sylia script format)");
            AppendTempFile("// This is a program generated file -- edit at your own risk.");
            AppendTempFile("//");
            AppendTempFile("// $numjobs 1");
            AppendTempFile("//");

            AppendTempFile("// $job \"Job 1\"");
            AppendTempFile("// $input \"" + SourceFileName + "\"");
            AppendTempFile("// $output \"" + ATarget + "\"");
            AppendTempFile("// $state 0");
            AppendTempFile("// $start_time 0 0");
            AppendTempFile("// $end_time 0 0");
            AppendTempFile("// $script");

            AppendTempFile("VirtualDub.Open(\"" + SourceFileName.Replace("\\", "\\\\") + "\", \"\", 0);");
            AppendTempFile("VirtualDub.audio.SetSource(1);");
            AppendTempFile("VirtualDub.audio.SetMode(0);");
            AppendTempFile("VirtualDub.audio.SetInterleave(1, 500, 1, 0, 0);");
            AppendTempFile("VirtualDub.audio.SetClipMode(1, 1);");
            AppendTempFile("VirtualDub.audio.SetConversion(0, 0, 0, 0, 0);");
            AppendTempFile("VirtualDub.audio.SetVolume();");
            AppendTempFile("VirtualDub.audio.SetCompression();");
            AppendTempFile("VirtualDub.audio.EnableFilterGraph(0);");
            AppendTempFile("VirtualDub.video.SetInputFormat(0);");
            AppendTempFile("VirtualDub.video.SetOutputFormat(7);");
            AppendTempFile("VirtualDub.video.SetMode(3);");
            AppendTempFile("VirtualDub.video.SetSmartRendering(0);");
            AppendTempFile("VirtualDub.video.SetPreserveEmptyFrames(0);");
            AppendTempFile("VirtualDub.video.SetFrameRate2(0, 0, 1);");
            AppendTempFile("VirtualDub.video.SetIVTC(0, 0, -1, 0);");
            AppendTempFile("VirtualDub.video.SetRange(0, 0);");
            AppendTempFile("VirtualDub.video.SetCompression(" + FOptions.LossLessCodec + ");");
            AppendTempFile("VirtualDub.video.filters.Clear();");
            AppendTempFile("VirtualDub.audio.filters.Clear();");
            AppendTempFile("VirtualDub.subset.Clear();");
            AppendTempFile("VirtualDub.subset.AddRange(0, " + (Length.FrameCount) + ");");
            AppendTempFile("VirtualDub.project.ClearTextInfo();");
            AppendTempFile("// -- $reloadstop --");
            AppendTempFile("VirtualDub.SaveAVI(\"" + ATarget.Replace("\\", "\\\\") + "\");");
            AppendTempFile("VirtualDub.audio.SetSource(1);");
            AppendTempFile("VirtualDub.Close();");

            AppendTempFile("// $endjob");
            AppendTempFile("//");
            AppendTempFile("//--------------------------------------------------");
            AppendTempFile("// $done");

            CloseTempFile();

            FSysHelper.Launch(FSysHelper.MyPath + "VirtualDub.exe", " /r /x", true, FLog, false);

            CheckFile(ATarget, false);
        }

        public void Init(Vegas AVegas, TLog ALog, TVT_Options AOptions)
        {
            FLog = ALog;
            FVegas = AVegas;

            Bitrate = MaxBitrate;

            FSysHelper = new TSysHelper(AOptions);
            FOptions = AOptions;
        }

        public CvgFieldOrder FieldOrder
        {
            get
            {
                return FFieldOrder;
            }

            set
            {
                FFieldOrder = value;
            }
        }

        public CvgScaleMode ScaleMode { get; set; }

        public TAspectRatio AspectRatio { get; set; }

        public bool NeedMuxing { get; set; }

        String FixFileName(String AName)
        {
            String Name = AName;

            Name.Replace("\\", "_");
            Name.Replace("/", "_");
            Name.Replace(":", "_");
            Name.Replace("*", "_");
            Name.Replace("?", "_");
            Name.Replace(".", "_");
            Name.Replace(",", "_");
            Name.Replace("\"", "_");
            Name.Replace("№", "N");

            return Name;
        }

        public void CheckFileName()
        {
            int N = 1;

            String FileName = FixFileName(SourceMode.FileName);
            String NewName = FileName;

            if (Directory.Exists(OutputPath))
            {
                while (Directory.GetFiles(OutputPath, NewName + ".*").GetLength(0) > 0)
                {
                    N++;
                    NewName = FileName + " pass N" + N;
                }
            }

            if (N > 1)
            {
                FLog.Message("Каталог вывода содержал файлы.", TLogEventType.leWarning);
                FileName = NewName;
            }

            FTargetFileName = OutputPath + FileName;
        }

        public TSourceMode SourceMode { get; set; }

        public String DummyAVI
        {
            get
            {
                return FSysHelper.MyPath + "Dummy.avi";
            }
        }

        public TAudioMode AudioMode { get; set; }

        public bool AVSProcessing
        {
            get
            {
                return (((Denoise + Sharpen + Border) > 0) || HQ || ForceAVS() || ((FVegas.Project.Video.Width != Width) || (FVegas.Project.Video.Height != Height)));
            }
        }

        public void Dispose()
        {
            FLog = null;
            FVegas = null;
        }

        protected String SourceFileName
        {
            get
            {
                return FSourceFile;
            }
        }

        public String TargetFileName
        {
            set
            {
                CheckIdle();
                FTargetFileName = value;
            }

            get
            {
                return FTargetFileName;
            }
        }

        public String OutputPath
        {
            get
            {
                return Path.GetDirectoryName(TargetFileName) + "\\";
            }
        }

        bool IsEven(int AValue)
        {
            return ((int)(AValue / 2) * 2) == AValue;
        }

        void AddResize(int Width, ref int Height)
        {
            AppendTempFile("Spline64Resize(" + Width + ", " + Height + ")");
        }

        protected void MakeAVS()
        {
            CreateTempFile("CCE.avs");

            int VW = FVegas.Project.Video.Width;
            int VH = FVegas.Project.Video.Height;

            float TAR = ((float)Width / (float)Height);

            //AppendTempFile("DirectShowSource(\"" + DummyAVI + "\", audio = false)");
            //AppendTempFile("OpenDMLSource(\"" + DummyAVI + "\", audio = false)");
            AppendTempFile("AVIFileSource(\"" + DummyAVI + "\", audio = false, fourCC=\"DFSC\")");
            string InputMode;

            if (FieldOrder == CvgFieldOrder.foProgressive)
            {
                AppendTempFile("AssumeFrameBased()");
                InputMode = ", InputType=1";
            }
            else
            {
                InputMode = ", InputType=0";

                if (FieldOrder == CvgFieldOrder.foUpper)
                    AppendTempFile("AssumeTFF()");
                else
                    AppendTempFile("AssumeBFF()");
            }

            AppendTempFile(AVSColorConvert());

            bool NeedResize = (VW != Width) || (VH != Height);

            if (HQ)
            {
                FLog.Message("Выполнена постобработка", TLogEventType.leInfo);

                AppendTempFile("QTGMC(Preset=\"Fast\"" + InputMode + ")");
                AppendTempFile("AssumeFrameBased()");

                if (FieldOrder != CvgFieldOrder.foProgressive)
                {
                    if (!DblFPS)
                        AppendTempFile("SelectEven()");
                    else
                        FLog.Message("Удвоение FPS", TLogEventType.leInfo);
                }
            }

            if (Denoise > 0 || Sharpen > 0)
            {
                if (Sharpen > 0)
                   FLog.Message("Резкость: " + Sharpen, TLogEventType.leInfo);
                //Denoiser = ", NoiseRestore=0.0, DenoiseMC=True, NoiseTR=2, Denoiser=\"fft3dfilter\", NoiseProcess=1, Sigma=" + Denoise;
                AppendTempFile("LoadPlugin(\"c:\\Program Files (x86)\\AviSynth 2.5\\Plugins\\FFT3DFilter.dll\")");

                if (Denoise > 0)
                {
                    FLog.Message("Шумодав: " + Denoise, TLogEventType.leInfo);
                    AppendTempFile("FFT3DFilter(plane=3, sigma=" + Denoise * 2 + ", bt=5, ow=16, oh=16)");
                }

                AppendTempFile("FFT3DFilter(plane=0, sigma=" + Denoise + ", bt=5, ow=16, oh=16, sharpen=" + Sharpen / 3 + ")");
            }

            // Рамка
            if (Border > 0)
            {
                FLog.Message("Обрезка = " + Border, TLogEventType.leInfo);

                AppendTempFile("Crop(" + Border + ", " + Border + ", -" + Border + ", -" + Border + ")");
            }

            // Скалирование
            if (NeedResize)
            {
                String ScaleDesc = "Скалирование " + VW + "х" + VH + " > " + Width + "х" + Height;

                int W = Width;
                int H = Height;

                int WB1, WB2, HB1, HB2;

                if (AspectRatio == TAspectRatio.ar16_9)
                    TAR = TAR * 1.4568f;
                else if (AspectRatio == TAspectRatio.ar4_3)
                    TAR = TAR * 1.0926f;

                if (ScaleMode == CvgScaleMode.smStrech)
                {
                    AddResize(W, ref H);
                    ScaleDesc += " с растяжением.";
                }
                else if (ScaleMode == CvgScaleMode.smInside)
                {
                    if (SAR < TAR)
                        W = (int)((Width * SAR) / TAR);
                    else
                        H = (int)((Height * TAR) / SAR);

                    if (!IsEven(W))
                        W--;

                    if (!IsEven(H))
                        H--;

                    AddResize(W, ref H);

                    WB1 = (Width - W) / 2;
                    HB1 = (Height - H) / 2;

                    if (WB1 + HB1 > 0)
                    {
                        AppendTempFile("AddBorders(" + WB1 + ", " + HB1 + ", " + WB1 + ", " + HB1 + ")");

                        ScaleDesc += " с вписыванием.";
                    }
                }
                else if (ScaleMode == CvgScaleMode.smCrop)
                {
                    if (SAR > TAR)
                        //W = (int)((VW * SAR * Height) / (TAR * VH));
                        W = (int)((Width * SAR) / TAR);
                    else
                        H = (int)((Height * TAR) / SAR);
                    //H = (int)((VH * TAR * Width) / (SAR * VW));

                    if (!IsEven(W))
                        W--;

                    if (!IsEven(H))
                        H--;

                    AddResize(W, ref H);

                    WB1 = (W - Width) / 2;
                    HB1 = (H - Height) / 2;

                    if (IsEven(WB1))
                        WB2 = WB1;
                    else
                    {
                        WB2 = WB1 - 1;
                        WB1++;
                    }

                    if (IsEven(HB1))
                        HB2 = HB1;
                    else
                    {
                        HB2 = HB1 - 1;
                        HB1++;
                    }

                    if (WB1 + HB1 + HB2 + WB2 > 0)
                    {
                        AppendTempFile("Crop(" + WB1 + ", " + HB1 + ", " + (-WB2) + ", " + (-HB2) + ")");

                        ScaleDesc += " с обрезкой.";
                    }
                }

                FLog.Message(ScaleDesc, TLogEventType.leInfo);
            }

            CloseTempFile();
        }

        public void Proceed()
        {
            CheckIdle();

            FBusy = true;
            try
            {
                if (AspectRatio == TAspectRatio.ar16_9)
                    FLog.Message("Соотношение сторон = 16:9", TLogEventType.leInfo);
                else if (AspectRatio == TAspectRatio.ar1_1)
                    FLog.Message("Соотношение сторон = 1:1", TLogEventType.leInfo);
                else
                    FLog.Message("Соотношение сторон = 4:3", TLogEventType.leInfo);

                if (Mode == CvgRenderMode.rmCBR)
                {
                    if (Bitrate != 0)
                        FLog.Message("Постоянный битрейт = " + Bitrate, TLogEventType.leInfo);
                }
                else if (Mode == CvgRenderMode.rmCQ)
                    FLog.Message("Постоянный квантизер = " + Quantizer, TLogEventType.leInfo);
                else if (Mode == CvgRenderMode.rmVBR)
                {
                    if (CreateBuffer)
                        FLog.Message("Переменный битрейт = " + Bitrate + " в два прохода с буферным файлом", TLogEventType.leInfo);
                    else
                        FLog.Message("Переменный битрейт = " + Bitrate + " в два прохода", TLogEventType.leInfo);
                }

                if (AVSProcessing)
                    MakeAVS();

                try
                {
                    SourceMode.Process(FVegas, this, FLog);
                }
                catch (Exception e)
                {
                    FLog.Error(e.Message);
                }
            }
            finally
            {
                FSysHelper.ShowWindow(FVegas.MainWindow.Handle.ToInt32());
                FBusy = false;
            }
        }

        public float Sharpen { get; set; }

        public int Border { get; set; }

        public float Denoise { get; set; }

        public bool DenoiseChroma { get; set; }

        public int Quantizer { get; set; }

        public float SAR
        {
            get
            {
                return ((float)FVegas.Project.Video.Width / (float)FVegas.Project.Video.Height) * (float)FVegas.Project.Video.PixelAspectRatio;
            }
        }

        public float PAR
        {
            get
            {
                return (float)FVegas.Project.Video.PixelAspectRatio;
            }
        }

        public int Bitrate
        {
            set
            {
                CheckIdle();

                if (value > MaxBitrate)
                {
                    FBitrate = MaxBitrate;
                }
                else if (value < MinBitrate)
                {
                    FBitrate = MinBitrate;
                }
                else
                {
                    FBitrate = value;
                }
            }

            get
            {
                return FBitrate;
            }
        }

        public int Width { get; set; }

        public int Height { get; set; }

        public bool HQ { get; set; }
        public bool DblFPS { get; set; }

        public bool SkipVideo { get; set; }

        public CvgRenderMode Mode
        {
            set
            {
                CheckIdle();
                FMode = value;
            }

            get
            {
                return FMode;
            }
        }

        public Timecode Start { get; set; }

        public Timecode Length { get; set; }

        public bool Busy
        {
            get
            {
                return FBusy;
            }
        }

        protected void DoRender(String ARender, String ATemplate, String APath, bool AWait)
        {
            FLog.OpenFolder("Рендеринг [" + ARender + "] с темплейтом [" + ATemplate + "]", TLogEventType.leRender);
            try
            {
                RenderArgs RA = new RenderArgs();
                Renderer Render = FVegas.Renderers.FindByName(ARender);

                try
                {
                    RA.RenderTemplate = Render.Templates.FindByName(ATemplate);
                    RA.OutputFile = APath;
                    RA.IncludeMarkers = true;
                    RA.UseSelection = false;
                    RA.StartNanos = Start.Nanos;
                    RA.LengthNanos = Length.Nanos;

                    FVegas.BeginRender(RA);

                    if (!FLog.Visible)
                        FSysHelper.HideWindow(FVegas.MainWindow.Handle.ToInt32());

                    if (AWait)
                    {
                        FVegas.WaitForIdle();

                        CheckFile(APath, true);
                    };
                }
                catch(Exception e)
                {
                    FLog.Error("Темплейт не найден! " + e.Message);
                    throw new Exception("");
                }
            }
            catch
            {
                FLog.Error("Рендерер не найден!");
                throw new Exception("");
            }

            FLog.CloseFolder();
        }

        public bool CreateBuffer { get; set; }

        void StartFrameserver()
        {
            int ColorMode = 1; // YUY2 = 2; RGB32 = 1

            RegistryKey FrameServerKey = FSysHelper.GetSubKey("Software\\DebugMode\\FrameServer");

            FrameServerKey.SetValue("serveFormat", ColorMode);
            FrameServerKey.SetValue("saveAsImageSequence", 0);
            FrameServerKey.SetValue("pcmAudioInAvi", 1);

            DoRender("DebugMode FrameServer", "Audio: 48.0Khz, Video: project default", DummyAVI, false);
            FLog.Message("Подготовка буферного файла...", TLogEventType.leInfo);
            FSysHelper.SendMessage(FSysHelper.FindWindow("#32770", "FrameServer - (Setup)", 10000 * 60), 0x111, 1, 0x00030A86); // Нажатие ОК
            Application.DoEvents();
            FSysHelper.HideWindow(FSysHelper.FindWindow("#32770", "FrameServer - (Status)")); // Ожидание появления окна статуса - признак создания файла выхода

            CheckFile(DummyAVI, false);
            FLog.Progress += 5;

            FLog.Message("Готово.", TLogEventType.leInfo);

            if (!FLog.Visible)
                System.Threading.Thread.Sleep(800);

            Application.DoEvents();
            FSysHelper.HideWindow(FSysHelper.FindWindow("#32770", "FrameServer - (Status)")); // Ожидание появления окна статуса - признак создания файла выхода            
        }

        public virtual void DoProceed()
        {
            CheckFileName();

            FLog.OpenFolder("Рендеринг " + Caption() + " [" + TargetFileName + "]", Icon());

            FLog.Message("Длительность = " + FVegas.Project.Length, TLogEventType.leInfo);

            Directory.CreateDirectory(OutputPath);

            if (!SkipVideo)
                DoVideo();
            else
                FLog.Progress += 85;

            if (FLog.HasErrors())
                return;

            DoAudio();

            if (FLog.HasErrors())
                return;

            if (!SkipVideo)
                DoMuxing();

            FLog.CloseFolder();
        }

        private void DoMuxing()
        {
            if (NeedMuxing && (AudioMode != TAudioMode.amPCM))
            {
                FLog.OpenFolder("Muxing", TLogEventType.leFeature);
                Muxing();
                FLog.CloseFolder();
            }

            FLog.Progress += 8;
        }

        private void DoAudio()
        {
            FLog.OpenFolder("Звук", TLogEventType.leFeature);

            if (AudioMode == TAudioMode.amPCM)
                DoRender("Wave (Microsoft)", "Default Template", TargetFileName + ".wav", true);
            else
                ExecuteAudioCompressor();

            FLog.Progress += 7;

            FLog.CloseFolder();
        }

        private void DoVideo()
        {
            FLog.OpenFolder("Видео", TLogEventType.leFeature);

            if (AVSProcessing)
                FSourceFile = FSysHelper.MyPath + "CCE.avs";
            else
                FSourceFile = DummyAVI;

            try
            {
                if (CreateBuffer)
                {
                 /*   FLog.OpenFolder("Создание промежуточного файла", TLogEventType.leAVI);

                    StartFrameserver();

                    RenderLossLess(FOptions.BufFileName);

                    FSysHelper.CloseWindow("#32770", "FrameServer - (Status)");

                    FSourceFile = FOptions.BufFileName;
                    CheckFile(SourceFileName, true);

                    FLog.CloseFolder();*/

                    DoExecuteVideoCompressor();
                }
                else
                {
                    //StartFrameserver();

                    DoExecuteVideoCompressor();

                    //FSysHelper.CloseWindow("#32770", "FrameServer - (Status)");
                }
            }
            finally
            {
                FLog.Message("Удаление временных файлов...", TLogEventType.leInfo);
                DeleteFile(SourceFileName);
                DeleteFile(DummyAVI);
            }

            FLog.CloseFolder();
        }

        private void DoExecuteVideoCompressor()
        {
            try
            {
                ExecuteVideoCompressor();

                using (FileStream FS = new FileStream(FullTargetFileName(), FileMode.Open))
                    if (FS.Length < 100)
                        FLog.Error("Видео файл не содержит видео!");
            }
            catch (Exception e)
            {
                FLog.Error(e.Message);
            }
        }

        void CheckIdle()
        {
            if (FBusy)
            {
                throw new InvalidOperationException("Рендерер занят!");
            }
        }

        CvgRenderMode FMode;
        int FBitrate;
        String FTargetFileName;
        String FSourceFile;
        bool FBusy;

        CvgFieldOrder FFieldOrder;
        StreamWriter FTempFileSW;

        protected TLog FLog;
        protected Vegas FVegas;

        protected TSysHelper FSysHelper;
        protected TVT_Options FOptions;
    }

    public class TDVD_Renderer : TRenderer
    {
        override public String CompactAudioPresetName()
        {
            return "Компактный AC3";
        }

        override public String StandartAudioPresetName()
        {
            return "Стандарт AC3";
        }

        public override void Muxing()
        {
            ExecuteMuxer(TargetFileName + ".mpv", TargetFileName + ".ac3", TargetFileName + ".mpg");
        }

        protected override void ExecuteAudioCompressor()
        {
            try
            {
                if (AudioMode == TAudioMode.amStandart)
                {
                    DoRender("Dolby Digital AC-3 Pro", "Vegas Tools DVD", TargetFileName + ".mpg", true);
                }
                else
                {
                    DoRender("Dolby Digital AC-3 Pro", "Vegas Tools DVD compact", TargetFileName + ".mpg", true);
                }
            }
            catch
            {
                FLog.Message("Возможно не зарегистрирован кодек Dolby Digital AC-3 Pro.", TLogEventType.leWarning);
                throw new InvalidOperationException("");
            }

            File.Move(TargetFileName + ".mpg", TargetFileName + ".ac3");
        }

        public override int MaxBitrate
        {
            get
            {
                return 9500;
            }
        }
        public override int MinBitrate
        {
            get
            {
                return 2500;
            }
        }

        public void ExecuteMuxer(String AVideoFile, String AudioFile, String AOutputFile)
        {
        }
    }
}