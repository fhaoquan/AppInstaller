namespace Install
{
    partial class mainFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainFrm));
            this.process = new System.Windows.Forms.CProgressBar();
            this.btnstart = new System.Windows.Forms.CButton();
            this.SuspendLayout();
            // 
            // process
            // 
            this.process.BackColor = System.Drawing.Color.Transparent;
            this.process.BlockBitmap = ((System.Drawing.Bitmap)(resources.GetObject("process.BlockBitmap")));
            this.process.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.process.BtnColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.process.Location = new System.Drawing.Point(150, 364);
            this.process.Maximum = 100;
            this.process.Name = "process";
            this.process.ShowBorder = true;
            this.process.Size = new System.Drawing.Size(400, 10);
            this.process.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.process.TabIndex = 1;
            this.process.Value = 1;
            this.process.Visible = false;
            // 
            // btnstart
            // 
            this.btnstart.BackColor = System.Drawing.Color.Transparent;
            this.btnstart.BgImage = null;
            this.btnstart.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(88)))), ((int)(((byte)(0)))));
            this.btnstart.BtnColor = System.Drawing.Color.Green;
            this.btnstart.BtnImage = null;
            this.btnstart.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.btnstart.FontColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnstart.ForeColor = System.Drawing.Color.Black;
            this.btnstart.ImageOffSet = new System.Drawing.Point(0, 0);
            this.btnstart.ImageWidth = 18;
            this.btnstart.Location = new System.Drawing.Point(268, 380);
            this.btnstart.Name = "btnstart";
            this.btnstart.Round = new System.Windows.Forms.Padding(25);
            this.btnstart.ShowBorder = true;
            this.btnstart.Size = new System.Drawing.Size(164, 52);
            this.btnstart.TabIndex = 2;
            this.btnstart.Text = "一键安装";
            this.btnstart.ToopTipText = null;
            this.btnstart.UseVisualStyleBackColor = false;
            this.btnstart.Click += new System.EventHandler(this.start);
            // 
            // mainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(88)))), ((int)(((byte)(88)))));
            this.BackgroundImage = global::Install.Properties.Resources.logo_bg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BorderPadding = new System.Windows.Forms.Padding(0);
            this.CanResize = false;
            this.ClientSize = new System.Drawing.Size(699, 468);
            this.Controls.Add(this.btnstart);
            this.Controls.Add(this.process);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "mainFrm";
            this.Radius = 1;
            this.ShowBorder = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "德易拍安装向导";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.CProgressBar process;
        private System.Windows.Forms.CButton btnstart;
    }
}

