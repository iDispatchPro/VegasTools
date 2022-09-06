using System;

namespace VegasTools
{
    public class TLossLessRender : TRenderer
    {
        public override int MaxBitrate
        {
            get
            {
                return 0;
            }
        }
        public override int MinBitrate
        {
            get
            {
                return 0;
            }
        }

        public override String AVSColorConvert()
        {
            return "ConvertToYUY2()";
        }

        override public String CompactAudioPresetName()
        {
            return "";
        }

        override public String StandartAudioPresetName()
        {
            return "";
        }

        override public TLogEventType Icon()
        {
            return TLogEventType.leAVI;
        }

        override public String Caption()
        {
            return "Lossless avi";
        }

        override public bool ForceAVS()
        {
            return false;
        }

        protected override string FullTargetFileName()
        {
            return TargetFileName + ".avi";
        }

        protected override void ExecuteVideoCompressor()
        {
            RenderLossLess(FullTargetFileName());

            FLog.Progress += 80;
        }

        protected override void ExecuteAudioCompressor()
        {

        }
    }
}
