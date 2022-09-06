using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VegasTools
{
    public partial class Options : Form
    {
        public Options(TVT_Options AOptions)
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog.FileName = tb_BufFileName.Text;

            if (SaveFileDialog.ShowDialog() == DialogResult.OK)
                tb_BufFileName.Text = SaveFileDialog.FileName;
        }
    }
}