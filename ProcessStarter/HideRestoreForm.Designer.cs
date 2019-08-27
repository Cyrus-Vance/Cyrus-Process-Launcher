namespace ProcessStarter
{
    partial class HideRestoreForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HideRestoreForm));
            this.ProcessView = new System.Windows.Forms.ListView();
            this.processImageList = new System.Windows.Forms.ImageList(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.RefreshProcessListButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.HideProcessButton = new System.Windows.Forms.Button();
            this.ManualPIDTextBox = new System.Windows.Forms.TextBox();
            this.ManualLabel = new System.Windows.Forms.Label();
            this.ManualPIDCheckBox = new System.Windows.Forms.CheckBox();
            this.RestoreProcessButton = new System.Windows.Forms.Button();
            this.RefreshListTimer = new System.Windows.Forms.Timer(this.components);
            this.SelectProcessButton = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ProcessView
            // 
            this.ProcessView.LargeImageList = this.processImageList;
            this.ProcessView.Location = new System.Drawing.Point(16, 15);
            this.ProcessView.Margin = new System.Windows.Forms.Padding(4);
            this.ProcessView.Name = "ProcessView";
            this.ProcessView.Size = new System.Drawing.Size(565, 398);
            this.ProcessView.SmallImageList = this.processImageList;
            this.ProcessView.TabIndex = 0;
            this.ProcessView.UseCompatibleStateImageBehavior = false;
            this.ProcessView.View = System.Windows.Forms.View.Details;
            // 
            // processImageList
            // 
            this.processImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
            this.processImageList.ImageSize = new System.Drawing.Size(24, 24);
            this.processImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 430);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(909, 26);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(39, 20);
            this.toolStripStatusLabel1.Text = "就绪";
            // 
            // RefreshProcessListButton
            // 
            this.RefreshProcessListButton.Location = new System.Drawing.Point(604, 15);
            this.RefreshProcessListButton.Margin = new System.Windows.Forms.Padding(4);
            this.RefreshProcessListButton.Name = "RefreshProcessListButton";
            this.RefreshProcessListButton.Size = new System.Drawing.Size(291, 35);
            this.RefreshProcessListButton.TabIndex = 7;
            this.RefreshProcessListButton.Text = "刷新进程列表";
            this.RefreshProcessListButton.UseVisualStyleBackColor = true;
            this.RefreshProcessListButton.Click += new System.EventHandler(this.RefreshProcessListButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.SelectProcessButton);
            this.groupBox1.Controls.Add(this.HideProcessButton);
            this.groupBox1.Controls.Add(this.ManualPIDTextBox);
            this.groupBox1.Controls.Add(this.ManualLabel);
            this.groupBox1.Controls.Add(this.ManualPIDCheckBox);
            this.groupBox1.Controls.Add(this.RestoreProcessButton);
            this.groupBox1.Location = new System.Drawing.Point(604, 225);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(291, 189);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "进程操作";
            // 
            // HideProcessButton
            // 
            this.HideProcessButton.Location = new System.Drawing.Point(19, 94);
            this.HideProcessButton.Margin = new System.Windows.Forms.Padding(4);
            this.HideProcessButton.Name = "HideProcessButton";
            this.HideProcessButton.Size = new System.Drawing.Size(259, 35);
            this.HideProcessButton.TabIndex = 11;
            this.HideProcessButton.Text = "隐藏进程窗口";
            this.HideProcessButton.UseVisualStyleBackColor = true;
            this.HideProcessButton.Click += new System.EventHandler(this.HideProcessButton_Click);
            // 
            // ManualPIDTextBox
            // 
            this.ManualPIDTextBox.Enabled = false;
            this.ManualPIDTextBox.Location = new System.Drawing.Point(77, 56);
            this.ManualPIDTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.ManualPIDTextBox.Name = "ManualPIDTextBox";
            this.ManualPIDTextBox.Size = new System.Drawing.Size(142, 25);
            this.ManualPIDTextBox.TabIndex = 9;
            this.ManualPIDTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ManualPIDTextBox_KeyPress);
            // 
            // ManualLabel
            // 
            this.ManualLabel.AutoSize = true;
            this.ManualLabel.Enabled = false;
            this.ManualLabel.Location = new System.Drawing.Point(16, 61);
            this.ManualLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ManualLabel.Name = "ManualLabel";
            this.ManualLabel.Size = new System.Drawing.Size(61, 15);
            this.ManualLabel.TabIndex = 10;
            this.ManualLabel.Text = "进程ID:";
            // 
            // ManualPIDCheckBox
            // 
            this.ManualPIDCheckBox.AutoSize = true;
            this.ManualPIDCheckBox.Location = new System.Drawing.Point(19, 29);
            this.ManualPIDCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.ManualPIDCheckBox.Name = "ManualPIDCheckBox";
            this.ManualPIDCheckBox.Size = new System.Drawing.Size(89, 19);
            this.ManualPIDCheckBox.TabIndex = 8;
            this.ManualPIDCheckBox.Text = "手动操作";
            this.ManualPIDCheckBox.UseVisualStyleBackColor = true;
            this.ManualPIDCheckBox.CheckedChanged += new System.EventHandler(this.ManualPIDCheckBox_CheckedChanged);
            // 
            // RestoreProcessButton
            // 
            this.RestoreProcessButton.Location = new System.Drawing.Point(19, 136);
            this.RestoreProcessButton.Margin = new System.Windows.Forms.Padding(4);
            this.RestoreProcessButton.Name = "RestoreProcessButton";
            this.RestoreProcessButton.Size = new System.Drawing.Size(259, 35);
            this.RestoreProcessButton.TabIndex = 7;
            this.RestoreProcessButton.Text = "还原进程窗口";
            this.RestoreProcessButton.UseVisualStyleBackColor = true;
            this.RestoreProcessButton.Click += new System.EventHandler(this.RestoreProcessButton_Click);
            // 
            // RefreshListTimer
            // 
            this.RefreshListTimer.Interval = 30000;
            this.RefreshListTimer.Tick += new System.EventHandler(this.RefreshListTimer_Tick);
            // 
            // SelectProcessButton
            // 
            this.SelectProcessButton.Enabled = false;
            this.SelectProcessButton.Location = new System.Drawing.Point(227, 54);
            this.SelectProcessButton.Name = "SelectProcessButton";
            this.SelectProcessButton.Size = new System.Drawing.Size(51, 28);
            this.SelectProcessButton.TabIndex = 12;
            this.SelectProcessButton.Text = "选择";
            this.SelectProcessButton.UseVisualStyleBackColor = true;
            // 
            // HideRestoreForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 456);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.RefreshProcessListButton);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.ProcessView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HideRestoreForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "隐藏程序管理";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.HideRestoreForm_FormClosed);
            this.Load += new System.EventHandler(this.HideRestoreForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView ProcessView;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ImageList processImageList;
        private System.Windows.Forms.Button RefreshProcessListButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button HideProcessButton;
        private System.Windows.Forms.TextBox ManualPIDTextBox;
        private System.Windows.Forms.Label ManualLabel;
        private System.Windows.Forms.CheckBox ManualPIDCheckBox;
        private System.Windows.Forms.Button RestoreProcessButton;
        private System.Windows.Forms.Timer RefreshListTimer;
        private System.Windows.Forms.Button SelectProcessButton;
    }
}