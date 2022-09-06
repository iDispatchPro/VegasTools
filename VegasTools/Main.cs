using System;
using System.Collections;
using System.IO;
using System.Windows.Forms;
using Microsoft.Win32;
using ScriptPortal.Vegas;

namespace VegasTools
{
    public class TVT_Options
    {
        void Store(String AName, object AValue)
        {

        }

        public TVT_Options()
        {
            UseGPU = false;
            BufFileName = "C:\\Buffer.avi";
            LossLessCodec = "";
        }

        public void Save()
        {
            Store("UseGPU", UseGPU);
            Store("LossLessCodec", LossLessCodec);
            Store("BufFileName", BufFileName);
        }

        ~TVT_Options()
        {
            Save();
        }

        public bool UseGPU;
        public String LossLessCodec;
        public String BufFileName;
    }

    public class MainICustomCommandModule : ICustomCommandModule
    {
        TVT_Options FOptions;
        TSysHelper SysHelper;
        //DockableControl bathRender_DockView = new DockableControl("BathRender");
        //DockableControl navigator_DockView = new DockableControl("Navigator");

        protected Vegas FVegas;
        protected TLog FLog;
        protected DVD_Options FDVD_Options;

        public void InitializeModule(Vegas vegas)
        {
            Application.VisualStyleState = System.Windows.Forms.VisualStyles.VisualStyleState.ClientAndNonClientAreasEnabled;
            FVegas = vegas;
            FOptions = new TVT_Options();
            SysHelper = new TSysHelper(FOptions);
        }

        public CustomCommand GetCustomCommand(CommandCategory ACategory, String ACaption, EventHandler AHandler)
        {
            CustomCommand cmd = new CustomCommand(ACategory, AHandler.Method.Name);
            cmd.DisplayName = "Vegas Tools - " + ACaption;
            cmd.Invoked += AHandler;
            cmd.IconFile = SysHelper.MyPath + AHandler.Method.Name.Replace("Do_", "") + ".png";
            return cmd;
        }

        public ICollection GetCustomCommands()
        {
            /*Navigator_MenuItem = GetCustomCommand(CommandCategory.View, "Навигатор",
                            Do_Navigator
                            );

            BathRender_MenuItem = GetCustomCommand(CommandCategory.View, "Пакетный рендеринг",
                            Do_BathRender
                            );*/

            return new CustomCommand[] 
                    {
                        GetCustomCommand(CommandCategory.Tools, "Рендеринг x264", 
                            Do_x264
                            ),
                        GetCustomCommand(CommandCategory.Tools, "Рендеринг Uncompressed avi", 
                            Do_LossLess
                            ),
                        GetCustomCommand(CommandCategory.Tools, "Параметры", 
                            Do_Options
                            ),
                        GetCustomCommand(CommandCategory.Edit, "Переключить прозрачность", 
                            Do_Alpha
                            ),
                        GetCustomCommand(CommandCategory.Edit, "Разделить выделенные эвенты", 
                            Do_Split
                            ),
                        GetCustomCommand(CommandCategory.Edit, "Добавить маркеры - главы для DVD", 
                            Do_AddChapters
                            ),
                        GetCustomCommand(CommandCategory.Tools, "Стоп-кадр", 
                            Do_SnapShot
                            )
                    };
        }

        #region Edit

        void Do_Split(Object sender, EventArgs args)
        {
            using (UndoBlock undo = new UndoBlock("Split selected"))
            {
                foreach (Track T in FVegas.Project.Tracks)
                {
                    foreach (TrackEvent E in T.Events)
                    {
                        if (E.Selected)
                            E.Split(FVegas.Cursor - E.Start);
                    }
                }
            }
        }

        void Do_SnapShot(Object sender, EventArgs args)
        {
            FVegas.SaveSnapshot(FVegas.Cursor);              
        }

