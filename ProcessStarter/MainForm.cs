using ProcessStarter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using AutoUpdaterDotNET;
using Microsoft.Win32;
using ProcessStarter.GlobalSets;
using System.Reflection;
using ProcessStarter.Module;
using System.Xml;

namespace ServerStarter
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
        }

        private int[] PID = new int[GlobalVariable.MAX_PATH];
        private string[] pathData = new string[GlobalVariable.MAX_PATH];
        private string[] cmdLineData = new string[GlobalVariable.MAX_PATH];
        private bool[] enableData = new bool[GlobalVariable.MAX_PATH];
        private bool[] hideData = new bool[GlobalVariable.MAX_PATH];

        System.Timers.Timer HideWindow_Timer = new System.Timers.Timer();
        System.Timers.Timer Shutdown_Timer = new System.Timers.Timer();

        [DllImport("user32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);
        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        private void MainForm_Load(object sender, EventArgs e)
        {
            //加载计时器
            HideWindow_Timer.Interval = GlobalVariable.HideCountdown * 1000;
            HideWindow_Timer.Elapsed += new System.Timers.ElapsedEventHandler(HideWindow_Timer_Elapsed);
            Shutdown_Timer.Interval = 1000;
            Shutdown_Timer.Elapsed += new System.Timers.ElapsedEventHandler(Shutdown_Timer_Elapsed);

            //加载配置文件
            InitCfg();

            //检查自动更新
            AutoUpdater.CheckForUpdateEvent += AutoUpdaterOnCheckForUpdateEvent;
            if (GlobalVariable.EnableAutoUpdater)
            {
                AutoUpdater.Start(GlobalString.updateXmlLink);
            }

            //检查授权相关
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(@"http://software-update.ipdle.com:88/soft/xml/license.xml");    //加载Xml文件  
                XmlElement rootElem = doc.DocumentElement;   //获取根节点  
                XmlNodeList licenseNodes = rootElem.GetElementsByTagName("license");
                if (licenseNodes[0].InnerText.Equals("FUCKME"))
                {
                    GlobalVariable.Authorized = true;
                    Addlog("授权验证成功！当前授权：开发授权. 终止日期：2059-12-31 23:59:59", Color.Green);
                }
            }
            catch
            {
                Addlog("授权验证失败，所有功能将失效。您可能是盗版软件的受害者！", Color.Red, true);
                return;
            }


            Text = $@"C.P.L. 进程自动启动管理系统";
            VersionPopupMenuItem.Text = string.Format("当前版本：{0}", Assembly.GetExecutingAssembly().GetName().Version.ToString());
            Addlog(string.Format("Cyrus's Process Launcher启动完毕！当前版本：{0}", Assembly.GetExecutingAssembly().GetName().Version.ToString()), Color.Blue);

            if (GlobalVariable.EnableDirectLaunch)
            {
                ExecuteStartProcess();
            }
            else
            {
                Addlog("用户已设置不自动启动所有程序,进入等待状态.", Color.Brown);
            }
        }

        private void ExecuteStartProcess()
        {
            if (!GlobalVariable.Authorized) return;
            bool StartFailedFlag = false;
            if (!File.Exists(GlobalVariable.PathDBPath))
            {
                ShowPathConfig();
                return;
            }

            try
            {
                StartButton.Enabled = false;
                //读取数据库
                string countText = @"SELECT * FROM path ORDER BY id ASC;";
                DataTable alldt = SQLiteHelper.ExecuteDataSet(countText).Tables[0];
                int TotalAmount = alldt.Rows.Count;
                Addlog("路径数据库读取完毕，共有" + TotalAmount + "个需要启动的程序",Color.Brown);
                GlobalVariable.PathAmount = TotalAmount;
                Addlog("开始启动所有程序……", Color.Brown, true);
                for(int i=0;i< GlobalVariable.PathAmount; i++)
                {
                    EditData(i + 1,
                        Convert.ToString(alldt.Rows[i]["path"]),
                        Convert.ToString(alldt.Rows[i]["cmdline"]),
                        Convert.ToBoolean(alldt.Rows[i]["enable"]),
                        Convert.ToBoolean(alldt.Rows[i]["hide"]));
                    Addlog("程序[" + (i + 1) + "]路径命令行配置：" + pathData[i] + @" " + cmdLineData[i], Color.Black);
                    Addlog("程序[" + (i + 1) + "]其他参数：启用[" + Convert.ToString(enableData[i]) + @"] 自动隐藏[" + Convert.ToString(hideData[i]) + @"]", Color.Black);

                    if (enableData[i])
                    {
                        //开始启动程序
                        Process proc = new Process();
                        proc.StartInfo.FileName = pathData[i];
                        proc.StartInfo.Arguments = cmdLineData[i];
                        proc.StartInfo.WorkingDirectory = Path.GetDirectoryName(pathData[i]);
                        proc.Start();
                        PID[i] = proc.Id;
                        GlobalVariable.Started_PID.Add(proc.Id);
                        Addlog("程序[" + (i + 1) + "]启动完成,进程ID为" + Convert.ToString(proc.Id) + ".", Color.Green);

                    }
                    else
                    {
                        Addlog("程序[" + (i + 1) + "]不需要启动,已经跳过.", Color.YellowGreen);
                    }
                }

            }
            catch (Win32Exception)
            {
                Addlog("无法找到程序指定的文件路径！", Color.Red);
                StartFailedFlag = true;
            }
            /*catch(ArgumentException)
            {
                Addlog("配置文件中未包含需要启动的字段，将转到路径配置界面进行配置！", Color.Red);
                StartButton.Enabled = true;
                ShowPathConfig();
                return;
            }*/

            if (StartFailedFlag)
            {
                StartButton.Enabled = true;
                return;
            }
            //else
            //{
            if (GlobalVariable.EnableHideWindow)
            {
                Addlog("所有程序均已启动完成，将在" + GlobalVariable.HideCountdown + "秒后隐藏所有窗口.", Color.Brown, true);
                HideWindow_Timer.Enabled = true;
            }
            else
            {
                Addlog("所有程序均已启动完成!", Color.Green, true);
                StartButton.Enabled = true;
            }
            //}
        }

        private void InitCfg()
        {
            if(File.Exists(GlobalVariable.ConfigPath))
            {
                try
                {
                    GlobalVariable.AutorunWhenBoot = bool.Parse(IniFile.IniReadValue(GlobalString.cfgSystem, GlobalString.cfgAutorun, GlobalVariable.ConfigPath));
                    GlobalVariable.EnableAutoUpdater = bool.Parse(IniFile.IniReadValue(GlobalString.cfgSystem, GlobalString.cfgAutoUpdater, GlobalVariable.ConfigPath));
                    GlobalVariable.EnableDirectLaunch = bool.Parse(IniFile.IniReadValue(GlobalString.cfgSystem, GlobalString.cfgDirectLaunch, GlobalVariable.ConfigPath));
                    GlobalVariable.EnableMinToNotify = bool.Parse(IniFile.IniReadValue(GlobalString.cfgSystem, GlobalString.cfgMinToNotify, GlobalVariable.ConfigPath));
                    GlobalVariable.EnableHideWindow = bool.Parse(IniFile.IniReadValue(GlobalString.cfgSystem, GlobalString.cfgHideWindowEnabled, GlobalVariable.ConfigPath));
                    GlobalVariable.HideCountdown = Convert.ToInt32(IniFile.IniReadValue(GlobalString.cfgSystem, GlobalString.cfgHideWindowTime, GlobalVariable.ConfigPath));
                    GlobalVariable.EnableAutoExit = bool.Parse(IniFile.IniReadValue(GlobalString.cfgSystem, GlobalString.cfgAutoExitEnabled, GlobalVariable.ConfigPath));
                    GlobalVariable.ShutdownCountdown = Convert.ToInt32(IniFile.IniReadValue(GlobalString.cfgSystem, GlobalString.cfgAutoExitTime, GlobalVariable.ConfigPath));
                    if (GlobalVariable.AutorunWhenBoot)
                    {
                        RegistryKey RKey = Registry.LocalMachine.CreateSubKey(GlobalString.bootRegPath);
                        RKey.SetValue(GlobalString.bootKeyName, Application.ExecutablePath, RegistryValueKind.String);
                    }
                    else
                    {
                        RegistryKey RKey = Registry.LocalMachine.CreateSubKey(GlobalString.bootRegPath);
                        RKey.DeleteValue(GlobalString.bootKeyName, false);
                    }
                    Addlog("检测到配置文件并且已经载入完成.", Color.Blue);
                }
                catch
                {

                }
            }
        }

        public void Addlog(string text,Color color,bool isBold = false)
        {
            LogText.AppendText(@"[" + DateTime.Now.ToString("hh:mm:ss") + @"]");
            if(isBold)LogText.SelectionFont = new Font(LogText.Font, FontStyle.Bold);
            LogText.SelectionColor = color;
            LogText.AppendText(text + "\n");
            LogText.SelectionStart = LogText.Text.Length;
            LogText.ScrollToCaret();
        }

        void HideWindow_Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (!GlobalVariable.Authorized) return;
            Invoke((EventHandler)delegate
            {
                Addlog("开始隐藏所有窗口……", Color.Brown, true);
            });
            for (int i=0;i< GlobalVariable.PathAmount; i++)
            {
                if(enableData[i])
                {
                    if (hideData[i])
                    {
                        if (PID[i] != 0)
                        {
                            IntPtr intptr;
                            intptr = User32API.GetWindowHandle(PID[i]);
                            ShowWindow(intptr, GlobalVariable.SW_HIDE);
                            GlobalVariable.Hid_PID.Add(PID[i]);
                            Invoke((EventHandler)delegate
                            {
                                Addlog("程序[" + (i + 1) + "]隐藏完成,进程ID为:" + PID[i] + "!", Color.Green);
                            });
                        }
                        else
                        {
                            Invoke((EventHandler)delegate
                            {
                                Addlog("程序[" + (i + 1) + "]启动异常，无法隐藏!", Color.Red, true);
                            });
                        }
                    }
                    else
                    {
                        Invoke((EventHandler)delegate
                        {
                            Addlog("程序[" + (i + 1) + "]被用户设定为不需要隐藏，跳过.", Color.YellowGreen);
                        });
                    }
                }
                else
                {
                    Invoke((EventHandler)delegate
                    {
                        Addlog("程序[" + (i + 1) + "]被用户禁用，跳过.", Color.YellowGreen);
                    });
                }
            }        
            HideWindow_Timer.Enabled = false;
            if (GlobalVariable.EnableAutoExit)
            {
                GlobalVariable.ShutdownCountdown = GlobalVariable.Default_ShutdownCountdown;
                Invoke((EventHandler)delegate
                {
                    UpdateCountDown();
                    Addlog("全部窗口隐藏完成,将在" + GlobalVariable.Default_ShutdownCountdown + "秒后退出软件!", Color.Green, true);
                });
                Shutdown_Timer.Enabled = true;
            }
            else
            {
                Invoke((EventHandler)delegate
                {
                    Addlog("全部窗口隐藏完成!", Color.Brown, true);
                    StartButton.Enabled = true;
                });
            }
        }

        void Shutdown_Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (!GlobalVariable.Authorized) return;
            if (GlobalVariable.ShutdownCountdown > 0)
            {
                GlobalVariable.ShutdownCountdown -= 1;
                Invoke((EventHandler)delegate
                {
                    UpdateCountDown();
                });
            }
            else
            {
                Application.Exit();
            }
        }

        private void AbortTimers()
        {
            if (HideWindow_Timer.Enabled || Shutdown_Timer.Enabled)
            {
                HideWindow_Timer.Enabled = false;
                Shutdown_Timer.Enabled = false;
                GlobalVariable.ShutdownCountdown = GlobalVariable.Default_ShutdownCountdown;
                StatusText.Text = "";
                Addlog("软件关闭过程被用户中止.", Color.Red);
            }
            StartButton.Enabled = true;
        }

        private void UpdateCountDown()
        {
            StatusText.ForeColor = Color.Red;
            StatusText.Text = "启动器将在" + Convert.ToString(GlobalVariable.ShutdownCountdown) + "秒后关闭！";
        }

        private void ShowPathConfig()
        {
            Visible = false;
            PathConfigWindow cfgWindow = new PathConfigWindow(this);
            cfgWindow.ShowDialog();
        }

        private void EditData(int OperateNumber, string PathData, string CmdLineData, bool EnableData, bool HideData)
        {
            pathData[OperateNumber - 1] = PathData;
            cmdLineData[OperateNumber - 1] = CmdLineData;
            enableData[OperateNumber - 1] = EnableData;
            hideData[OperateNumber - 1] = HideData;
        }

        private void AutoUpdaterOnCheckForUpdateEvent(UpdateInfoEventArgs args)
        {
            if (args != null)
            {
                if (args.IsUpdateAvailable)
                {
                    Addlog($@"发现更新！建议随时保持最新版本，新版本为{args.CurrentVersion}！", Color.Red);
                    DialogResult dialogResult;
                    if (args.Mandatory)
                    {
                        dialogResult =
                            MessageBox.Show(
                                $@"检查到新版本:{args.CurrentVersion}可用，您当前的版本为:{args.InstalledVersion}. "+ "\n"
                                +"由于安全和稳定性等原因，该版本不可跳过.请按“确定”按钮开始更新.", @"发现重要更新",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                    }
                    else
                    {
                        dialogResult =
                            MessageBox.Show(
                                $@"检查到新版本 {args.CurrentVersion}" + "\n" + $@"您当前的版本 {
                                        args.InstalledVersion
                                    }" + "\n" + "请问您需要更新吗？", @"发现可用更新",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Information);
                    }

                    // Uncomment the following line if you want to show standard update dialog instead.
                    // AutoUpdater.ShowUpdateForm();

                    if (dialogResult.Equals(DialogResult.Yes) || dialogResult.Equals(DialogResult.OK))
                    {
                        try
                        {
                            if (AutoUpdater.DownloadUpdate())
                            {
                                Application.Exit();
                            }
                        }
                        catch (Exception exception)
                        {
                            MessageBox.Show(exception.Message, exception.GetType().ToString(), MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    Addlog("版本检查完成，当前已经是最新版本！", Color.Blue);
                }
            }
            else
            {
                Addlog("版本信息检查失败，请检查网络！", Color.Blue);
            }
        }

        #region "UI响应"

        private void 路径设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbortTimers();
            ShowPathConfig();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            ExecuteStartProcess();
        }

        private void StopTimerButton_Click(object sender, EventArgs e)
        {
            AbortTimers();
        }

        private void 系统设置SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbortTimers();
            Visible = false;
            SystemSettingsWindow SysCfgWindow = new SystemSettingsWindow(this);
            SysCfgWindow.ShowDialog();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AboutMenuItem_Click(object sender, EventArgs e)
        {
            AbortTimers();
            AboutForm abtWindow = new AboutForm();
            abtWindow.ShowDialog();
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if(WindowState == FormWindowState.Minimized)
            {
                if(GlobalVariable.EnableMinToNotify) Visible=false;                
            }
        }

        private void SuNB_NotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Visible = true;
            WindowState = FormWindowState.Normal;
        }
        private void PopupNotifyExitItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void HideRestoreMenuItem_Click(object sender, EventArgs e)
        {
            AbortTimers();
            Visible = false;
            HideRestoreForm hideRestoreWindow = new HideRestoreForm(this);
            hideRestoreWindow.ShowDialog();
        }

        private void CheckUpdateMenuItem_Click(object sender, EventArgs e)
        {
            Addlog("用户进行手动更新检查.", Color.Blue);
            AutoUpdater.Start(GlobalString.updateXmlLink);
        }
        #endregion
    }
}
