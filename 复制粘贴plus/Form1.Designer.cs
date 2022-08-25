namespace 复制粘贴plus
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.shearWall = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.oldstr = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.newstr = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.keyhook = new System.Windows.Forms.TextBox();
            this.keyhookHeader = new System.Windows.Forms.ComboBox();
            this.oldstrcbxESC = new System.Windows.Forms.CheckBox();
            this.newstrcbxESC = new System.Windows.Forms.CheckBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            this.SuspendLayout();
            // 
            // shearWall
            // 
            this.shearWall.Location = new System.Drawing.Point(6, 20);
            this.shearWall.Multiline = true;
            this.shearWall.Name = "shearWall";
            this.shearWall.Size = new System.Drawing.Size(764, 209);
            this.shearWall.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.shearWall);
            this.groupBox1.Location = new System.Drawing.Point(12, 203);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 235);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "剪切板：";
            // 
            // oldstr
            // 
            this.oldstr.Location = new System.Drawing.Point(87, 12);
            this.oldstr.Multiline = true;
            this.oldstr.Name = "oldstr";
            this.oldstr.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.oldstr.Size = new System.Drawing.Size(150, 49);
            this.oldstr.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "替换后字符";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "替换前字符";
            // 
            // newstr
            // 
            this.newstr.Location = new System.Drawing.Point(87, 67);
            this.newstr.Multiline = true;
            this.newstr.Name = "newstr";
            this.newstr.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.newstr.Size = new System.Drawing.Size(150, 49);
            this.newstr.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "替换快捷键";
            // 
            // keyhook
            // 
            this.keyhook.Location = new System.Drawing.Point(214, 122);
            this.keyhook.Name = "keyhook";
            this.keyhook.ReadOnly = true;
            this.keyhook.Size = new System.Drawing.Size(150, 21);
            this.keyhook.TabIndex = 7;
            this.keyhook.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyhook_KeyDown);
            // 
            // keyhookHeader
            // 
            this.keyhookHeader.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.keyhookHeader.FormattingEnabled = true;
            this.keyhookHeader.Location = new System.Drawing.Point(87, 122);
            this.keyhookHeader.Name = "keyhookHeader";
            this.keyhookHeader.Size = new System.Drawing.Size(121, 20);
            this.keyhookHeader.TabIndex = 8;
            this.keyhookHeader.SelectedIndexChanged += new System.EventHandler(this.keyhookHeader_SelectedIndexChanged);
            // 
            // oldstrcbxESC
            // 
            this.oldstrcbxESC.AutoSize = true;
            this.oldstrcbxESC.Location = new System.Drawing.Point(243, 17);
            this.oldstrcbxESC.Name = "oldstrcbxESC";
            this.oldstrcbxESC.Size = new System.Drawing.Size(48, 16);
            this.oldstrcbxESC.TabIndex = 9;
            this.oldstrcbxESC.Text = "转义";
            this.oldstrcbxESC.UseVisualStyleBackColor = true;
            // 
            // newstrcbxESC
            // 
            this.newstrcbxESC.AutoSize = true;
            this.newstrcbxESC.Location = new System.Drawing.Point(243, 72);
            this.newstrcbxESC.Name = "newstrcbxESC";
            this.newstrcbxESC.Size = new System.Drawing.Size(48, 16);
            this.newstrcbxESC.TabIndex = 10;
            this.newstrcbxESC.Text = "转义";
            this.newstrcbxESC.UseVisualStyleBackColor = true;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "庹少的剪贴板操作";
            this.notifyIcon1.Visible = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.退出ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 26);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(688, 5);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 12;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(713, 134);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "播放";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(684, 32);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(104, 45);
            this.trackBar1.TabIndex = 14;
            this.trackBar1.Value = 5;
            // 
            // trackBar2
            // 
            this.trackBar2.Location = new System.Drawing.Point(684, 83);
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(104, 45);
            this.trackBar2.TabIndex = 15;
            this.trackBar2.Value = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(637, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 16;
            this.label4.Text = "音量";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(637, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 17;
            this.label5.Text = "语速";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.trackBar2);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.newstrcbxESC);
            this.Controls.Add(this.oldstrcbxESC);
            this.Controls.Add(this.keyhookHeader);
            this.Controls.Add(this.keyhook);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.newstr);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.oldstr);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "剪切板内容替换工具";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox shearWall;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox oldstr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox newstr;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox keyhook;
        private System.Windows.Forms.ComboBox keyhookHeader;
        private System.Windows.Forms.CheckBox oldstrcbxESC;
        private System.Windows.Forms.CheckBox newstrcbxESC;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}

