namespace VegasTools
{
    partial class DVD_Options
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DVD_Options));
            this.Ok_Button = new System.Windows.Forms.Button();
            this.Cancel_Button = new System.Windows.Forms.Button();
            this.FolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.se_BitRate = new System.Windows.Forms.NumericUpDown();
            this.lb_Bitrate = new System.Windows.Forms.Label();
            this.se_Quantizer = new System.Windows.Forms.NumericUpDown();
            this.cb_Mode = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lb_Quantizer = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cb_audioMode = new System.Windows.Forms.ComboBox();
            this.cb_SeparateAudio = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.seSharpen = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.se_Border = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.seDenoiser = new System.Windows.Forms.NumericUpDown();
            this.cbDblFPS = new System.Windows.Forms.CheckBox();
            this.cbHQ = new System.Windows.Forms.CheckBox();
            this.cb_ScaleMode = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btn_Smaller = new System.Windows.Forms.Button();
            this.btn_Larger = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.se_Height = new System.Windows.Forms.NumericUpDown();
            this.se_Width = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.cb_Source = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tb_FileName = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.se_BitRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.se_Quantizer)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.seSharpen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.se_Border)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.seDenoiser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.se_Height)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.se_Width)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // Ok_Button
            // 
            this.Ok_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Ok_Button.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Ok_Button.Location = new System.Drawing.Point(254, 284);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(75, 23);
            this.Ok_Button.TabIndex = 2;
            this.Ok_Button.Text = "Ok";
            this.Ok_Button.UseVisualStyleBackColor = true;
            this.Ok_Button.Click += new System.EventHandler(this.button1_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel_Button.Location = new System.Drawing.Point(335, 284);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(75, 23);
            this.Cancel_Button.TabIndex = 3;
            this.Cancel_Button.Text = "Отмена";
            this.Cancel_Button.UseVisualStyleBackColor = true;
            // 
            // FolderDialog
            // 
            this.FolderDialog.Description = "Укажите каталог, в который будут отрендерен проект.";
            this.FolderDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // se_BitRate
            // 
            this.se_BitRate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.se_BitRate.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.se_BitRate.Location = new System.Drawing.Point(338, 20);
            this.se_BitRate.Maximum = new decimal(new int[] {
            9500,
            0,
            0,
            0});
            this.se_BitRate.Minimum = new decimal(new int[] {
            2500,
            0,
            0,
            0});
            this.se_BitRate.Name = "se_BitRate";
            this.se_BitRate.Size = new System.Drawing.Size(53, 20);
            this.se_BitRate.TabIndex = 8;
            this.se_BitRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.se_BitRate.ThousandsSeparator = true;
            this.se_BitRate.Value = new decimal(new int[] {
            9500,
            0,
            0,
            0});
            // 
            // lb_Bitrate
            // 
            this.lb_Bitrate.AutoSize = true;
            this.lb_Bitrate.Location = new System.Drawing.Point(229, 22);
            this.lb_Bitrate.Name = "lb_Bitrate";
            this.lb_Bitrate.Size = new System.Drawing.Size(51, 13);
            this.lb_Bitrate.TabIndex = 12;
            this.lb_Bitrate.Text = "Битрейт:";
            // 
            // se_Quantizer
            // 
            this.se_Quantizer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.se_Quantizer.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.se_Quantizer.Location = new System.Drawing.Point(338, 20);
            this.se_Quantizer.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.se_Quantizer.Name = "se_Quantizer";
            this.se_Quantizer.Size = new System.Drawing.Size(53, 20);
            this.se_Quantizer.TabIndex = 13;
            this.se_Quantizer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.se_Quantizer.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // cb_Mode
            // 
            this.cb_Mode.FormattingEnabled = true;
            this.cb_Mode.Items.AddRange(new object[] {
            "Постоянный битрейт",
            "Переменный битрейт (2 прохода)",
            "Постоянный квантизер",
            "Переменный битрейт с буфером",
            "Только звук"});
            this.cb_Mode.Location = new System.Drawing.Point(70, 19);
            this.cb_Mode.Name = "cb_Mode";
            this.cb_Mode.Size = new System.Drawing.Size(153, 21);
            this.cb_Mode.TabIndex = 13;
            this.cb_Mode.SelectedIndexChanged += new System.EventHandler(this.cb_Mode_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Режим:";
            // 
            // lb_Quantizer
            // 
            this.lb_Quantizer.AutoSize = true;
            this.lb_Quantizer.Location = new System.Drawing.Point(229, 22);
            this.lb_Quantizer.Name = "lb_Quantizer";
            this.lb_Quantizer.Size = new System.Drawing.Size(64, 13);
            this.lb_Quantizer.TabIndex = 15;
            this.lb_Quantizer.Text = "Квантизер:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.cb_audioMode);
            this.groupBox2.Controls.Add(this.cb_SeparateAudio);
            this.groupBox2.Controls.Add(this.lb_Quantizer);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cb_Mode);
            this.groupBox2.Controls.Add(this.se_Quantizer);
            this.groupBox2.Controls.Add(this.lb_Bitrate);
            this.groupBox2.Controls.Add(this.se_BitRate);
            this.groupBox2.Location = new System.Drawing.Point(12, 94);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(400, 73);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = " Компрессия ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "Звук:";
            // 
            // cb_audioMode
            // 
            this.cb_audioMode.FormattingEnabled = true;
            this.cb_audioMode.Location = new System.Drawing.Point(70, 44);
            this.cb_audioMode.Name = "cb_audioMode";
            this.cb_audioMode.Size = new System.Drawing.Size(153, 21);
            this.cb_audioMode.TabIndex = 25;
            this.cb_audioMode.SelectedIndexChanged += new System.EventHandler(this.cb_audioMode_SelectedIndexChanged);
            // 
            // cb_SeparateAudio
            // 
            this.cb_SeparateAudio.AutoSize = true;
            this.cb_SeparateAudio.Location = new System.Drawing.Point(232, 46);
            this.cb_SeparateAudio.Name = "cb_SeparateAudio";
            this.cb_SeparateAudio.Size = new System.Drawing.Size(100, 17);
            this.cb_SeparateAudio.TabIndex = 22;
            this.cb_SeparateAudio.Text = "Звук отдельно";
            this.ToolTip.SetToolTip(this.cb_SeparateAudio, "Звук и видео сохраняются в 2 раздельных файла");
            this.cb_SeparateAudio.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(113, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Резкость:";
            // 
            // seSharpen
            // 
            this.seSharpen.DecimalPlaces = 1;
            this.seSharpen.Location = new System.Drawing.Point(176, 45);
            this.seSharpen.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.seSharpen.Name = "seSharpen";
            this.seSharpen.Size = new System.Drawing.Size(47, 20);
            this.seSharpen.TabIndex = 17;
            this.seSharpen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.seSharpen.ThousandsSeparator = true;
            this.ToolTip.SetToolTip(this.seSharpen, "Увеличение резкости (0-10)");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(113, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Кроп:";
            // 
            // se_Border
            // 
            this.se_Border.Increment = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.se_Border.Location = new System.Drawing.Point(176, 72);
            this.se_Border.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.se_Border.Name = "se_Border";
            this.se_Border.Size = new System.Drawing.Size(47, 20);
            this.se_Border.TabIndex = 19;
            this.se_Border.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.se_Border.ThousandsSeparator = true;
            this.ToolTip.SetToolTip(this.se_Border, "Черная рамка для скрытия дефектов изображения по краям кадра. Типичное значение д" +
                    "ля VHS - 16.");
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.seDenoiser);
            this.groupBox1.Controls.Add(this.cbDblFPS);
            this.groupBox1.Controls.Add(this.cbHQ);
            this.groupBox1.Controls.Add(this.cb_ScaleMode);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.btn_Smaller);
            this.groupBox1.Controls.Add(this.se_Border);
            this.groupBox1.Controls.Add(this.btn_Larger);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.seSharpen);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.se_Height);
            this.groupBox1.Controls.Add(this.se_Width);
            this.groupBox1.Location = new System.Drawing.Point(12, 174);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(400, 104);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " Постпроцессинг ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(113, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 44;
            this.label1.Text = "Шумодав:";
            // 
            // seDenoiser
            // 
            this.seDenoiser.DecimalPlaces = 1;
            this.seDenoiser.Location = new System.Drawing.Point(176, 19);
            this.seDenoiser.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.seDenoiser.Name = "seDenoiser";
            this.seDenoiser.Size = new System.Drawing.Size(47, 20);
            this.seDenoiser.TabIndex = 45;
            this.seDenoiser.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.seDenoiser.ThousandsSeparator = true;
            this.ToolTip.SetToolTip(this.seDenoiser, "Сила шумопонижения (0-10)");
            // 
            // cbDblFPS
            // 
            this.cbDblFPS.AutoSize = true;
            this.cbDblFPS.Location = new System.Drawing.Point(10, 46);
            this.cbDblFPS.Name = "cbDblFPS";
            this.cbDblFPS.Size = new System.Drawing.Size(60, 17);
            this.cbDblFPS.TabIndex = 43;
            this.cbDblFPS.Text = "2x FPS";
            this.ToolTip.SetToolTip(this.cbDblFPS, "Удвоение FPS путем интерполяции кадров");
            this.cbDblFPS.UseVisualStyleBackColor = true;
            // 
            // cbHQ
            // 
            this.cbHQ.AutoSize = true;
            this.cbHQ.Location = new System.Drawing.Point(10, 20);
            this.cbHQ.Name = "cbHQ";
            this.cbHQ.Size = new System.Drawing.Size(94, 17);
            this.cbHQ.TabIndex = 42;
            this.cbHQ.Text = "Деинтерлейс";
            this.ToolTip.SetToolTip(this.cbHQ, "Включает оптимизацию видео и, при необходимости, деинтерлейс.");
            this.cbHQ.UseVisualStyleBackColor = true;
            this.cbHQ.CheckedChanged += new System.EventHandler(this.cbHQ_CheckedChanged);
            // 
            // cb_ScaleMode
            // 
            this.cb_ScaleMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_ScaleMode.FormattingEnabled = true;
            this.cb_ScaleMode.Items.AddRange(new object[] {
            "Растянуть",
            "Вписать",
            "Обрезать"});
            this.cb_ScaleMode.Location = new System.Drawing.Point(284, 71);
            this.cb_ScaleMode.Name = "cb_ScaleMode";
            this.cb_ScaleMode.Size = new System.Drawing.Size(107, 21);
            this.cb_ScaleMode.TabIndex = 39;
            this.ToolTip.SetToolTip(this.cb_ScaleMode, resources.GetString("cb_ScaleMode.ToolTip"));
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(229, 74);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(45, 13);
            this.label11.TabIndex = 41;
            this.label11.Text = "Режим:";
            // 
            // btn_Smaller
            // 
            this.btn_Smaller.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Smaller.Location = new System.Drawing.Point(337, 19);
            this.btn_Smaller.Name = "btn_Smaller";
            this.btn_Smaller.Size = new System.Drawing.Size(24, 46);
            this.btn_Smaller.TabIndex = 37;
            this.btn_Smaller.Text = "<";
            this.ToolTip.SetToolTip(this.btn_Smaller, "Меньший размер");
            this.btn_Smaller.UseVisualStyleBackColor = true;
            this.btn_Smaller.Click += new System.EventHandler(this.button5_Click);
            // 
            // btn_Larger
            // 
            this.btn_Larger.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Larger.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_Larger.Location = new System.Drawing.Point(367, 19);
            this.btn_Larger.Name = "btn_Larger";
            this.btn_Larger.Size = new System.Drawing.Size(24, 46);
            this.btn_Larger.TabIndex = 36;
            this.btn_Larger.Text = ">";
            this.ToolTip.SetToolTip(this.btn_Larger, "Больший размер");
            this.btn_Larger.UseVisualStyleBackColor = true;
            this.btn_Larger.Click += new System.EventHandler(this.button4_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(229, 48);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 13);
            this.label10.TabIndex = 35;
            this.label10.Text = "Высота:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(229, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 34;
            this.label9.Text = "Ширина:";
            // 
            // se_Height
            // 
            this.se_Height.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.se_Height.Location = new System.Drawing.Point(284, 45);
            this.se_Height.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.se_Height.Minimum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.se_Height.Name = "se_Height";
            this.se_Height.Size = new System.Drawing.Size(47, 20);
            this.se_Height.TabIndex = 33;
            this.se_Height.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.se_Height.ThousandsSeparator = true;
            this.ToolTip.SetToolTip(this.se_Height, "Высота кадра результирующего видео.");
            this.se_Height.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.se_Height.ValueChanged += new System.EventHandler(this.se_Width_ValueChanged);
            // 
            // se_Width
            // 
            this.se_Width.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.se_Width.Location = new System.Drawing.Point(284, 19);
            this.se_Width.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.se_Width.Minimum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.se_Width.Name = "se_Width";
            this.se_Width.Size = new System.Drawing.Size(47, 20);
            this.se_Width.TabIndex = 32;
            this.se_Width.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.se_Width.ThousandsSeparator = true;
            this.ToolTip.SetToolTip(this.se_Width, "Ширина кадра результирующего видео.");
            this.se_Width.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.se_Width.ValueChanged += new System.EventHandler(this.se_Width_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Каталог:";
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(367, 44);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(24, 23);
            this.button3.TabIndex = 14;
            this.button3.Text = "...";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // cb_Source
            // 
            this.cb_Source.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_Source.FormattingEnabled = true;
            this.cb_Source.Items.AddRange(new object[] {
            "Выделение",
            "Весь проект",
            "Регионы",
            "Эвенты",
            "Выделенные эвенты"});
            this.cb_Source.Location = new System.Drawing.Point(70, 19);
            this.cb_Source.Name = "cb_Source";
            this.cb_Source.Size = new System.Drawing.Size(321, 21);
            this.cb_Source.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Режим:";
            // 
            // tb_FileName
            // 
            this.tb_FileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_FileName.Location = new System.Drawing.Point(70, 46);
            this.tb_FileName.Name = "tb_FileName";
            this.tb_FileName.Size = new System.Drawing.Size(298, 20);
            this.tb_FileName.TabIndex = 18;
            this.ToolTip.SetToolTip(this.tb_FileName, "Каталог для сохранения результатов рендеринга. Имена файлов результатов зависят о" +
                    "т режима проекта и наличия предыдущих результатов рендеринга.");
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.tb_FileName);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.cb_Source);
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(400, 76);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = " Проект ";
            // 
            // ToolTip
            // 
            this.ToolTip.AutoPopDelay = 50000;
            this.ToolTip.InitialDelay = 500;
            this.ToolTip.IsBalloon = true;
            this.ToolTip.ReshowDelay = 100;
            this.ToolTip.ShowAlways = true;
            this.ToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ToolTip.ToolTipTitle = "Vegas tools";
            // 
            // DVD_Options
            // 
            this.AcceptButton = this.Ok_Button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel_Button;
            this.ClientSize = new System.Drawing.Size(422, 319);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.Ok_Button);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DVD_Options";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Параметры рендеринга";
            this.Load += new System.EventHandler(this.DVD_Options_Load);
            ((System.ComponentModel.ISupportInitialize)(this.se_BitRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.se_Quantizer)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.seSharpen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.se_Border)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.seDenoiser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.se_Height)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.se_Width)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Ok_Button;
        private System.Windows.Forms.Button Cancel_Button;
        public System.Windows.Forms.FolderBrowserDialog FolderDialog;
        public System.Windows.Forms.NumericUpDown se_BitRate;
        private System.Windows.Forms.Label lb_Bitrate;
        public System.Windows.Forms.NumericUpDown se_Quantizer;
        public System.Windows.Forms.ComboBox cb_Mode;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label lb_Quantizer;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.NumericUpDown seSharpen;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.NumericUpDown se_Border;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button3;
        public System.Windows.Forms.ComboBox cb_Source;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox tb_FileName;
        private System.Windows.Forms.GroupBox groupBox3;
        public System.Windows.Forms.CheckBox cb_SeparateAudio;
        private System.Windows.Forms.ToolTip ToolTip;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.ComboBox cb_audioMode;
        private System.Windows.Forms.Button btn_Smaller;
        private System.Windows.Forms.Button btn_Larger;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.NumericUpDown se_Height;
        public System.Windows.Forms.NumericUpDown se_Width;
        public System.Windows.Forms.ComboBox cb_ScaleMode;
        private System.Windows.Forms.Label label11;
        public System.Windows.Forms.CheckBox cbHQ;
        public System.Windows.Forms.CheckBox cbDblFPS;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.NumericUpDown seDenoiser;
    }
}