namespace fastDFSDemo
{
    partial class FastDF
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.txtTracker = new System.Windows.Forms.TextBox();
            this.txtStorage = new System.Windows.Forms.TextBox();
            this.btnLinkFastDfs = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "traker服务器列表";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(252, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "storage服务器列表";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(436, 175);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "选择文件并上传";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(33, 177);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(397, 21);
            this.textBox1.TabIndex = 7;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(33, 217);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(512, 184);
            this.listBox1.TabIndex = 9;
            // 
            // txtTracker
            // 
            this.txtTracker.Location = new System.Drawing.Point(33, 51);
            this.txtTracker.Multiline = true;
            this.txtTracker.Name = "txtTracker";
            this.txtTracker.Size = new System.Drawing.Size(200, 103);
            this.txtTracker.TabIndex = 10;
            // 
            // txtStorage
            // 
            this.txtStorage.Location = new System.Drawing.Point(254, 51);
            this.txtStorage.Multiline = true;
            this.txtStorage.Name = "txtStorage";
            this.txtStorage.Size = new System.Drawing.Size(200, 103);
            this.txtStorage.TabIndex = 11;
            // 
            // btnLinkFastDfs
            // 
            this.btnLinkFastDfs.Location = new System.Drawing.Point(470, 51);
            this.btnLinkFastDfs.Name = "btnLinkFastDfs";
            this.btnLinkFastDfs.Size = new System.Drawing.Size(75, 74);
            this.btnLinkFastDfs.TabIndex = 12;
            this.btnLinkFastDfs.Text = "连接FASTDFS";
            this.btnLinkFastDfs.UseVisualStyleBackColor = true;
            this.btnLinkFastDfs.Click += new System.EventHandler(this.btnLinkFastDfs_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label3.Location = new System.Drawing.Point(460, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "尚未连接FASTDFS";
            // 
            // FastDF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 414);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnLinkFastDfs);
            this.Controls.Add(this.txtStorage);
            this.Controls.Add(this.txtTracker);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FastDF";
            this.Text = "FastDFS分布式文件系统";
            this.Load += new System.EventHandler(this.FastDF_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox txtTracker;
        private System.Windows.Forms.TextBox txtStorage;
        private System.Windows.Forms.Button btnLinkFastDfs;
        private System.Windows.Forms.Label label3;
    }
}

