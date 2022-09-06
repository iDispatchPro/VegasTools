namespace VegasTools
{
    partial class TLog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TLog));
            this.Total_ProgressBar = new System.Windows.Forms.ProgressBar();
            this.TreeView = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btn_Stop = new System.Windows.Forms.Button();
            this.btn_ok = new System.Windows.Forms.Button();
            this.cb_ShutDown = new System.Windows.Forms.CheckBox();
            this.btn_Hide = new System.Windows.Forms.Button();
            this.Tray = new System.Windows.Forms.NotifyIcon(this.components);
            this.SuspendLayout();
            // 
            // Total_ProgressBar
            // 
            this.Total_ProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Total_ProgressBar.Location = new System.Drawing.Point(12, 407);
            this.Total_ProgressBar.Name = "Total_ProgressBar";
            this.Total_ProgressBar.Size = new System.Drawing.Size(645, 23);
            this.Total_ProgressBar.Step = 1;
            this.Total_ProgressBar.TabIndex = 1;
            // 
            // TreeView
            // 
            this.TreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TreeView.ImageIndex = 0;
            this.TreeView.ImageList = this.imageList1;
            this.TreeView.Location = new System.Drawing.Point(12, 41);
            this.TreeView.Name = "TreeView";
            this.TreeView.SelectedImageIndex = 0;
            this.TreeView.Size = new System.Drawing.Size(726, 360);
            this.TreeView.TabIndex = 2;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Feature.ico");
            this.imageList1.Images.SetKeyName(1, "Save.ico");
            this.imageList1.Images.SetKeyName(2, "exec.ico");
            this.imageList1.Images.SetKeyName(3, "Info.ico");
            this.imageList1.Images.SetKeyName(4, "Warning.ico");
            this.imageList1.Images.SetKeyName(5, "Error.ico");
            this.imageList1.Images.SetKeyName(6, "Render_Carbon_SD.png");
            this.imageList1.Images.SetKeyName(7, "Render_CCE_SD.png");
            this.imageList1.Images.SetKeyName(8, "Render_LossLess_HD.png");
            this.imageList1.Images.SetKeyName(9, "Render_x264_HD.png");
            this.imageList1.Images.SetKeyName(10, "Reset.ico");
            // 
            // btn_Stop
            // 
            this.btn_Stop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Stop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_Stop.Location = new System.Drawing.Point(663, 407);
            this.btn_Stop.Name = "btn_Stop";
            this.btn_Stop.Size = new System.Drawing.Size(75, 23);
            this.btn_Stop.TabIndex = 3;
            this.btn_Stop.Text = "Стоп!";
            this.btn_Stop.UseVisualStyleBackColor = true;
            this.btn_Stop.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_ok.Location = new System.Drawing.Point(12, 407);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 4;
            this.btn_ok.Text = "Ok";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // cb_ShutDown
            // 
            this.cb_ShutDown.AutoSize = true;
            this.cb_ShutDown.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.cb_ShutDown.ForeColor = System.Drawing.Color.Red;
            this.cb_ShutDown.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cb_ShutDown.ImageIndex = 10;
            this.cb_ShutDown.Location = new System.Drawing.Point(12, 12);
            this.cb_ShutDown.Name = "cb_ShutDown";
            this.cb_ShutDown.Size = new System.Drawing.Size(276, 17);
            this.cb_ShutDown.TabIndex = 5;
            this.cb_ShutDown.Text = "Выключить компьютер после завершения";
            this.cb_ShutDown.UseVisualStyleBackColor = true;
            // 
            // btn_Hide
            // 
            this.btn_Hide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Hide.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_Hide.Location = new System.Drawing.Point(663, 8);
            this.btn_Hide.Name = "btn_Hide";
            this.btn_Hide.Size = new System.Drawing.Size(75, 23);
            this.btn_Hide.TabIndex = 6;
            this.btn_Hide.Text = "Скрыть";
            this.btn_Hide.UseVisualStyleBackColor = true;
            this.btn_Hide.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Tray
            // 
            this.Tray.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.Tray.BalloonTipTitle = "Vegas tools";
            this.Tray.Icon = ((System.Drawing.Icon)(resources.GetObject("Tray.Icon")));
            this.Tray.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Tray_MouseMove);
            this.Tray.Click += new System.EventHandler(this.Tray_Click);
            // 
            // TLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 442);
            this.Controls.Add(this.btn_Hide);
            this.Controls.Add(this.cb_ShutDown);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.btn_Stop);
            this.Controls.Add(this.TreeView);
            this.Controls.Add(this.Total_ProgressBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TLog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vegas tools";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Log_Load);
            this.VisibleChanged += new System.EventHandler(this.TLog_VisibleChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar Total_ProgressBar;
        private System.Windows.Forms.TreeView TreeView;
        private System.Windows.Forms.Button btn_Stop;
        private System.Windows.Forms.Button btn_ok;
        public System.Windows.Forms.CheckBox cb_ShutDown;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btn_Hide;
        private System.Windows.Forms.NotifyIcon Tray;
    }
}