namespace VegasTools
{
    partial class Navigator
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ToolStripButton VideoEvent_Autonavigate;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Navigator));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Video_Page = new System.Windows.Forms.TabPage();
            this.VideoEvents_View = new System.Windows.Forms.ListView();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader12 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader13 = new System.Windows.Forms.ColumnHeader();
            this.PARColumn = new System.Windows.Forms.ColumnHeader();
            this.columnHeader14 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader22 = new System.Windows.Forms.ColumnHeader();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.VideoEvents_Filter = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel5 = new System.Windows.Forms.ToolStripLabel();
            this.VideoEvents_Filter_FX = new System.Windows.Forms.ToolStripTextBox();
            this.Audio_Page = new System.Windows.Forms.TabPage();
            this.AudioEvents_View = new System.Windows.Forms.ListView();
            this.columnHeader15 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader16 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader17 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader18 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader19 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader23 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader20 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader21 = new System.Windows.Forms.ColumnHeader();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBox2 = new System.Windows.Forms.ToolStripTextBox();
            this.Markers_Page = new System.Windows.Forms.TabPage();
            this.Markers_View = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.toolStrip4 = new System.Windows.Forms.ToolStrip();
            this.Markers_Autonavigate = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.Markers_Filter = new System.Windows.Forms.ToolStripTextBox();
            this.Markers_ShowUnLabelled = new System.Windows.Forms.ToolStripButton();
            this.Regions_Page = new System.Windows.Forms.TabPage();
            this.Regions_View = new System.Windows.Forms.ListView();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.Regions_Autonavigate = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.Regions_Filter = new System.Windows.Forms.ToolStripTextBox();
            this.Regions_ShowUnLabelled = new System.Windows.Forms.ToolStripButton();
            this.columnHeader24 = new System.Windows.Forms.ColumnHeader();
            VideoEvent_Autonavigate = new System.Windows.Forms.ToolStripButton();
            this.tabControl1.SuspendLayout();
            this.Video_Page.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.Audio_Page.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            this.Markers_Page.SuspendLayout();
            this.toolStrip4.SuspendLayout();
            this.Regions_Page.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // VideoEvent_Autonavigate
            // 
            VideoEvent_Autonavigate.CheckOnClick = true;
            VideoEvent_Autonavigate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            VideoEvent_Autonavigate.Image = ((System.Drawing.Image)(resources.GetObject("VideoEvent_Autonavigate.Image")));
            VideoEvent_Autonavigate.ImageTransparentColor = System.Drawing.Color.Magenta;
            VideoEvent_Autonavigate.Name = "VideoEvent_Autonavigate";
            VideoEvent_Autonavigate.Size = new System.Drawing.Size(23, 22);
            VideoEvent_Autonavigate.Text = "Автонавигация";
            VideoEvent_Autonavigate.ToolTipText = "Автоматически переходить на видеоэвент при выделении его в списке";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Video_Page);
            this.tabControl1.Controls.Add(this.Audio_Page);
            this.tabControl1.Controls.Add(this.Markers_Page);
            this.tabControl1.Controls.Add(this.Regions_Page);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ImageList = this.imageList1;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(653, 330);
            this.tabControl1.TabIndex = 1;
            // 
            // Video_Page
            // 
            this.Video_Page.Controls.Add(this.VideoEvents_View);
            this.Video_Page.Controls.Add(this.toolStrip2);
            this.Video_Page.ImageIndex = 0;
            this.Video_Page.Location = new System.Drawing.Point(4, 23);
            this.Video_Page.Name = "Video_Page";
            this.Video_Page.Padding = new System.Windows.Forms.Padding(3);
            this.Video_Page.Size = new System.Drawing.Size(645, 303);
            this.Video_Page.TabIndex = 0;
            this.Video_Page.Text = "Видео";
            this.Video_Page.UseVisualStyleBackColor = true;
            // 
            // VideoEvents_View
            // 
            this.VideoEvents_View.AllowColumnReorder = true;
            this.VideoEvents_View.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13,
            this.PARColumn,
            this.columnHeader24,
            this.columnHeader14,
            this.columnHeader22});
            this.VideoEvents_View.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VideoEvents_View.FullRowSelect = true;
            this.VideoEvents_View.Location = new System.Drawing.Point(3, 28);
            this.VideoEvents_View.Name = "VideoEvents_View";
            this.VideoEvents_View.Size = new System.Drawing.Size(639, 272);
            this.VideoEvents_View.SmallImageList = this.imageList1;
            this.VideoEvents_View.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.VideoEvents_View.TabIndex = 5;
            this.VideoEvents_View.UseCompatibleStateImageBehavior = false;
            this.VideoEvents_View.View = System.Windows.Forms.View.Details;
            this.VideoEvents_View.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.VideoEvents_View_MouseDoubleClick);
            this.VideoEvents_View.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.VideoEvents_View_ItemSelectionChanged);
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "№";
            this.columnHeader8.Width = 50;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Метка";
            this.columnHeader9.Width = 300;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Позиция";
            this.columnHeader10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader10.Width = 80;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Длинна";
            this.columnHeader11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader11.Width = 80;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Поля";
            this.columnHeader12.Width = 100;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Разрешение";
            this.columnHeader13.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader13.Width = 100;
            // 
            // PARColumn
            // 
            this.PARColumn.DisplayIndex = 8;
            this.PARColumn.Text = "PAR";
            // 
            // columnHeader14
            // 
            this.columnHeader14.DisplayIndex = 6;
            this.columnHeader14.Text = "Путь к файлу";
            this.columnHeader14.Width = 200;
            // 
            // columnHeader22
            // 
            this.columnHeader22.DisplayIndex = 7;
            this.columnHeader22.Text = "Эффекты";
            this.columnHeader22.Width = 200;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Видео.ico");
            this.imageList1.Images.SetKeyName(1, "Аудио.ico");
            this.imageList1.Images.SetKeyName(2, "Маркер.ico");
            this.imageList1.Images.SetKeyName(3, "Регион.ico");
            this.imageList1.Images.SetKeyName(4, "Error.ico");
            // 
            // toolStrip2
            // 
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            VideoEvent_Autonavigate,
            this.toolStripSeparator2,
            this.toolStripLabel2,
            this.VideoEvents_Filter,
            this.toolStripSeparator5,
            this.toolStripLabel5,
            this.VideoEvents_Filter_FX});
            this.toolStrip2.Location = new System.Drawing.Point(3, 3);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(639, 25);
            this.toolStrip2.TabIndex = 4;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(51, 22);
            this.toolStripLabel2.Text = "Фильтр:";
            // 
            // VideoEvents_Filter
            // 
            this.VideoEvents_Filter.Name = "VideoEvents_Filter";
            this.VideoEvents_Filter.Size = new System.Drawing.Size(100, 25);
            this.VideoEvents_Filter.TextChanged += new System.EventHandler(this.VideoEvents_Filter_TextChanged);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel5
            // 
            this.toolStripLabel5.Name = "toolStripLabel5";
            this.toolStripLabel5.Size = new System.Drawing.Size(61, 22);
            this.toolStripLabel5.Text = "Эффекты:";
            // 
            // VideoEvents_Filter_FX
            // 
            this.VideoEvents_Filter_FX.Name = "VideoEvents_Filter_FX";
            this.VideoEvents_Filter_FX.Size = new System.Drawing.Size(100, 25);
            this.VideoEvents_Filter_FX.TextChanged += new System.EventHandler(this.VideoEvents_Filter_FX_TextChanged);
            // 
            // Audio_Page
            // 
            this.Audio_Page.Controls.Add(this.AudioEvents_View);
            this.Audio_Page.Controls.Add(this.toolStrip3);
            this.Audio_Page.ImageIndex = 1;
            this.Audio_Page.Location = new System.Drawing.Point(4, 23);
            this.Audio_Page.Name = "Audio_Page";
            this.Audio_Page.Padding = new System.Windows.Forms.Padding(3);
            this.Audio_Page.Size = new System.Drawing.Size(645, 303);
            this.Audio_Page.TabIndex = 3;
            this.Audio_Page.Text = "Аудио";
            this.Audio_Page.UseVisualStyleBackColor = true;
            // 
            // AudioEvents_View
            // 
            this.AudioEvents_View.AllowColumnReorder = true;
            this.AudioEvents_View.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader15,
            this.columnHeader16,
            this.columnHeader17,
            this.columnHeader18,
            this.columnHeader19,
            this.columnHeader23,
            this.columnHeader20,
            this.columnHeader21});
            this.AudioEvents_View.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AudioEvents_View.FullRowSelect = true;
            this.AudioEvents_View.Location = new System.Drawing.Point(3, 28);
            this.AudioEvents_View.Name = "AudioEvents_View";
            this.AudioEvents_View.Size = new System.Drawing.Size(639, 272);
            this.AudioEvents_View.SmallImageList = this.imageList1;
            this.AudioEvents_View.TabIndex = 6;
            this.AudioEvents_View.UseCompatibleStateImageBehavior = false;
            this.AudioEvents_View.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "№";
            this.columnHeader15.Width = 50;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "Метка";
            this.columnHeader16.Width = 300;
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "Позиция";
            this.columnHeader17.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader17.Width = 80;
            // 
            // columnHeader18
            // 
            this.columnHeader18.Text = "Длинна";
            this.columnHeader18.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader18.Width = 80;
            // 
            // columnHeader19
            // 
            this.columnHeader19.Text = "Каналы";
            this.columnHeader19.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader23
            // 
            this.columnHeader23.Text = "Частота";
            // 
            // columnHeader20
            // 
            this.columnHeader20.Text = "Глубина";
            this.columnHeader20.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader21
            // 
            this.columnHeader21.Text = "Путь к файлу";
            this.columnHeader21.Width = 200;
            // 
            // toolStrip3
            // 
            this.toolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton3,
            this.toolStripSeparator3,
            this.toolStripLabel3,
            this.toolStripTextBox2});
            this.toolStrip3.Location = new System.Drawing.Point(3, 3);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(639, 25);
            this.toolStrip3.TabIndex = 5;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.CheckOnClick = true;
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "Автонавигация";
            this.toolStripButton3.ToolTipText = "Автоматически переходить на регион при выделении его в списке";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(51, 22);
            this.toolStripLabel3.Text = "Фильтр:";
            // 
            // toolStripTextBox2
            // 
            this.toolStripTextBox2.Name = "toolStripTextBox2";
            this.toolStripTextBox2.Size = new System.Drawing.Size(100, 25);
            // 
            // Markers_Page
            // 
            this.Markers_Page.Controls.Add(this.Markers_View);
            this.Markers_Page.Controls.Add(this.toolStrip4);
            this.Markers_Page.ImageIndex = 2;
            this.Markers_Page.Location = new System.Drawing.Point(4, 23);
            this.Markers_Page.Name = "Markers_Page";
            this.Markers_Page.Padding = new System.Windows.Forms.Padding(3);
            this.Markers_Page.Size = new System.Drawing.Size(645, 303);
            this.Markers_Page.TabIndex = 1;
            this.Markers_Page.Text = "Маркеры";
            this.Markers_Page.UseVisualStyleBackColor = true;
            // 
            // Markers_View
            // 
            this.Markers_View.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.Markers_View.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Markers_View.FullRowSelect = true;
            this.Markers_View.Location = new System.Drawing.Point(3, 28);
            this.Markers_View.Name = "Markers_View";
            this.Markers_View.Size = new System.Drawing.Size(639, 272);
            this.Markers_View.SmallImageList = this.imageList1;
            this.Markers_View.TabIndex = 4;
            this.Markers_View.UseCompatibleStateImageBehavior = false;
            this.Markers_View.View = System.Windows.Forms.View.Details;
            this.Markers_View.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Markers_View_MouseDoubleClick);
            this.Markers_View.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.Markers_View_AfterLabelEdit);
            this.Markers_View.SelectedIndexChanged += new System.EventHandler(this.Markers_View_SelectedIndexChanged);
            this.Markers_View.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Markers_View_KeyDown);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "№";
            this.columnHeader1.Width = 50;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Метка";
            this.columnHeader2.Width = 300;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Позиция";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 100;
            // 
            // toolStrip4
            // 
            this.toolStrip4.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Markers_Autonavigate,
            this.toolStripSeparator4,
            this.toolStripLabel4,
            this.Markers_Filter,
            this.Markers_ShowUnLabelled});
            this.toolStrip4.Location = new System.Drawing.Point(3, 3);
            this.toolStrip4.Name = "toolStrip4";
            this.toolStrip4.Size = new System.Drawing.Size(639, 25);
            this.toolStrip4.TabIndex = 2;
            this.toolStrip4.Text = "toolStrip4";
            // 
            // Markers_Autonavigate
            // 
            this.Markers_Autonavigate.CheckOnClick = true;
            this.Markers_Autonavigate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Markers_Autonavigate.Image = ((System.Drawing.Image)(resources.GetObject("Markers_Autonavigate.Image")));
            this.Markers_Autonavigate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Markers_Autonavigate.Name = "Markers_Autonavigate";
            this.Markers_Autonavigate.Size = new System.Drawing.Size(23, 22);
            this.Markers_Autonavigate.Text = "Автонавигация";
            this.Markers_Autonavigate.ToolTipText = "Автоматически переходить на маркер при выделении его в списке";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(51, 22);
            this.toolStripLabel4.Text = "Фильтр:";
            // 
            // Markers_Filter
            // 
            this.Markers_Filter.Name = "Markers_Filter";
            this.Markers_Filter.Size = new System.Drawing.Size(100, 25);
            this.Markers_Filter.TextChanged += new System.EventHandler(this.Markers_Filter_TextChanged);
            // 
            // Markers_ShowUnLabelled
            // 
            this.Markers_ShowUnLabelled.CheckOnClick = true;
            this.Markers_ShowUnLabelled.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Markers_ShowUnLabelled.Image = ((System.Drawing.Image)(resources.GetObject("Markers_ShowUnLabelled.Image")));
            this.Markers_ShowUnLabelled.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Markers_ShowUnLabelled.Name = "Markers_ShowUnLabelled";
            this.Markers_ShowUnLabelled.Size = new System.Drawing.Size(23, 22);
            this.Markers_ShowUnLabelled.Text = "Показывать маркеры с пустой меткой";
            this.Markers_ShowUnLabelled.Click += new System.EventHandler(this.Markers_ShowUnLabelled_Click);
            // 
            // Regions_Page
            // 
            this.Regions_Page.Controls.Add(this.Regions_View);
            this.Regions_Page.Controls.Add(this.toolStrip1);
            this.Regions_Page.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Regions_Page.ImageIndex = 3;
            this.Regions_Page.Location = new System.Drawing.Point(4, 23);
            this.Regions_Page.Name = "Regions_Page";
            this.Regions_Page.Padding = new System.Windows.Forms.Padding(3);
            this.Regions_Page.Size = new System.Drawing.Size(645, 303);
            this.Regions_Page.TabIndex = 2;
            this.Regions_Page.Text = "Регионы";
            this.Regions_Page.UseVisualStyleBackColor = true;
            // 
            // Regions_View
            // 
            this.Regions_View.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.Regions_View.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Regions_View.FullRowSelect = true;
            this.Regions_View.Location = new System.Drawing.Point(3, 28);
            this.Regions_View.Name = "Regions_View";
            this.Regions_View.Size = new System.Drawing.Size(639, 272);
            this.Regions_View.SmallImageList = this.imageList1;
            this.Regions_View.TabIndex = 5;
            this.Regions_View.UseCompatibleStateImageBehavior = false;
            this.Regions_View.View = System.Windows.Forms.View.Details;
            this.Regions_View.DoubleClick += new System.EventHandler(this.Regions_View_DoubleClick);
            this.Regions_View.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.Regions_View_ItemSelectionChanged);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "№";
            this.columnHeader4.Width = 50;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Метка";
            this.columnHeader5.Width = 300;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Позиция";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader6.Width = 100;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Длинна";
            this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader7.Width = 100;
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Regions_Autonavigate,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.Regions_Filter,
            this.Regions_ShowUnLabelled});
            this.toolStrip1.Location = new System.Drawing.Point(3, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(639, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // Regions_Autonavigate
            // 
            this.Regions_Autonavigate.CheckOnClick = true;
            this.Regions_Autonavigate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Regions_Autonavigate.Image = ((System.Drawing.Image)(resources.GetObject("Regions_Autonavigate.Image")));
            this.Regions_Autonavigate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Regions_Autonavigate.Name = "Regions_Autonavigate";
            this.Regions_Autonavigate.Size = new System.Drawing.Size(23, 22);
            this.Regions_Autonavigate.Text = "Автонавигация";
            this.Regions_Autonavigate.ToolTipText = "Автоматически переходить на регион при выделении его в списке";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(51, 22);
            this.toolStripLabel1.Text = "Фильтр:";
            // 
            // Regions_Filter
            // 
            this.Regions_Filter.Name = "Regions_Filter";
            this.Regions_Filter.Size = new System.Drawing.Size(100, 25);
            this.Regions_Filter.TextChanged += new System.EventHandler(this.Regions_Filter_TextChanged);
            // 
            // Regions_ShowUnLabelled
            // 
            this.Regions_ShowUnLabelled.CheckOnClick = true;
            this.Regions_ShowUnLabelled.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Regions_ShowUnLabelled.Image = ((System.Drawing.Image)(resources.GetObject("Regions_ShowUnLabelled.Image")));
            this.Regions_ShowUnLabelled.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Regions_ShowUnLabelled.Name = "Regions_ShowUnLabelled";
            this.Regions_ShowUnLabelled.Size = new System.Drawing.Size(23, 22);
            this.Regions_ShowUnLabelled.Text = "Показывать маркеры с пустой меткой";
            this.Regions_ShowUnLabelled.ToolTipText = "Показывать регионы с пустой меткой";
            this.Regions_ShowUnLabelled.Click += new System.EventHandler(this.Regions_ShowUnLabelled_Click);
            // 
            // columnHeader24
            // 
            this.columnHeader24.Text = "Alpha";
            // 
            // Navigator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.DoubleBuffered = true;
            this.Name = "Navigator";
            this.Size = new System.Drawing.Size(653, 330);
            this.tabControl1.ResumeLayout(false);
            this.Video_Page.ResumeLayout(false);
            this.Video_Page.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.Audio_Page.ResumeLayout(false);
            this.Audio_Page.PerformLayout();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.Markers_Page.ResumeLayout(false);
            this.Markers_Page.PerformLayout();
            this.toolStrip4.ResumeLayout(false);
            this.toolStrip4.PerformLayout();
            this.Regions_Page.ResumeLayout(false);
            this.Regions_Page.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Video_Page;
        private System.Windows.Forms.TabPage Markers_Page;
        private System.Windows.Forms.TabPage Regions_Page;
        private System.Windows.Forms.ToolStrip toolStrip4;
        private System.Windows.Forms.ToolStripButton Markers_Autonavigate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripTextBox Markers_Filter;
        private System.Windows.Forms.ToolStripButton Markers_ShowUnLabelled;
        private System.Windows.Forms.ListView Markers_View;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton Regions_Autonavigate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton Regions_ShowUnLabelled;
        private System.Windows.Forms.ListView Regions_View;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        public System.Windows.Forms.ToolStripTextBox Regions_Filter;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ListView VideoEvents_View;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        public System.Windows.Forms.ToolStripTextBox VideoEvents_Filter;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.TabPage Audio_Page;
        private System.Windows.Forms.ListView AudioEvents_View;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.ColumnHeader columnHeader17;
        private System.Windows.Forms.ColumnHeader columnHeader18;
        private System.Windows.Forms.ColumnHeader columnHeader19;
        private System.Windows.Forms.ColumnHeader columnHeader20;
        private System.Windows.Forms.ColumnHeader columnHeader21;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        public System.Windows.Forms.ToolStripTextBox toolStripTextBox2;
        private System.Windows.Forms.ColumnHeader columnHeader22;
        private System.Windows.Forms.ColumnHeader PARColumn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripLabel toolStripLabel5;
        private System.Windows.Forms.ToolStripTextBox VideoEvents_Filter_FX;
        private System.Windows.Forms.ColumnHeader columnHeader23;
        private System.Windows.Forms.ColumnHeader columnHeader24;
    }
}
