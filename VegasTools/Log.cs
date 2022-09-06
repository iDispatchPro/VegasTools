using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace VegasTools
{
    public enum TLogEventType
    {
        leFeature = 0,
        leRender = 1,
        leExec = 2,
        leInfo = 3,
        leWarning = 4,
        leError = 5,
        leCarbon = 6,
        leCCE = 7,
        leAVI = 8,
        lex264 = 9
    }

    public partial class TLog : Form
    {
        private ScriptPortal.Vegas.Vegas FVegas;

        public bool ShutDownAfterDone
        {
            get
            {
                return cb_ShutDown.Checked;
            }

            set
            {
                cb_ShutDown.Checked = ShutDownAfterDone;
            }
        }

        public void Clear(ScriptPortal.Vegas.Vegas AVegas)
        {
            FVegas = AVegas;
            FHasErrors = false;
            SetCurProcess(null, "", "");
            Total_ProgressBar.Value = 0;
            TreeView.Nodes.Clear();
            btn_Stop.Show();
            btn_ok.Hide();
            btn_Hide.Show();
        }

        public void OpenFolder(String AName, TLogEventType AIcon)
        {
            if (FCurTask == null)
                FCurTask = TreeView.Nodes.Add("");
            else
                FCurTask = FCurTask.Nodes.Add("");

            FCurTask.Tag = DateTime.Now;
            FCurTask.ImageIndex = (int)AIcon;
            FCurTask.SelectedImageIndex = FCurTask.ImageIndex;
            FCurTask.Text = "[" + FCurTask.Tag.ToString() + "] " + AName;
            FCurTask.EnsureVisible();

            Application.DoEvents();
        }

        public void Done()
        {
            ShowLog();

            btn_Hide.Hide();
            Total_ProgressBar.Hide();
            btn_Stop.Hide();
            btn_ok.Show();
        }

        public void SetTotal(int ACount)
        {
            Total_ProgressBar.Maximum = (ACount * 100);
        }

        public void Message(String AName, TLogEventType AIcon)
        {
            TreeNode Node;

            if (FCurTask == null)
                Node = TreeView.Nodes.Add(AName);
            else
            {
                Node = FCurTask.Nodes.Add(AName);
                FCurTask.ExpandAll();
            }

            Node.ImageIndex = (int)AIcon;
            Node.SelectedImageIndex = Node.ImageIndex;
            TreeView.SelectedNode = Node;

            Application.DoEvents();
        }

        public byte Progress
        {
            get
            {
                return (byte)Total_ProgressBar.Value;
            }

            set
            {
                if (Total_ProgressBar.Value != value)
                {
                    Total_ProgressBar.Value = value;

                    String S = (int)(((double)value / (double)Total_ProgressBar.Maximum) * 100) + "%";

                    if (value == 100)
                        Text = "Vagas tools";
                    else
                        Text = "Vegas tools - " + S;

                    Tray.BalloonTipText = S;
                }

                Application.DoEvents();
            }
        }

        private String AddTimeComponent(int AValue, String ASuffix)
        {
            if (AValue > 0)
                return " " + AValue.ToString() + " " + ASuffix;
            else
                return "";
        }

        public void CloseFolder()
        {
            TimeSpan TaskTime = DateTime.Now.Subtract((DateTime)(FCurTask.Tag));

            if ((TaskTime.Seconds > 0) && (FCurTask.Nodes.Count > 0))
                Message("Время выполнения: " + AddTimeComponent(TaskTime.Days, "дн.") + AddTimeComponent(TaskTime.Hours, "час.") + AddTimeComponent(TaskTime.Minutes, "мин.") + AddTimeComponent(TaskTime.Seconds, "сек."), TLogEventType.leInfo);

            FCurTask.Collapse();
            FCurTask = FCurTask.Parent;
            Application.DoEvents();
        }
        
        public void SetCurProcess(Process AProcess, String AName, String AParams)
        {
            if (AProcess == null)
            {
                if (FCurProcess != null)
                {
                    if (!FCurProcess.HasExited)
                        FCurProcess.Kill();

                    //CloseFolder();
                }
            }
            else
            {
                //OpenFolder("Запущен процесс [" +  Path.GetFileNameWithoutExtension(AName) + "]", TLogEventType.leExec);
                //Message("Параметры [" + AParams + "]");
            }

            FCurProcess = AProcess;
        }

        private Process FCurProcess;
        private TreeNode FCurTask;
        private bool FHasErrors;

        public bool HasErrors()
        {
            return FHasErrors;
        }

        public TLog()
        {
            InitializeComponent();
        }

        public void Error(String AName)
        {
            FHasErrors = true;
            Message(AName, TLogEventType.leError);
        }

        private void Log_Load(object sender, EventArgs e)
        {
            Clear(FVegas);
            cb_ShutDown.Checked = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            SetCurProcess(null, "", "");
            Error("Рендеринг прерван пользователем.");
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            Hide();
            Clear(null);
        }

        public void HideLog()
        {
            Hide();
            TSysHelper S = new TSysHelper(null);
            S.HideWindow(FVegas.MainWindow.Handle.ToInt32());
            S.HideWindow(S.TryFindWindow("#32770", "FrameServer - (Status)"));
            Tray.Visible = true;
            Tray.BalloonTipText = "Кликните для отображения лога.";
            Tray.ShowBalloonTip(5000);
        }

        public void ShowLog()
        {
            TSysHelper S = new TSysHelper(null);
            S.ShowWindow(FVegas.MainWindow.Handle.ToInt32());
            Show();
            Tray.Visible = false;

            btn_Stop.Select();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            HideLog();
        }

        private void Tray_Click(object sender, EventArgs e)
        {
            ShowLog();
        }

        private void Tray_MouseMove(object sender, MouseEventArgs e)
        {
            //Tray.ShowBalloonTip(5000);
        }

        private void TLog_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
                btn_Stop.Select();
        }
    }
}