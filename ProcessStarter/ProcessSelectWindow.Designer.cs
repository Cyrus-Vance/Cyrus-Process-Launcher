namespace ProcessStarter
{
    partial class ProcessSelectWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProcessSelectWindow));
            this.ProcessView = new System.Windows.Forms.ListView();
            this.processImageList = new System.Windows.Forms.ImageList(this.components);
            this.OKButton = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.loadProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // ProcessView
            // 
            this.ProcessView.LargeImageList = this.processImageList;
            this.ProcessView.Location = new System.Drawing.Point(9, 9);
            this.ProcessView.Margin = new System.Windows.Forms.Padding(2);
            this.ProcessView.Name = "ProcessView";
            this.ProcessView.Size = new System.Drawing.Size(624, 404);
            this.ProcessView.SmallImageList = this.processImageList;
            this.ProcessView.TabIndex = 0;
            this.ProcessView.UseCompatibleStateImageBehavior = false;
            this.ProcessView.View = System.Windows.Forms.View.Details;
            this.ProcessView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ProcessView_ColumnClick);
            this.ProcessView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ProcessView_MouseDoubleClick);
            // 
            // processImageList
            // 
            this.processImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
            this.processImageList.ImageSize = new System.Drawing.Size(20, 20);
            this.processImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(278, 418);
            this.OKButton.Margin = new System.Windows.Forms.Padding(2);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(103, 29);
            this.OKButton.TabIndex = 1;
            this.OKButton.Text = "确定";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel,
            this.loadProgressBar});
            this.statusStrip.Location = new System.Drawing.Point(0, 455);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(642, 22);
            this.statusStrip.TabIndex = 4;
            this.statusStrip.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(425, 17);
            this.statusLabel.Spring = true;
            this.statusLabel.Text = "就绪";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // loadProgressBar
            // 
            this.loadProgressBar.Name = "loadProgressBar";
            this.loadProgressBar.Size = new System.Drawing.Size(200, 16);
            // 
            // ProcessSelectWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 477);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.ProcessView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(658, 493);
            this.Name = "ProcessSelectWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "进程选择";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ProcessSelectWindow_Load);
            this.Resize += new System.EventHandler(this.ProcessSelectWindow_Resize);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView ProcessView;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.ImageList processImageList;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ToolStripProgressBar loadProgressBar;
    }
}