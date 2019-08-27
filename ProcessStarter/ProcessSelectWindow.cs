using ProcessStarter.Module;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ProcessStarter
{
    public partial class ProcessSelectWindow : Form
    {
        public HideRestoreForm _HideRestoreForm;

        public ProcessSelectWindow(HideRestoreForm form) : this()
        {
            _HideRestoreForm = form;
        }

        public ProcessSelectWindow()
        {
            InitializeComponent();
        }

        private void ProcessSelectWindow_Load(object sender, EventArgs e)
        {
            ProcessView.BeginUpdate();
            ProcessView.Columns.Add("进程名", 100, HorizontalAlignment.Left);
            ProcessView.Columns.Add("进程ID", 60, HorizontalAlignment.Left);
            ProcessView.Columns.Add("路径", 260, HorizontalAlignment.Left);
            ProcessView.Columns.Add("命令行", 200, HorizontalAlignment.Left);
            ProcessView.EndUpdate();

            ParseProcessList ownerInfo = new ParseProcessList();
            ownerInfo.processImageList = processImageList;
            ownerInfo.processView = ProcessView;
            ownerInfo.statusLabel = statusLabel;
            ownerInfo.loadProgressBar = loadProgressBar;
            ownerInfo.processSelectWindow = this;

            Thread processParser = new Thread(ownerInfo.Run);

            processParser.Start();

        }

        private void ProcessSelectWindow_Resize(object sender, EventArgs e)
        {
            ProcessView.Width = Width - 34;
            ProcessView.Height = Height - 112;
            OKButton.Location = new Point(Width / 2 - OKButton.Width / 2, Height - 98);

        }   

        private void ProcessView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ProcessView.ListViewItemSorter = new ListViewColumnSorter();
            ProcessView.ColumnClick += new ColumnClickEventHandler(ListViewHelper.ListView_ColumnClick);
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            int SelectedCount = ProcessView.SelectedItems.Count;
            if (SelectedCount != 0)
            {
                if (SelectedCount == 1)
                {
                    _HideRestoreForm.ManualPIDTextBox.Text = ProcessView.SelectedItems[0].SubItems[1].Text;
                }
                else if (SelectedCount > 1)
                {
                    string pid_list = "";
                    foreach (ListViewItem item in ProcessView.SelectedItems)
                    {
                        if (pid_list.Equals(""))
                        {
                            pid_list = item.SubItems[1].Text;
                        }
                        else
                        {
                            pid_list += @"," + item.SubItems[1].Text;
                        }
                    }
                    _HideRestoreForm.ManualPIDTextBox.Text = pid_list;
                }
                Close();
            }
            else
            {
                MessageBox.Show("请选择您需要选择的进程！","未选择进程",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void ProcessView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (ProcessView.SelectedItems.Count != 0)
            {
                _HideRestoreForm.ManualPIDTextBox.Text = ProcessView.SelectedItems[0].SubItems[1].Text;
                Close();
            }
        }
    }

    public class ParseProcessList
    {
        public ProcessSelectWindow processSelectWindow { get; set; }

        public ImageList processImageList { get; set; }

        public ListView processView { get; set; }

        public ToolStripStatusLabel statusLabel { get; set; }

        public ToolStripProgressBar loadProgressBar { get; set; }


        public void Run()
        {
            try
            {
                processSelectWindow.Invoke((EventHandler)delegate
                {
                    //清空进程imageList和ProcessView
                    processImageList.Images.Clear();
                    processView.Items.Clear();
                    loadProgressBar.Value = 0;

                    statusLabel.Text = "正在加载进程列表……";
                });

                //获取所有进程
                Process[] pro = Process.GetProcesses();
                int max_count = pro.Count();
                int progress = 0;

                processSelectWindow.Invoke((EventHandler)delegate
                {
                    loadProgressBar.Maximum = max_count;
                });
                foreach (Process item in pro)
                {
                    progress += 1;
                    ListViewItem lvi = new ListViewItem
                    {
                        Text = item.ProcessName
                    };
                    //获取对应PID的启动目录
                    string proPathName, proArgument;
                    proPathName = GetProcessFilename(item);
                    proArgument = ProcessExtensions.GetCommandLineArgs(item);
                    string[] args = CommandLineExtensions.ConvertCommandLineToArgs(proArgument);
                    string sumArg = "";
                    for (int a = 1; a < args.Length; a++)
                    {
                        sumArg += args[a] + " ";
                    }
                    lvi.SubItems.Add(Convert.ToString(item.Id));
                    lvi.SubItems.Add(proPathName);
                    lvi.SubItems.Add(sumArg);

                    processSelectWindow.Invoke((EventHandler)delegate
                    {
                        processImageList.Images.Add(Convert.ToString(item.Id), IconHelper.GetFileIcon(proPathName, true));
                        lvi.ImageIndex = processImageList.Images.Count - 1;     //通过与imageList绑定，显示imageList中第i项图标

                        processView.Items.Add(lvi);
                        statusLabel.Text = $@"正在加载进程列表……({progress}/{max_count})";
                        loadProgressBar.Value = progress;
                    });
                }
                processSelectWindow.Invoke((EventHandler)delegate
                {
                    statusLabel.Text = $@"进程列表加载完毕,共加载了{progress}个进程!";
                });
            }
            catch
            {

            }
            
        }
        #region "进程路径获取"
        [Flags]
        private enum ProcessAccessFlags : uint
        {
            QueryLimitedInformation = 0x00001000
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool QueryFullProcessImageName(
              [In] IntPtr hProcess,
              [In] int dwFlags,
              [Out] StringBuilder lpExeName,
              ref int lpdwSize);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr OpenProcess(
         ProcessAccessFlags processAccess,
         bool bInheritHandle,
         int processId);

        String GetProcessFilename(Process p)
        {
            int capacity = 2000;
            StringBuilder builder = new StringBuilder(capacity);
            IntPtr ptr = OpenProcess(ProcessAccessFlags.QueryLimitedInformation, false, p.Id);
            if (!QueryFullProcessImageName(ptr, 0, builder, ref capacity))
            {
                return String.Empty;
            }

            return builder.ToString();
        }
        #endregion
    }

}
