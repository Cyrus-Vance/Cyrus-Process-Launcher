namespace ServerStarter
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.路径设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.系统设置SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ExitButton = new System.Windows.Forms.ToolStripMenuItem();
            this.工具TToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HideRestoreMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CheckUpdateMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.AboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StartButton = new System.Windows.Forms.Button();
            this.StopTimerButton = new System.Windows.Forms.Button();
            this.LogText = new System.Windows.Forms.RichTextBox();
            this.StatusText = new System.Windows.Forms.Label();
            this.SuNB_NotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.popupMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.VersionPopupMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.popupNotifyExitItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.popupMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.设置ToolStripMenuItem,
            this.工具TToolStripMenuItem,
            this.HelpMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(831, 28);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.路径设置ToolStripMenuItem,
            this.系统设置SToolStripMenuItem,
            this.toolStripSeparator1,
            this.ExitButton});
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(72, 24);
            this.设置ToolStripMenuItem.Text = "系统(&S)";
            // 
            // 路径设置ToolStripMenuItem
            // 
            this.路径设置ToolStripMenuItem.Name = "路径设置ToolStripMenuItem";
            this.路径设置ToolStripMenuItem.Size = new System.Drawing.Size(171, 26);
            this.路径设置ToolStripMenuItem.Text = "路径设置(&P)";
            this.路径设置ToolStripMenuItem.Click += new System.EventHandler(this.路径设置ToolStripMenuItem_Click);
            // 
            // 系统设置SToolStripMenuItem
            // 
            this.系统设置SToolStripMenuItem.Name = "系统设置SToolStripMenuItem";
            this.系统设置SToolStripMenuItem.Size = new System.Drawing.Size(171, 26);
            this.系统设置SToolStripMenuItem.Text = "系统设置(&S)";
            this.系统设置SToolStripMenuItem.Click += new System.EventHandler(this.系统设置SToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(168, 6);
            // 
            // ExitButton
            // 
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(171, 26);
            this.ExitButton.Text = "退出(&E)";
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // 工具TToolStripMenuItem
            // 
            this.工具TToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HideRestoreMenuItem});
            this.工具TToolStripMenuItem.Name = "工具TToolStripMenuItem";
            this.工具TToolStripMenuItem.Size = new System.Drawing.Size(72, 24);
            this.工具TToolStripMenuItem.Text = "工具(&T)";
            // 
            // HideRestoreMenuItem
            // 
            this.HideRestoreMenuItem.Name = "HideRestoreMenuItem";
            this.HideRestoreMenuItem.Size = new System.Drawing.Size(202, 26);
            this.HideRestoreMenuItem.Text = "隐藏程序管理(&R)";
            this.HideRestoreMenuItem.Click += new System.EventHandler(this.HideRestoreMenuItem_Click);
            // 
            // HelpMenuItem
            // 
            this.HelpMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CheckUpdateMenuItem,
            this.toolStripSeparator2,
            this.AboutMenuItem});
            this.HelpMenuItem.Name = "HelpMenuItem";
            this.HelpMenuItem.Size = new System.Drawing.Size(75, 24);
            this.HelpMenuItem.Text = "帮助(&H)";
            // 
            // CheckUpdateMenuItem
            // 
            this.CheckUpdateMenuItem.Name = "CheckUpdateMenuItem";
            this.CheckUpdateMenuItem.Size = new System.Drawing.Size(172, 26);
            this.CheckUpdateMenuItem.Text = "检查更新(&C)";
            this.CheckUpdateMenuItem.Click += new System.EventHandler(this.CheckUpdateMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(169, 6);
            // 
            // AboutMenuItem
            // 
            this.AboutMenuItem.Name = "AboutMenuItem";
            this.AboutMenuItem.Size = new System.Drawing.Size(172, 26);
            this.AboutMenuItem.Text = "关于(&A)";
            this.AboutMenuItem.Click += new System.EventHandler(this.AboutMenuItem_Click);
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(16, 331);
            this.StartButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(669, 36);
            this.StartButton.TabIndex = 6;
            this.StartButton.Text = "启动程序";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // StopTimerButton
            // 
            this.StopTimerButton.Location = new System.Drawing.Point(693, 331);
            this.StopTimerButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.StopTimerButton.Name = "StopTimerButton";
            this.StopTimerButton.Size = new System.Drawing.Size(121, 36);
            this.StopTimerButton.TabIndex = 10;
            this.StopTimerButton.Text = "中止";
            this.StopTimerButton.UseVisualStyleBackColor = true;
            this.StopTimerButton.Click += new System.EventHandler(this.StopTimerButton_Click);
            // 
            // LogText
            // 
            this.LogText.BackColor = System.Drawing.Color.White;
            this.LogText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LogText.Location = new System.Drawing.Point(16, 35);
            this.LogText.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LogText.Name = "LogText";
            this.LogText.ReadOnly = true;
            this.LogText.Size = new System.Drawing.Size(797, 256);
            this.LogText.TabIndex = 11;
            this.LogText.Text = "";
            // 
            // StatusText
            // 
            this.StatusText.Location = new System.Drawing.Point(16, 296);
            this.StatusText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.StatusText.Name = "StatusText";
            this.StatusText.Size = new System.Drawing.Size(799, 31);
            this.StatusText.TabIndex = 12;
            this.StatusText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SuNB_NotifyIcon
            // 
            this.SuNB_NotifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.SuNB_NotifyIcon.ContextMenuStrip = this.popupMenuStrip;
            this.SuNB_NotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("SuNB_NotifyIcon.Icon")));
            this.SuNB_NotifyIcon.Text = "CPL进程自动启动管理系统";
            this.SuNB_NotifyIcon.Visible = true;
            this.SuNB_NotifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.SuNB_NotifyIcon_MouseDoubleClick);
            // 
            // popupMenuStrip
            // 
            this.popupMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.popupMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.VersionPopupMenuItem,
            this.toolStripSeparator3,
            this.popupNotifyExitItem});
            this.popupMenuStrip.Name = "popupMenuStrip";
            this.popupMenuStrip.Size = new System.Drawing.Size(169, 58);
            // 
            // VersionPopupMenuItem
            // 
            this.VersionPopupMenuItem.Enabled = false;
            this.VersionPopupMenuItem.Name = "VersionPopupMenuItem";
            this.VersionPopupMenuItem.Size = new System.Drawing.Size(168, 24);
            this.VersionPopupMenuItem.Text = "版本：获取中";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(165, 6);
            // 
            // popupNotifyExitItem
            // 
            this.popupNotifyExitItem.Name = "popupNotifyExitItem";
            this.popupNotifyExitItem.Size = new System.Drawing.Size(168, 24);
            this.popupNotifyExitItem.Text = "退出(&E)";
            this.popupNotifyExitItem.Click += new System.EventHandler(this.PopupNotifyExitItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 385);
            this.Controls.Add(this.StatusText);
            this.Controls.Add(this.LogText);
            this.Controls.Add(this.StopTimerButton);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CPL进程自动启动管理系统";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.popupMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 路径设置ToolStripMenuItem;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.ToolStripMenuItem HelpMenuItem;
        private System.Windows.Forms.Button StopTimerButton;
        private System.Windows.Forms.RichTextBox LogText;
        private System.Windows.Forms.Label StatusText;
        private System.Windows.Forms.ToolStripMenuItem 系统设置SToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ExitButton;
        private System.Windows.Forms.ToolStripMenuItem CheckUpdateMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem AboutMenuItem;
        private System.Windows.Forms.NotifyIcon SuNB_NotifyIcon;
        private System.Windows.Forms.ContextMenuStrip popupMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem popupNotifyExitItem;
        private System.Windows.Forms.ToolStripMenuItem 工具TToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HideRestoreMenuItem;
        private System.Windows.Forms.ToolStripMenuItem VersionPopupMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}

