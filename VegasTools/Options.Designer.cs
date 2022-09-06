namespace VegasTools
{
    partial class Options
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Options));
            this.Ok = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_BufFileName = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tb_LossLessCodec = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cb_UseGPU = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Ok
            // 
            this.Ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Ok.Location = new System.Drawing.Point(316, 141);
            this.Ok.Name = "Ok";
            this.Ok.Size = new System.Drawing.Size(75, 23);
            this.Ok.TabIndex = 1;
            this.Ok.Text = "Ok";
            this.Ok.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Файл:";
            // 
            // tb_BufFileName
            // 
            this.tb_BufFileName.Location = new System.Drawing.Point(77, 13);
            this.tb_BufFileName.Name = "tb_BufFileName";
            this.tb_BufFileName.Size = new System.Drawing.Size(265, 20);
            this.tb_BufFileName.TabIndex = 5;
            this.toolTip1.SetToolTip(this.tb_BufFileName, "Путь и имя файла, который будет использован для промежуточного сохранения видео, " +
                    "перед двухпроходной компрессией");
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(343, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(30, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Компрессия:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tb_LossLessCodec);
            this.groupBox1.Controls.Add(this.tb_BufFileName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(12, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(379, 72);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " Буффер ";
            // 
            // tb_LossLessCodec
            // 
            this.tb_LossLessCodec.Location = new System.Drawing.Point(77, 39);
            this.tb_LossLessCodec.Name = "tb_LossLessCodec";
            this.tb_LossLessCodec.Size = new System.Drawing.Size(265, 20);
            this.tb_LossLessCodec.TabIndex = 8;
            this.toolTip1.SetToolTip(this.tb_LossLessCodec, "Строка, описывающая компрессию для буферного файла. Пустая строка - без компресси" +
                    "и.");
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cb_UseGPU);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(372, 46);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = " Общие ";
            // 
            // cb_UseGPU
            // 
            this.cb_UseGPU.AutoSize = true;
            this.cb_UseGPU.Location = new System.Drawing.Point(9, 19);
            this.cb_UseGPU.Name = "cb_UseGPU";
            this.cb_UseGPU.Size = new System.Drawing.Size(67, 17);
            this.cb_UseGPU.TabIndex = 4;
            this.cb_UseGPU.Text = "Use GPU";
            this.toolTip1.SetToolTip(this.cb_UseGPU, "Использовать видеокарту для шумопонижения и увеличения резкости");
            this.cb_UseGPU.UseVisualStyleBackColor = true;
            // 
            // SaveFileDialog
            // 
            this.SaveFileDialog.DefaultExt = "avi";
            this.SaveFileDialog.Filter = "AVI(*.avi)|*.avi";
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 176);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Ok);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Options";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Параметры";
            this.TopMost = true;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Ok;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.SaveFileDialog SaveFileDialog;
        public System.Windows.Forms.TextBox tb_BufFileName;
        public System.Windows.Forms.CheckBox cb_UseGPU;
        public System.Windows.Forms.TextBox tb_LossLessCodec;
    }
}