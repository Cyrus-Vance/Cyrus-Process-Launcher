using Microsoft.Win32;
using ProcessStarter.GlobalSets;
using ServerStarter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProcessStarter
{
    public partial class SystemSettingsWindow : Form
    {
        public MainForm _MainForm;
        public SystemSettingsWindow()
        {
            InitializeComponent();
        }
        public SystemSettingsWindow(MainForm form) : this()
        {
            _MainForm = form;
        }

        private void SystemSettingsWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseThisWindow();
        }

        private void applyDefaultSettings()
        {
            //载入默认值到窗口
            AutorunBox.Checked = GlobalVariable.AutorunWhenBoot;
            AutoUpdaterBox.Checked = GlobalVariable.EnableAutoUpdater;
            AutoLaunchProgramBox.Checked = GlobalVariable.EnableDirectLaunch;
            MinToNotifyBox.Checked = GlobalVariable.EnableMinToNotify;

            //隐藏窗口分类
            HideWindowBox.Checked = GlobalVariable.EnableHideWindow;
            HideWindowTextBox.Text = Convert.ToString(GlobalVariable.HideCountdown);
            HideWindowLabel.Enabled = GlobalVariable.EnableHideWindow;
            HideWindowTextBox.Enabled = GlobalVariable.EnableHideWindow;
            //退出软件分类
            ExitBox.Checked = GlobalVariable.EnableAutoExit;
            ExitTextBox.Text = Convert.ToString(GlobalVariable.Default_ShutdownCountdown); ;
            ExitLabel.Enabled = GlobalVariable.EnableAutoExit;
            ExitTextBox.Enabled = GlobalVariable.EnableAutoExit;
        }

        private void CloseThisWindow()
        {
            Invoke((EventHandler)delegate
            {
                _MainForm.Visible = true;
                this.Close();
            });
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveButton.Enabled = false;
            if (!((HideWindowBox.Checked && HideWindowTextBox.Text.Equals("")) || (ExitBox.Checked && ExitTextBox.Text.Equals(""))))
            {
                SaveButton.Enabled = false;
                IniFile.IniWriteValue(GlobalString.cfgSystem, GlobalString.cfgFirstConfig, Convert.ToString(true), GlobalVariable.ConfigPath);
                IniFile.IniWriteValue(GlobalString.cfgSystem, GlobalString.cfgAutorun, Convert.ToString(AutorunBox.Checked), GlobalVariable.ConfigPath);
                IniFile.IniWriteValue(GlobalString.cfgSystem, GlobalString.cfgAutoUpdater, Convert.ToString(AutoUpdaterBox.Checked), GlobalVariable.ConfigPath);
                IniFile.IniWriteValue(GlobalString.cfgSystem, GlobalString.cfgDirectLaunch, Convert.ToString(AutoLaunchProgramBox.Checked), GlobalVariable.ConfigPath);
                IniFile.IniWriteValue(GlobalString.cfgSystem, GlobalString.cfgMinToNotify, Convert.ToString(MinToNotifyBox.Checked), GlobalVariable.ConfigPath);
                IniFile.IniWriteValue(GlobalString.cfgSystem, GlobalString.cfgAutoExitEnabled, Convert.ToString(ExitBox.Checked), GlobalVariable.ConfigPath);
                IniFile.IniWriteValue(GlobalString.cfgSystem, GlobalString.cfgAutoExitTime, ExitTextBox.Text, GlobalVariable.ConfigPath);
                IniFile.IniWriteValue(GlobalString.cfgSystem, GlobalString.cfgHideWindowEnabled, Convert.ToString(HideWindowBox.Checked), GlobalVariable.ConfigPath);
                IniFile.IniWriteValue(GlobalString.cfgSystem, GlobalString.cfgHideWindowTime, HideWindowTextBox.Text, GlobalVariable.ConfigPath);

                if (AutorunBox.Checked)
                {
                    RegistryKey RKey = Registry.LocalMachine.CreateSubKey(GlobalString.bootRegPath);
                    RKey.SetValue(GlobalString.bootKeyName, Application.ExecutablePath, RegistryValueKind.String);
                    _MainForm.Addlog("已向系统写入开机自启项！", Color.Brown);
                }
                else
                {
                    RegistryKey RKey = Registry.LocalMachine.CreateSubKey(GlobalString.bootRegPath);
                    RKey.DeleteValue(GlobalString.bootKeyName, false);
                    _MainForm.Addlog("已向系统删除开机自启项！", Color.Brown);
                }

                GlobalVariable.AutorunWhenBoot = AutoUpdaterBox.Checked;
                GlobalVariable.EnableAutoUpdater = AutoUpdaterBox.Checked;
                GlobalVariable.EnableDirectLaunch = AutoLaunchProgramBox.Checked;
                GlobalVariable.EnableMinToNotify = MinToNotifyBox.Checked;
                GlobalVariable.EnableAutoExit = ExitBox.Checked;
                GlobalVariable.EnableHideWindow = HideWindowBox.Checked;
                GlobalVariable.Default_ShutdownCountdown = Convert.ToInt32(ExitTextBox.Text);
                GlobalVariable.HideCountdown = Convert.ToInt32(HideWindowTextBox.Text);

                _MainForm.Addlog("系统配置文件已经保存！", Color.Blue);

                CloseThisWindow();
            }
            else
            {
                MessageBox.Show("您尚有未填写的数字哦！");
                SaveButton.Enabled = true;
            }
        }

        private void HideWindowBox_CheckedChanged(object sender, EventArgs e)
        {
            if (HideWindowBox.Checked)
            {
                HideWindowLabel.Enabled = true;
                HideWindowTextBox.Enabled = true;
            }
            else
            {
                HideWindowLabel.Enabled = false;
                HideWindowTextBox.Enabled = false;
            }
        }

        private void ExitBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ExitBox.Checked)
            {
                ExitLabel.Enabled = true;
                ExitTextBox.Enabled = true;
            }
            else
            {
                ExitLabel.Enabled = false;
                ExitTextBox.Enabled = false;
            }
        }

        private void HideWindowLabel_Click(object sender, EventArgs e)
        {

        }

        private void HideWindowTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void SystemSettingsWindow_Load(object sender, EventArgs e)
        {
            if (File.Exists(GlobalVariable.ConfigPath))
            {
                try
                {
                    if (!bool.Parse(IniFile.IniReadValue(GlobalString.cfgSystem, GlobalString.cfgFirstConfig, GlobalVariable.ConfigPath)))
                    {
                        applyDefaultSettings();
                    }
                    else
                    {
                        try
                        {
                            AutorunBox.Checked = bool.Parse(IniFile.IniReadValue(GlobalString.cfgSystem, GlobalString.cfgAutorun, GlobalVariable.ConfigPath));
                            AutoUpdaterBox.Checked = bool.Parse(IniFile.IniReadValue(GlobalString.cfgSystem, GlobalString.cfgAutoUpdater, GlobalVariable.ConfigPath));
                            AutoLaunchProgramBox.Checked = bool.Parse(IniFile.IniReadValue(GlobalString.cfgSystem, GlobalString.cfgDirectLaunch, GlobalVariable.ConfigPath));
                            MinToNotifyBox.Checked = bool.Parse(IniFile.IniReadValue(GlobalString.cfgSystem, GlobalString.cfgMinToNotify, GlobalVariable.ConfigPath));
                            HideWindowBox.Checked = bool.Parse(IniFile.IniReadValue(GlobalString.cfgSystem, GlobalString.cfgHideWindowEnabled, GlobalVariable.ConfigPath));
                            HideWindowTextBox.Text = IniFile.IniReadValue(GlobalString.cfgSystem, GlobalString.cfgHideWindowTime, GlobalVariable.ConfigPath);
                            ExitBox.Checked = bool.Parse(IniFile.IniReadValue(GlobalString.cfgSystem, GlobalString.cfgAutoExitEnabled, GlobalVariable.ConfigPath));
                            ExitTextBox.Text = IniFile.IniReadValue(GlobalString.cfgSystem, GlobalString.cfgAutoExitTime, GlobalVariable.ConfigPath);
                            if (!HideWindowBox.Checked)
                            {
                                HideWindowLabel.Enabled = false;
                                HideWindowTextBox.Enabled = false;
                            }
                            if (!ExitBox.Checked)
                            {
                                ExitLabel.Enabled = false;
                                ExitTextBox.Enabled = false;
                            }
                        }
                        catch
                        {
                            MessageBox.Show("配置文件被破坏，将重新填入默认值！", "配置错误");
                            applyDefaultSettings();
                        }
                    }
                }
                catch
                { applyDefaultSettings(); }
            }
            else
            {
                applyDefaultSettings();
            }
        }
    }
}
