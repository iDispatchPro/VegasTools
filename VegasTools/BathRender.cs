using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ScriptPortal.Vegas;

namespace VegasTools
{
    public partial class BathRender : UserControl
    {
        public BathRender(Vegas AVegas)
        {
            vegas = AVegas;
            InitializeComponent();
        }

        Vegas vegas;
    }
}
