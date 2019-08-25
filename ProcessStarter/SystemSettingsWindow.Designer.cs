namespace ProcessStarter
{
    partial class SystemSettingsWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SystemSettingsWindow));
            this.SaveButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.HideWindowTextBox = new System.Windows.Forms.TextBox();
            this.HideWindowBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.HideWindowLabel = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ExitTextBox = new System.Windows.Forms.TextBox();
            this.ExitLabel = new System.Windows.Forms.Label();
            this.ExitBox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.MinToNotifyBox = new System.Windows.Forms.CheckBox();
            this.AutoLaunchProgramBox = new System.Windows.Forms.CheckBox();
            this.AutoUpdaterBox = new System.Windows.Forms.CheckBox();
            this.AutorunBox = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(169, 278);
            this.SaveButton.Margin = new System.Windows.Forms.Padding(4);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(193, 38);
            this.SaveButton.TabIndex = 1;
            this.SaveButton.Text = "保存设置";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.HideWindowTextBox);
            this.groupBox1.Controls.Add(this.HideWindowBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.HideWindowLabel);
            this.groupBox1.Location = new System.Drawing.Point(279, 139);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(233, 116);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "隐藏窗口";
            // 
            // HideWindowTextBox
            // 
            this.HideWindowTextBox.Location = new System.Drawing.Point(137, 64);
            this.HideWindowTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.HideWindowTextBox.Name = "HideWindowTextBox";
            this.HideWindowTextBox.Size = new System.Drawing.Size(47, 25);
            this.HideWindowTextBox.TabIndex = 6;
            this.HideWindowTextBox.TextChanged += new System.EventHandler(this.HideWindowTextBox_TextChanged);
            // 
            // HideWindowBox
            // 
            this.HideWindowBox.AutoSize = true;
            this.HideWindowBox.Location = new System.Drawing.Point(23, 35);
            this.HideWindowBox.Margin = new System.Windows.Forms.Padding(4);
            this.HideWindowBox.Name = "HideWindowBox";
            this.HideWindowBox.Size = new System.Drawing.Size(119, 19);
            this.HideWindowBox.TabIndex = 8;
            this.HideWindowBox.Text = "自动隐藏窗口";
            this.HideWindowBox.UseVisualStyleBackColor = true;
            this.HideWindowBox.CheckedChanged += new System.EventHandler(this.HideWindowBox_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(193, 68);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "秒";
            this.label1.Click += new System.EventHandler(this.Label1_Click);
            // 
            // HideWindowLabel
            // 
            this.HideWindowLabel.AutoSize = true;
            this.HideWindowLabel.Location = new System.Drawing.Point(20, 68);
            this.HideWindowLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.HideWindowLabel.Name = "HideWindowLabel";
            this.HideWindowLabel.Size = new System.Drawing.Size(112, 15);
            this.HideWindowLabel.TabIndex = 3;
            this.HideWindowLabel.Text = "隐藏窗口时间：";
            this.HideWindowLabel.Click += new System.EventHandler(this.HideWindowLabel_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ExitTextBox);
            this.groupBox2.Controls.Add(this.ExitLabel);
            this.groupBox2.Controls.Add(this.ExitBox);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(32, 139);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(233, 116);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "执行完毕退出软件";
            // 
            // ExitTextBox
            // 
            this.ExitTextBox.Location = new System.Drawing.Point(137, 64);
            this.ExitTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.ExitTextBox.Name = "ExitTextBox";
            this.ExitTextBox.Size = new System.Drawing.Size(47, 25);
            this.ExitTextBox.TabIndex = 6;
            // 
            // ExitLabel
            // 
            this.ExitLabel.AutoSize = true;
            this.ExitLabel.Location = new System.Drawing.Point(20, 68);
            this.ExitLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ExitLabel.Name = "ExitLabel";
            this.ExitLabel.Size = new System.Drawing.Size(112, 15);
            this.ExitLabel.TabIndex = 9;
            this.ExitLabel.Text = "软件退出时间：";
            // 
            // ExitBox
            // 
            this.ExitBox.AutoSize = true;
            this.ExitBox.Location = new System.Drawing.Point(23, 34);
            this.ExitBox.Margin = new System.Windows.Forms.Padding(4);
            this.ExitBox.Name = "ExitBox";
            this.ExitBox.Size = new System.Drawing.Size(119, 19);
            this.ExitBox.TabIndex = 8;
            this.ExitBox.Text = "自动退出软件";
            this.ExitBox.UseVisualStyleBackColor = true;
            this.ExitBox.CheckedChanged += new System.EventHandler(this.ExitBox_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(193, 68);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "秒";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.MinToNotifyBox);
            this.groupBox3.Controls.Add(this.AutoLaunchProgramBox);
            this.groupBox3.Controls.Add(this.AutoUpdaterBox);
            this.groupBox3.Controls.Add(this.AutorunBox);
            this.groupBox3.Location = new System.Drawing.Point(32, 15);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(480, 116);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "功能设置";
            // 
            // MinToNotifyBox
            // 
            this.MinToNotifyBox.AutoSize = true;
            this.MinToNotifyBox.Location = new System.Drawing.Point(273, 71);
            this.MinToNotifyBox.Margin = new System.Windows.Forms.Padding(4);
            this.MinToNotifyBox.Name = "MinToNotifyBox";
            this.MinToNotifyBox.Size = new System.Drawing.Size(119, 19);
            this.MinToNotifyBox.TabIndex = 4;
            this.MinToNotifyBox.Text = "最小化到托盘";
            this.MinToNotifyBox.UseVisualStyleBackColor = true;
            // 
            // AutoLaunchProgramBox
            // 
            this.AutoLaunchProgramBox.AutoSize = true;
            this.AutoLaunchProgramBox.Location = new System.Drawing.Point(57, 71);
            this.AutoLaunchProgramBox.Margin = new System.Windows.Forms.Padding(4);
            this.AutoLaunchProgramBox.Name = "AutoLaunchProgramBox";
            this.AutoLaunchProgramBox.Size = new System.Drawing.Size(119, 19);
            this.AutoLaunchProgramBox.TabIndex = 3;
            this.AutoLaunchProgramBox.Text = "自动启动目标";
            this.AutoLaunchProgramBox.UseVisualStyleBackColor = true;
            // 
            // AutoUpdaterBox
            // 
            this.AutoUpdaterBox.AutoSize = true;
            this.AutoUpdaterBox.Location = new System.Drawing.Point(273, 31);
            this.AutoUpdaterBox.Margin = new System.Windows.Forms.Padding(4);
            this.AutoUpdaterBox.Name = "AutoUpdaterBox";
            this.AutoUpdaterBox.Size = new System.Drawing.Size(89, 19);
            this.AutoUpdaterBox.TabIndex = 2;
            this.AutoUpdaterBox.Text = "自动更新";
            this.AutoUpdaterBox.UseVisualStyleBackColor = true;
            // 
            // AutorunBox
            // 
            this.AutorunBox.AutoSize = true;
            this.AutorunBox.Location = new System.Drawing.Point(57, 31);
            this.AutorunBox.Margin = new System.Windows.Forms.Padding(4);
            this.AutorunBox.Name = "AutorunBox";
            this.AutorunBox.Size = new System.Drawing.Size(89, 19);
            this.AutorunBox.TabIndex = 1;
            this.AutorunBox.Text = "开机自启";
            this.AutorunBox.UseVisualStyleBackColor = true;
            // 
            // SystemSettingsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 332);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.SaveButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SystemSettingsWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "系统设置";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SystemSettingsWindow_FormClosed);
            this.Load += new System.EventHandler(this.SystemSettingsWindow_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox HideWindowTextBox;
        private System.Windows.Forms.CheckBox HideWindowBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label HideWindowLabel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox ExitTextBox;
        private System.Windows.Forms.Label ExitLabel;
        private System.Windows.Forms.CheckBox ExitBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox AutoUpdaterBox;
        private System.Windows.Forms.CheckBox AutorunBox;
        private System.Windows.Forms.CheckBox AutoLaunchProgramBox;
        private System.Windows.Forms.CheckBox MinToNotifyBox;
    }
}