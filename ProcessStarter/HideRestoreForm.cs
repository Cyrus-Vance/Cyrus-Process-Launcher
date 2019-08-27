using ProcessStarter.GlobalSets;
using ProcessStarter.Module;
using ServerStarter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace ProcessStarter
{
    public partial class HideRestoreForm : Form
    {
        public MainForm _MainForm;

        [DllImport("user32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);
        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        public HideRestoreForm(MainForm form) : this()
        {
            _MainForm = form;
        }

        public HideRestoreForm()
        {
            InitializeComponent();
        }

        private void HideRestoreForm_Load(object sender, EventArgs e)
        {
            ProcessView.BeginUpdate();
            ProcessView.Columns.Add("进程ID", 80, HorizontalAlignment.Center);
            ProcessView.Columns.Add("路径", 160, HorizontalAlignment.Left);
            ProcessView.Columns.Add("命令行", 120, HorizontalAlignment.Left);
            ProcessView.Columns.Add("状态", 60, HorizontalAlignment.Left);

            LoadAllProgramToList();

            ProcessView.EndUpdate();
            RefreshListTimer.Enabled = true;
        }

        private void LoadAllProgramToList()
        {
            //清空进程imageList和ProcessView
            processImageList.Images.Clear();
            ProcessView.Items.Clear();

            foreach (int i in GlobalVariable.Started_PID)
            {
                ListViewItem lvi = new ListViewItem();

                lvi.Text = Convert.ToString(i);

                //获取对应PID的启动目录
                Process pro;
                string proPathName, proArgument;
                try
                {
                    pro = Process.GetProcessById(i);//获得对应PID的进程  
                    proPathName = pro.MainModule.FileName.ToString();
                    proArgument = ProcessExtensions.GetCommandLineArgs(pro);
                }
                catch
                {
                    continue;
                }

                string[] args = CommandLineExtensions.ConvertCommandLineToArgs(proArgument);
                string sumArg = "";
                for (int a = 1; a < args.Length; a++)
                {
                    sumArg += args[a] + " ";
                }

                lvi.SubItems.Add(proPathName);
                lvi.SubItems.Add(sumArg);

                if (GlobalVariable.Hid_PID.Contains(i))
                {
                    lvi.SubItems.Add("隐藏");
                }
                else
                {
                    lvi.SubItems.Add("正常");
                }

                processImageList.Images.Add(Convert.ToString(i), IconHelper.GetFileIcon(proPathName, true));
                lvi.ImageIndex = processImageList.Images.Count - 1;     //通过与imageList绑定，显示imageList中第i项图标

                ProcessView.Items.Add(lvi);
            }

            //更新新的Started_PID表
            GlobalVariable.Started_PID.Clear();
            foreach(ListViewItem i in ProcessView.Items)
            {
                GlobalVariable.Started_PID.Add(Convert.ToInt32(i.Text));
            }

        }

        private void CloseThisWindow()
        {
            RefreshListTimer.Enabled = false;
            Invoke((EventHandler)delegate
            {
                _MainForm.Visible = true;
                Close();
            });
        }

        private void ShowProcessWindow(int PID)
        {
            IntPtr intptr;
            intptr = User32API.GetWindowHandle(PID);
            ShowWindow(intptr, GlobalVariable.SW_SHOW);
            if(GlobalVariable.Hid_PID.Contains(PID)) GlobalVariable.Hid_PID.Remove(PID);
        }

        private void HideProcessWindow(int PID)
        {
            IntPtr intptr;
            intptr = User32API.GetWindowHandle(PID);
            ShowWindow(intptr, GlobalVariable.SW_HIDE);
            if(!GlobalVariable.Hid_PID.Contains(PID)) GlobalVariable.Hid_PID.Add(PID);
        }


        private void HideRestoreForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseThisWindow();
        }

        private void ManualPIDCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ManualPIDCheckBox.Checked)
            {
                ManualLabel.Enabled = true;
                ManualPIDTextBox.Enabled = true;
                SelectProcessButton.Enabled = true;
            }
            else
            {
                ManualLabel.Enabled = false;
                ManualPIDTextBox.Enabled = false;
                SelectProcessButton.Enabled = false;
            }
        }

        private void RestoreProcessButton_Click(object sender, EventArgs e)
        {
            if (!GlobalVariable.Authorized) return; //授权验证
            if (ProcessView.SelectedItems.Count > 0 || ManualPIDCheckBox.Checked)
            {
                if (!ManualPIDCheckBox.Checked)
                {
                    foreach (ListViewItem item in ProcessView.SelectedItems)
                    {
                        if (item.SubItems[3].Text.Equals("隐藏"))
                        {
                            ShowProcessWindow(Convert.ToInt32(item.Text));
                            item.SubItems[3].Text = "正常";
                        }
                    }
                }
                else
                {
                    //进入手动操作模式
                    if (!ManualPIDTextBox.Text.Equals(""))
                    {
                        if (ManualPIDTextBox.Text.Contains(','))
                        {
                            string[] listed_processes = ManualPIDTextBox.Text.Split(',');
                            foreach (string str in listed_processes)
                            {
                                //如果是已记录的隐藏程序
                                if (GlobalVariable.Started_PID.Contains(Convert.ToInt32(str)))
                                {
                                    //在ListView中对相应的项设置“显示”标签
                                    foreach (ListViewItem item in ProcessView.Items)
                                    {
                                        if (item.Text.Equals(ManualPIDTextBox.Text) && item.SubItems[3].Text.Equals("隐藏"))
                                        {
                                            ShowProcessWindow(Convert.ToInt32(str));
                                            item.SubItems[3].Text = "正常";
                                        }
                                    }
                                }
                                else
                                {
                                    //未记录则强制发送指令
                                    ShowProcessWindow(Convert.ToInt32(str));
                                }
                            }
                        }
                        else
                        {
                            int userInputNumber = Convert.ToInt32(ManualPIDTextBox.Text);
                            //如果是已记录的隐藏程序
                            if (GlobalVariable.Started_PID.Contains(userInputNumber))
                            {
                                //在ListView中对相应的项设置“显示”标签
                                foreach (ListViewItem item in ProcessView.Items)
                                {
                                    if (item.Text.Equals(ManualPIDTextBox.Text) && item.SubItems[3].Text.Equals("隐藏"))
                                    {
                                        ShowProcessWindow(userInputNumber);
                                        item.SubItems[3].Text = "正常";
                                    }
                                }
                            }
                            else
                            {
                                //未记录则强制发送指令
                                ShowProcessWindow(userInputNumber);
                            }
                        }                        
                    }
                    else
                    {
                        MessageBox.Show("请输入进程ID！", "未输入PID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                ProcessView.BeginUpdate();
                LoadAllProgramToList();
                ProcessView.EndUpdate();
            }
            else
            {
                MessageBox.Show("请选择需要操作的进程！", "未选中进程", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void HideProcessButton_Click(object sender, EventArgs e)
        {
            if (!GlobalVariable.Authorized) return; //授权验证
            if (ProcessView.SelectedItems.Count > 0 || ManualPIDCheckBox.Checked)
            {
                if (!ManualPIDCheckBox.Checked)
                {
                    foreach (ListViewItem item in ProcessView.SelectedItems)
                    {
                        if (item.SubItems[3].Text.Equals("正常"))
                        {
                            HideProcessWindow(Convert.ToInt32(item.Text));
                            item.SubItems[3].Text = "隐藏";
                        }
                    }
                }
                else
                {
                    //进入手动操作模式
                    if (!ManualPIDTextBox.Text.Equals(""))
                    {
                        if (ManualPIDTextBox.Text.Contains(','))
                        {
                            string[] listed_processes = ManualPIDTextBox.Text.Split(',');
                            foreach(string str in listed_processes)
                            {
                                //如果是已记录的启动程序
                                if (GlobalVariable.Started_PID.Contains(Convert.ToInt32(str)))
                                {
                                    //在ListView中对相应的项设置“隐藏”标签
                                    foreach (ListViewItem item in ProcessView.Items)
                                    {
                                        if (item.Text.Equals(ManualPIDTextBox.Text) && item.SubItems[3].Text.Equals("正常"))
                                        {
                                            HideProcessWindow(Convert.ToInt32(str));
                                            item.SubItems[3].Text = "隐藏";
                                        }
                                    }
                                }
                                else
                                {
                                    //未记录则强制发送指令
                                    HideProcessWindow(Convert.ToInt32(str));
                                }
                            }
                        }
                        else
                        {
                            int userInputNumber = Convert.ToInt32(ManualPIDTextBox.Text);
                            //如果是已记录的启动程序
                            if (GlobalVariable.Started_PID.Contains(userInputNumber))
                            {
                                //在ListView中对相应的项设置“隐藏”标签
                                foreach (ListViewItem item in ProcessView.Items)
                                {
                                    if (item.Text.Equals(ManualPIDTextBox.Text) && item.SubItems[3].Text.Equals("正常"))
                                    {
                                        HideProcessWindow(userInputNumber);
                                        item.SubItems[3].Text = "隐藏";
                                    }
                                }
                            }
                            else
                            {
                                //未记录则强制发送指令
                                HideProcessWindow(userInputNumber);
                            }
                        }                  
                    }
                    else
                    {
                        MessageBox.Show("请输入进程ID！", "未输入PID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                ProcessView.BeginUpdate();
                LoadAllProgramToList();
                ProcessView.EndUpdate();
            }
            else
            {
                MessageBox.Show("请选择需要操作的进程！", "未选中进程", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ManualPIDTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')//如果不是输入数字、退格、逗号就不让输入
            {
                e.Handled = true;
            }
        }

        private void RefreshProcessListButton_Click(object sender, EventArgs e)
        {
            ProcessView.BeginUpdate();
            LoadAllProgramToList();
            ProcessView.EndUpdate();
        }

        private void RefreshListTimer_Tick(object sender, EventArgs e)
        {
            LoadAllProgramToList();
        }

        private void SelectProcessButton_Click(object sender, EventArgs e)
        {
            if (!GlobalVariable.Authorized) return; //授权验证
            ProcessSelectWindow processSlctWindow = new ProcessSelectWindow(this);
            processSlctWindow.ShowDialog();
        }
    }
}