        void Do_Alpha(Object sender, EventArgs args)
        {
            using (UndoBlock undo = new UndoBlock("Alpha change"))
            {
                foreach (Track T in FVegas.Project.Tracks)
                {
                    foreach (TrackEvent E in T.Events)
                    {
                        if (E.Selected && (E.MediaType == MediaType.Video) && (E.ActiveTake.Media != null))
                        {
                            VideoStream V = E.ActiveTake.MediaStream as VideoStream;

                            switch (V.AlphaChannel)
                            {
                                case VideoAlphaType.None:
                                    V.AlphaChannel = VideoAlphaType.Premultiplied;
                                    break;

                                case VideoAlphaType.Premultiplied:
                                    V.AlphaChannel = VideoAlphaType.PremultipliedDirty;
                                    break;

                                case VideoAlphaType.PremultipliedDirty:
                                    V.AlphaChannel = VideoAlphaType.Straight;
                                    break;

                                case VideoAlphaType.Straight:
                                    V.AlphaChannel = VideoAlphaType.None;
                                    break;
                            }
                        }
                    }
                }
            }
        }

        void CheckLength(Timecode AStart, Timecode AFinish, ref Timecode ALength, ref Timecode APosition)
        {
            Timecode Length = AFinish - AStart;

            if (Length > ALength)
            {
                ALength = Length;
                APosition = new Timecode((Length.ToMilliseconds() / 2) + AStart.ToMilliseconds());
            }
        }

        void Do_AddChapters(Object sender, EventArgs args)
        {
            using (UndoBlock undo = new UndoBlock("Add chapters"))
            {
                MarkerList Markers = FVegas.Project.Markers;

                while (Markers.Count < 99)
                {
                    Timecode MaxLength = new Timecode(0);
                    Timecode Position = new Timecode(0);

                    if (Markers.Count > 0)
                    {
                        CheckLength(new Timecode(0), Markers[0].Position, ref MaxLength, ref Position);

                        for (int i = 1; i < Markers.Count; i++)
                            CheckLength(Markers[i - 1].Position, Markers[i].Position, ref MaxLength, ref Position);

                        CheckLength(Markers[Markers.Count - 1].Position, FVegas.Project.Length, ref MaxLength, ref Position);
                    }
                    else
                        CheckLength(new Timecode(0), FVegas.Project.Length, ref MaxLength, ref Position);

                    if (MaxLength.ToMilliseconds() > 0 && MaxLength.ToMilliseconds() >= 10 * 60 * 1000)
                        Markers.Add(new Marker(Position));
                    else
                        return;
                }
            }
        }

        #endregion

        #region Renders

        void Do_x264(Object sender, EventArgs args)
        {
            Render(new Tx264());
        }

        void Do_LossLess(Object sender, EventArgs args)
        {
            Render(new TLossLessRender());
        }

        #endregion

        void Done()
        {
            Log.Done();
            bool ShutDownAfterDone = Log.ShutDownAfterDone;
            FLog = null;

            if (ShutDownAfterDone)
            {
                SysHelper.ShutDown(false, true);
            }
        }

        bool CheckProject()
        {
            if (FVegas.Project.Length.FrameCount == 0)
            {
                MessageBox.Show("Проект пустой!");
                return false;
            }

            if (FVegas.Project.IsModified)
            {
                FVegas.SaveProject();
            }

            return true;
        }

        public TLog Log
        {
            get
            {
                if (FLog == null)
                {
                    FLog = new TLog();
                }

                return FLog;
            }
        }

        void Do_Options(Object sender, EventArgs args)
        {
            Options Dlg = new Options(FOptions);

            Dlg.cb_UseGPU.Checked = FOptions.UseGPU;
            Dlg.tb_BufFileName.Text = FOptions.BufFileName;
            Dlg.tb_LossLessCodec.Text = FOptions.LossLessCodec;

            Dlg.ShowDialog();

            FOptions.UseGPU = Dlg.cb_UseGPU.Checked;
            FOptions.BufFileName = Dlg.tb_BufFileName.Text;
            FOptions.LossLessCodec = Dlg.tb_LossLessCodec.Text;

            FOptions.Save();
        }

        TSourceMode SourceModeByIndex(int AIndex)
        {
            switch (AIndex)
            {
                case 0:
                    {
                        if (FVegas.SelectionLength.FrameCount > 0) 
                        {
                            return new TSourceMode_Selection();
                        }
                        else
                        {
                            return new TSourceMode_Project();
                        }
                    }
                
                case 1: return new TSourceMode_Project();
                case 2: return new TSourceMode_Regions();
                case 3: return new TSourceMode_Events();
                case 4: return new TSourceMode_SelectedEvents();
                default: return new TSourceMode_Project();
            }
        }

