namespace ServerStarter
{
    partial class PathConfigWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PathConfigWindow));
            this.SaveButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.HideBox = new System.Windows.Forms.CheckBox();
            this.EnableBox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BrowsePathButton = new System.Windows.Forms.Button();
            this.ProgramCmdLineText = new System.Windows.Forms.TextBox();
            this.ProgramPathText = new System.Windows.Forms.TextBox();
            this.selectNumBox = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.TotalAmountLabel = new System.Windows.Forms.Label();
            this.AddButton = new System.Windows.Forms.Button();
            this.DelButton = new System.Windows.Forms.Button();
            this.AmountNumLabel = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selectNumBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(252, 258);
            this.SaveButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(161, 32);
            this.SaveButton.TabIndex = 10;
            this.SaveButton.Text = "保存";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.HideBox);
            this.groupBox1.Controls.Add(this.EnableBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.BrowsePathButton);
            this.groupBox1.Controls.Add(this.ProgramCmdLineText);
            this.groupBox1.Controls.Add(this.ProgramPathText);
            this.groupBox1.Location = new System.Drawing.Point(32, 75);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(613, 165);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "程序配置";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Enabled = false;
            this.checkBox1.Location = new System.Drawing.Point(356, 124);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(194, 19);
            this.checkBox1.TabIndex = 16;
            this.checkBox1.Text = "隐藏进程（仅高级版本）";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // HideBox
            // 
            this.HideBox.AutoSize = true;
            this.HideBox.Checked = true;
            this.HideBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.HideBox.Location = new System.Drawing.Point(191, 124);
            this.HideBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.HideBox.Name = "HideBox";
            this.HideBox.Size = new System.Drawing.Size(134, 19);
            this.HideBox.TabIndex = 15;
            this.HideBox.Text = "启动后隐藏窗口";
            this.HideBox.UseVisualStyleBackColor = true;
            // 
            // EnableBox
            // 
            this.EnableBox.AutoSize = true;
            this.EnableBox.Checked = true;
            this.EnableBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.EnableBox.Location = new System.Drawing.Point(57, 124);
            this.EnableBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.EnableBox.Name = "EnableBox";
            this.EnableBox.Size = new System.Drawing.Size(104, 19);
            this.EnableBox.TabIndex = 14;
            this.EnableBox.Text = "启用该程序";
            this.EnableBox.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 86);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 15);
            this.label2.TabIndex = 13;
            this.label2.Text = "参数:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 40);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 15);
            this.label1.TabIndex = 12;
            this.label1.Text = "路径:";
            // 
            // BrowsePathButton
            // 
            this.BrowsePathButton.Location = new System.Drawing.Point(545, 34);
            this.BrowsePathButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BrowsePathButton.Name = "BrowsePathButton";
            this.BrowsePathButton.Size = new System.Drawing.Size(52, 28);
            this.BrowsePathButton.TabIndex = 11;
            this.BrowsePathButton.Text = "...";
            this.BrowsePathButton.UseVisualStyleBackColor = true;
            this.BrowsePathButton.Click += new System.EventHandler(this.BrowsePathButton_Click);
            // 
            // ProgramCmdLineText
            // 
            this.ProgramCmdLineText.Location = new System.Drawing.Point(80, 82);
            this.ProgramCmdLineText.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ProgramCmdLineText.MaxLength = 150;
            this.ProgramCmdLineText.Name = "ProgramCmdLineText";
            this.ProgramCmdLineText.Size = new System.Drawing.Size(456, 25);
            this.ProgramCmdLineText.TabIndex = 10;
            // 
            // ProgramPathText
            // 
            this.ProgramPathText.Location = new System.Drawing.Point(80, 36);
            this.ProgramPathText.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ProgramPathText.MaxLength = 150;
            this.ProgramPathText.Name = "ProgramPathText";
            this.ProgramPathText.Size = new System.Drawing.Size(456, 25);
            this.ProgramPathText.TabIndex = 9;
            // 
            // selectNumBox
            // 
            this.selectNumBox.Location = new System.Drawing.Point(125, 30);
            this.selectNumBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.selectNumBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.selectNumBox.Name = "selectNumBox";
            this.selectNumBox.ReadOnly = true;
            this.selectNumBox.Size = new System.Drawing.Size(87, 25);
            this.selectNumBox.TabIndex = 13;
            this.selectNumBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.selectNumBox.ValueChanged += new System.EventHandler(this.SelectNumBox_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 35);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 14;
            this.label3.Text = "当前选择";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TotalAmountLabel
            // 
            this.TotalAmountLabel.AutoSize = true;
            this.TotalAmountLabel.Location = new System.Drawing.Point(527, 35);
            this.TotalAmountLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TotalAmountLabel.Name = "TotalAmountLabel";
            this.TotalAmountLabel.Size = new System.Drawing.Size(82, 15);
            this.TotalAmountLabel.TabIndex = 15;
            this.TotalAmountLabel.Text = "启动总数：";
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(220, 29);
            this.AddButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(75, 29);
            this.AddButton.TabIndex = 16;
            this.AddButton.Text = "添加";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // DelButton
            // 
            this.DelButton.Location = new System.Drawing.Point(301, 29);
            this.DelButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DelButton.Name = "DelButton";
            this.DelButton.Size = new System.Drawing.Size(75, 29);
            this.DelButton.TabIndex = 17;
            this.DelButton.Text = "删除";
            this.DelButton.UseVisualStyleBackColor = true;
            this.DelButton.Click += new System.EventHandler(this.DelButton_Click);
            // 
            // AmountNumLabel
            // 
            this.AmountNumLabel.AutoSize = true;
            this.AmountNumLabel.Location = new System.Drawing.Point(611, 35);
            this.AmountNumLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.AmountNumLabel.Name = "AmountNumLabel";
            this.AmountNumLabel.Size = new System.Drawing.Size(15, 15);
            this.AmountNumLabel.TabIndex = 18;
            this.AmountNumLabel.Text = "0";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(583, 260);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(63, 30);
            this.dataGridView1.TabIndex = 19;
            this.dataGridView1.Visible = false;
            // 
            // PathConfigWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 302);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.AmountNumLabel);
            this.Controls.Add(this.DelButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.TotalAmountLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.selectNumBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.SaveButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PathConfigWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "路径配置";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PathConfigWindow_FormClosed);
            this.Load += new System.EventHandler(this.PathConfigWindow_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selectNumBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BrowsePathButton;
        private System.Windows.Forms.TextBox ProgramCmdLineText;
        private System.Windows.Forms.TextBox ProgramPathText;
        private System.Windows.Forms.NumericUpDown selectNumBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label TotalAmountLabel;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button DelButton;
        private System.Windows.Forms.CheckBox EnableBox;
        private System.Windows.Forms.Label AmountNumLabel;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox HideBox;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}