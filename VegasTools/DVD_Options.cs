using System;
using System.IO;
using System.Windows.Forms;
using ScriptPortal.Vegas;

namespace VegasTools
{
    public partial class DVD_Options : Form
    {
        TVT_Options FOptions;
        Vegas FVegas;

        public TRenderer Renderer;

        public DVD_Options(Vegas AVegas, TVT_Options AOptions, TRenderer ARenderer)
        {
            Renderer = ARenderer;
            FVegas = AVegas;
            FOptions = AOptions;

            InitializeComponent();

            Text = "Vegas tools 0.9.51 [Параметры " + ARenderer.Caption() + "]";

            cb_audioMode.Items.Add("PCM (48 кГц., 16 бит, стерео)");
            cb_audioMode.Items.Add(ARenderer.StandartAudioPresetName());
            cb_audioMode.Items.Add(ARenderer.CompactAudioPresetName());

            cb_audioMode.SelectedIndex = 1;
            cb_ScaleMode.SelectedIndex = 1;

            cbDblFPS.Enabled = FVegas.Project.Video.FieldOrder != ScriptPortal.Vegas.VideoFieldOrder.ProgressiveScan;

            if (!cbDblFPS.Enabled)
                cbHQ.Text = "Оптимизация";
            else
                cbHQ.Text = "Деинтерлейс";

            cbHQ.Checked = false;

            Renderer.Start = new Timecode(0);
            Renderer.Length = FVegas.Project.Length;
            Renderer.Bitrate = (int)(((Renderer.MaxBitrate * (60 * 60 * 25)) / Renderer.Length.FrameCount));

            se_BitRate.Maximum = Renderer.MaxBitrate;
            se_BitRate.Minimum = Renderer.MinBitrate;
            //cb_Deinterlace.Enabled = (FVegas.Project.Video.FieldOrder != VideoFieldOrder.ProgressiveScan);
            se_BitRate.Value = Renderer.Bitrate;
            Renderer.TargetFileName = Path.GetFileNameWithoutExtension(FVegas.Project.FilePath);
            tb_FileName.Text = Path.GetDirectoryName(FVegas.Project.FilePath) + "\\" + Renderer.TargetFileName + "_render\\";

            if (FVegas.SelectionLength.FrameCount > 0)
                cb_Source.SelectedIndex = 0;
            else if (FVegas.Project.Regions.Count > 0)
                cb_Source.SelectedIndex = 2;
            else
                cb_Source.SelectedIndex = 1;

            if (se_BitRate.Value < (int)(Renderer.MaxBitrate * 0.9))
                cb_Mode.SelectedIndex = 1;
            else
                cb_Mode.SelectedIndex = 0;

            if (Renderer is TDVD_Renderer)
            {
                se_Width.Enabled = false;
                se_Height.Enabled = false;
                btn_Larger.Enabled = false;
                btn_Smaller.Enabled = false;
            }

            if (Renderer is TLossLessRender)
                Height = 271;

            if (se_Width.Enabled)
            {
                Renderer.Width = FVegas.Project.Video.Width;
                Renderer.Height = FVegas.Project.Video.Height;
            }

            se_Width.Value = Renderer.Width;
            se_Height.Value = Renderer.Height;
        }

        private void cb_Mode_SelectedIndexChanged(object sender, EventArgs e)
        {
            se_BitRate.Visible = (cb_Mode.SelectedIndex != 2);
            se_Quantizer.Visible = (cb_Mode.SelectedIndex == 2);

            lb_Bitrate.Visible = !se_Quantizer.Visible;
            lb_Quantizer.Visible = se_Quantizer.Visible;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FolderDialog.SelectedPath = tb_FileName.Text;

            if (FolderDialog.ShowDialog() == DialogResult.OK)
            {
                tb_FileName.Text = FolderDialog.SelectedPath + "\\";
            }
        }

        private void cb_audioMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_SeparateAudio.Enabled = cb_audioMode.SelectedIndex > 0; 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            se_Width.Value *= 2;
            se_Height.Value *= 2;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            se_Width.Value /= 2;
            se_Height.Value /= 2;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void se_Width_ValueChanged(object sender, EventArgs e)
        {
            cb_ScaleMode.Enabled = (se_Width.Value != FVegas.Project.Video.Width) || (se_Height.Value != FVegas.Project.Video.Height);
        }

        private void DVD_Options_Load(object sender, EventArgs e)
        {
            cb_Mode.SelectedIndex = 2;
        }

        private void cbHQ_CheckedChanged(object sender, EventArgs e)
        {
//            seDenoiser.Enabled = cbHQ.Checked;
  //          seSharpen.Enabled = cbHQ.Checked;
        }
    }
}