        void Render(TRenderer ARenderer)
        {
            if (CheckProject())
            {
                DVD_Options Opt = new DVD_Options(FVegas, FOptions, ARenderer);

                try
                {
                    if (Opt.ShowDialog() == DialogResult.OK)
                    {
                        ARenderer.Init(FVegas, Log, FOptions);

                        try
                        {
                            try
                            {
                                Log.Clear(FVegas);
                                Log.Show();

                                ARenderer.Bitrate = (int)Opt.se_BitRate.Value;
                                ARenderer.Quantizer = (int)Opt.se_Quantizer.Value;
                                ARenderer.HQ = Opt.cbHQ.Checked;
                                ARenderer.DblFPS = Opt.cbDblFPS.Checked;
                                ARenderer.Sharpen = (float)Opt.seSharpen.Value;
                                ARenderer.Border = (int)Opt.se_Border.Value;
                                ARenderer.CreateBuffer = false;
                                ARenderer.Denoise = (float)(Opt.seDenoiser.Value);
                                ARenderer.Sharpen = (float)(Opt.seSharpen.Value);

                                if (Opt.cb_Mode.SelectedIndex == 4)
                                    ARenderer.SkipVideo = true;
                                else if (Opt.cb_Mode.SelectedIndex == 3)
                                {
                                    ARenderer.Mode = CvgRenderMode.rmVBR;
                                    ARenderer.CreateBuffer = true;
                                }
                                else if (Opt.cb_Mode.SelectedIndex == 2)
                                    ARenderer.Mode = CvgRenderMode.rmCQ;
                                else if (Opt.cb_Mode.SelectedIndex == 1)
                                    ARenderer.Mode = CvgRenderMode.rmVBR;
                                else if (Opt.cb_Mode.SelectedIndex == 0)
                                    ARenderer.Mode = CvgRenderMode.rmCBR;

                                ARenderer.TargetFileName = Path.Combine(Opt.tb_FileName.Text, "");
                                ARenderer.SourceMode = SourceModeByIndex(Opt.cb_Source.SelectedIndex);
                                ARenderer.NeedMuxing = !Opt.cb_SeparateAudio.Checked;
                                ARenderer.Width = (int)Opt.se_Width.Value;
                                ARenderer.Height = (int)Opt.se_Height.Value;

                                if (Opt.cb_audioMode.SelectedIndex == 0)
                                    ARenderer.AudioMode = TAudioMode.amPCM;
                                else if (Opt.cb_audioMode.SelectedIndex == 1)
                                    ARenderer.AudioMode = TAudioMode.amStandart;
                                else if (Opt.cb_audioMode.SelectedIndex == 2)
                                    ARenderer.AudioMode = TAudioMode.amCompact;

                                if (ARenderer.PAR == 1)
                                    ARenderer.AspectRatio = TAspectRatio.ar1_1;
                                else if (ARenderer.SAR < 1.4)
                                    ARenderer.AspectRatio = TAspectRatio.ar4_3;
                                else
                                    ARenderer.AspectRatio = TAspectRatio.ar16_9;

                                if (FVegas.Project.Video.FieldOrder == VideoFieldOrder.ProgressiveScan)
                                    ARenderer.FieldOrder = CvgFieldOrder.foProgressive;
                                else if (FVegas.Project.Video.FieldOrder == VideoFieldOrder.LowerFieldFirst)
                                    ARenderer.FieldOrder = CvgFieldOrder.foLower;
                                else if (FVegas.Project.Video.FieldOrder == VideoFieldOrder.UpperFieldFirst)
                                    ARenderer.FieldOrder = CvgFieldOrder.foUpper;

                                ARenderer.ScaleMode = (CvgScaleMode)(Opt.cb_ScaleMode.SelectedIndex);

                                ARenderer.Proceed();

                                if (Log.HasErrors())
                                    Log.Error("Рендеринг прерван!");
                                else
                                    Log.Message("Рендеринг завершен успешно.", TLogEventType.leInfo);
                            }
                            catch
                            {
                                Log.Error("Ошибка рендеринга проекта.");

                                ARenderer.Cancel();

                                FVegas.CancelAsynchronousTasks();
                            }
                        }
                        finally
                        {
                            Done();
                            ARenderer.Dispose();
                        }
                    }
                }
                finally
                {

                }
            }
        }
    }
}