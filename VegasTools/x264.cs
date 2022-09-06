using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace VegasTools
{
    public class Tx264 : TRenderer
    {
        String dummyFile = "c:\\temp\\dummy.avi";

        override public String CompactAudioPresetName()
        {
            return "Компактный ААС";
        }

        override public String StandartAudioPresetName()
        {
            return "Стандартный AAC";
        }

        override public TLogEventType Icon()
        {
            return TLogEventType.lex264;
        }

        override public String Caption()
        {
            return "x264";
        }

        //public override String AVSColorConvert()
        //{
        //    return "ConvertToYV12()";
        //}

        override public bool ForceAVS()
        {
            return false;
        }

        protected override string FullTargetFileName()
        {
            return "c:\\temp\\output.mp4";
        }

        public override void Muxing()
        {
            var videoFile = TargetFileName + "_a_.mp4";

            FLog.Message("Audio: " + videoFile, TLogEventType.leInfo);
            FLog.Message("Video: " + FullTargetFileName(), TLogEventType.leInfo);

            FSysHelper.Launch(FSysHelper.MyPath + "MP4Box.exe", " -add \"" + videoFile + "\" -add \"" + FullTargetFileName() + "\" -new \"" + TargetFileName + ".mp4\" ", true, FLog, true);

            if (File.Exists(TargetFileName + ".mp4"))
            {
                DeleteFile(TargetFileName + "_a_.mp4");
                DeleteFile(FullTargetFileName());
            }
        }

        public override int MaxBitrate
        {
            get
            {
                return 2500;
            }
        }
        public override int MinBitrate
        {
            get
            {
                return 50;
            }
        }

        protected override void ExecuteAudioCompressor()
        {
            if (AudioMode == TAudioMode.amStandart)
                DoRender("Wave (Microsoft)", "Vegas tools AAC", TargetFileName + ".wav", true);
            else if (AudioMode == TAudioMode.amCompact)
                DoRender("Wave (Microsoft)", "Vegas tools compact AAC", TargetFileName + ".wav", true);

            try
            {
                FSysHelper.KillProcess("NeroAAC");
                String Ext;

                if (SkipVideo)
                    Ext = ".mp4";
                else
                    Ext = "_a_.mp4";

                if (AudioMode == TAudioMode.amCompact)
                    FSysHelper.Launch(FSysHelper.MyPath + "NeroAAC.exe", " -q 0.35 -if \"" + TargetFileName + ".wav\" -of \"" + TargetFileName + Ext + "\"", true, FLog, true);
                else if (AudioMode == TAudioMode.amStandart)
                    FSysHelper.Launch(FSysHelper.MyPath + "NeroAAC.exe", " -q 0.5 -if \"" + TargetFileName + ".wav\" -of \"" + TargetFileName + Ext + "\"", true, FLog, true);
            }
            finally
            {
                FSysHelper.KillProcess("NeroAAC");
                DeleteFile(TargetFileName + ".wav");
            }
        }

        void Pass(String AParams)
        {
            FSysHelper.KillProcess("x264");
            Process x264 = FSysHelper.Launch(FSysHelper.MyPath + "x264.exe", " \"" + SourceFileName + "\" " + AParams, true, FLog, true);
            /*String Output;

            while (!x264.HasExited)
            {
                Application.DoEvents();
                System.Threading.Thread.Sleep(0);
                Output = x264.StandardOutput.ReadToEnd();
                Output += "d";
            }*/
        }

        protected override void ExecuteVideoCompressor()
        {
            try
            {
                String Params = "";// " --threads 1 ";

                Params += " --preset veryslow --tune film --vbv-maxrate 25000 --vbv-bufsize 25000 --level 4.1 --open-gop --partitions all";
                // Params += " --level 4.0 --aud --nal-hrd vbr --vbv-bufsize 25000 --vbv-maxrate 25000 --filter 0,0 --ref 3 --bframes 3 --b-adapt 1 --b-pyramid none --subme 7 --aq-mode 1 --trellis 1 --partitions all --me umh";
                //Params += " --progress ";

                if (AspectRatio == TAspectRatio.ar16_9)
                    Params += " --sar 14568:10000 ";
                else if (AspectRatio == TAspectRatio.ar4_3)
                    Params += " --sar 10926:10000 ";
                else
                    Params += " --sar 1:1 ";

                if (Quantizer > 20)
                    DoRender("Video for Windows", "x264 LowQuality", dummyFile, true);
                else
                    DoRender("Video for Windows", "x264 HighQuality", dummyFile, true);

                FLog.Progress += 80;              
            }
            finally
            {
               // FSysHelper.KillProcess("x264");
               DeleteFile(dummyFile);
            }
        }
    }
}
