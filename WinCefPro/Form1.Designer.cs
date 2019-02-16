namespace WinCefPro
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
            this.slbl3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnVolume = new System.Windows.Forms.Button();
            this.slbl2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.slbl1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnLearnWithDataList = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.GetDataList = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.btnBegin = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cmsLearnDataList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiClear = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiReloadDataList = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSaveHistroyDataList = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiLoadHIstroyDataList = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnGo = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.rTxtLog = new System.Windows.Forms.RichTextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnGetPackageDataList = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.cmsLearnDataList.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // slbl3
            // 
            this.slbl3.Name = "slbl3";
            this.slbl3.Size = new System.Drawing.Size(56, 17);
            this.slbl3.Text = "课程名称";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(11, 17);
            this.toolStripStatusLabel1.Text = "|";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(11, 17);
            this.toolStripStatusLabel2.Text = "|";
            // 
            // btnVolume
            // 
            this.btnVolume.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVolume.Location = new System.Drawing.Point(1017, 7);
            this.btnVolume.Name = "btnVolume";
            this.btnVolume.Size = new System.Drawing.Size(75, 23);
            this.btnVolume.TabIndex = 30;
            this.btnVolume.Text = "音量";
            this.btnVolume.UseVisualStyleBackColor = true;
            this.btnVolume.Click += new System.EventHandler(this.btnVolume_Click);
            // 
            // slbl2
            // 
            this.slbl2.Name = "slbl2";
            this.slbl2.Size = new System.Drawing.Size(164, 17);
            this.slbl2.Text = "按课程列表学习状态：未启动";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(744, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 29;
            this.label3.Text = "跳转最新知识页";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 27;
            this.label1.Text = "用户名：";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(71, 35);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(100, 21);
            this.txtUser.TabIndex = 25;
            this.txtUser.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUser_KeyPress);
            // 
            // slbl1
            // 
            this.slbl1.Name = "slbl1";
            this.slbl1.Size = new System.Drawing.Size(104, 17);
            this.slbl1.Text = "自动学习：未启动";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(184, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 28;
            this.label2.Text = "密码：";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(231, 35);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(100, 21);
            this.txtPassword.TabIndex = 26;
            this.txtPassword.Text = "123456";
            this.txtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPassword_KeyPress);
            // 
            // btnLearnWithDataList
            // 
            this.btnLearnWithDataList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLearnWithDataList.Location = new System.Drawing.Point(911, 38);
            this.btnLearnWithDataList.Name = "btnLearnWithDataList";
            this.btnLearnWithDataList.Size = new System.Drawing.Size(100, 23);
            this.btnLearnWithDataList.TabIndex = 24;
            this.btnLearnWithDataList.Text = "按课程列表学习";
            this.btnLearnWithDataList.UseVisualStyleBackColor = true;
            this.btnLearnWithDataList.Click += new System.EventHandler(this.btnLearnWithDataList_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(337, 33);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 23;
            this.btnLogin.Text = "登录";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // GetDataList
            // 
            this.GetDataList.Location = new System.Drawing.Point(418, 33);
            this.GetDataList.Name = "GetDataList";
            this.GetDataList.Size = new System.Drawing.Size(86, 23);
            this.GetDataList.TabIndex = 22;
            this.GetDataList.Text = "获取课程列表";
            this.GetDataList.UseVisualStyleBackColor = true;
            this.GetDataList.Click += new System.EventHandler(this.GetDataList_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.comboBox1.Location = new System.Drawing.Point(839, 5);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(54, 20);
            this.comboBox1.TabIndex = 21;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.slbl1,
            this.toolStripStatusLabel1,
            this.slbl2,
            this.toolStripStatusLabel2,
            this.slbl3});
            this.statusStrip1.Location = new System.Drawing.Point(0, 500);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1104, 22);
            this.statusStrip1.TabIndex = 20;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // btnBegin
            // 
            this.btnBegin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBegin.Location = new System.Drawing.Point(1017, 38);
            this.btnBegin.Name = "btnBegin";
            this.btnBegin.Size = new System.Drawing.Size(75, 23);
            this.btnBegin.TabIndex = 19;
            this.btnBegin.Text = "自动学习";
            this.btnBegin.UseVisualStyleBackColor = true;
            this.btnBegin.Click += new System.EventHandler(this.btnBegin_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1093, 403);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "云学堂";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cmsLearnDataList
            // 
            this.cmsLearnDataList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiClear,
            this.tsmiReloadDataList,
            this.tsmiSaveHistroyDataList,
            this.tsmiLoadHIstroyDataList});
            this.cmsLearnDataList.Name = "cmsLearnDataList";
            this.cmsLearnDataList.Size = new System.Drawing.Size(149, 92);
            // 
            // tsmiClear
            // 
            this.tsmiClear.Name = "tsmiClear";
            this.tsmiClear.Size = new System.Drawing.Size(148, 22);
            this.tsmiClear.Text = "清空列表";
            this.tsmiClear.Click += new System.EventHandler(this.tsmiClear_Click);
            // 
            // tsmiReloadDataList
            // 
            this.tsmiReloadDataList.Name = "tsmiReloadDataList";
            this.tsmiReloadDataList.Size = new System.Drawing.Size(148, 22);
            this.tsmiReloadDataList.Text = "重新加载列表";
            this.tsmiReloadDataList.Click += new System.EventHandler(this.tsmiReloadDataList_Click);
            // 
            // tsmiSaveHistroyDataList
            // 
            this.tsmiSaveHistroyDataList.Name = "tsmiSaveHistroyDataList";
            this.tsmiSaveHistroyDataList.Size = new System.Drawing.Size(148, 22);
            this.tsmiSaveHistroyDataList.Text = "保存学习列表";
            this.tsmiSaveHistroyDataList.Click += new System.EventHandler(this.tsmiSaveHistroyDataList_Click);
            // 
            // tsmiLoadHIstroyDataList
            // 
            this.tsmiLoadHIstroyDataList.Name = "tsmiLoadHIstroyDataList";
            this.tsmiLoadHIstroyDataList.Size = new System.Drawing.Size(148, 22);
            this.tsmiLoadHIstroyDataList.Text = "读取学习列表";
            this.tsmiLoadHIstroyDataList.Click += new System.EventHandler(this.tsmiLoadHIstroyDataList_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1093, 403);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "学习页面";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.ContextMenuStrip = this.cmsLearnDataList;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(3, 3);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(1087, 397);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.richTextBox1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1093, 403);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "学习列表页";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(639, 5);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(43, 23);
            this.btnGo.TabIndex = 17;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(3, 7);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(630, 21);
            this.textBox1.TabIndex = 18;
            this.textBox1.Text = "http://hongyangsoft.yunxuetang.cn";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.rTxtLog);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1093, 403);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "日志";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // rTxtLog
            // 
            this.rTxtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rTxtLog.Location = new System.Drawing.Point(3, 3);
            this.rTxtLog.Name = "rTxtLog";
            this.rTxtLog.Size = new System.Drawing.Size(1087, 397);
            this.rTxtLog.TabIndex = 0;
            this.rTxtLog.Text = "";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Location = new System.Drawing.Point(3, 62);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1101, 429);
            this.tabControl1.TabIndex = 16;
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(1093, 403);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "课程包备用";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "云学堂";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(688, 5);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(43, 23);
            this.btnRefresh.TabIndex = 31;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnGetPackageDataList
            // 
            this.btnGetPackageDataList.Location = new System.Drawing.Point(510, 33);
            this.btnGetPackageDataList.Name = "btnGetPackageDataList";
            this.btnGetPackageDataList.Size = new System.Drawing.Size(101, 23);
            this.btnGetPackageDataList.TabIndex = 32;
            this.btnGetPackageDataList.Text = "获取课程包列表";
            this.btnGetPackageDataList.UseVisualStyleBackColor = true;
            this.btnGetPackageDataList.Click += new System.EventHandler(this.btnGetPackageDataList_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1104, 522);
            this.Controls.Add(this.btnGetPackageDataList);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnVolume);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.btnLearnWithDataList);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.GetDataList);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnBegin);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.cmsLearnDataList.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripStatusLabel slbl3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.Button btnVolume;
        private System.Windows.Forms.ToolStripStatusLabel slbl2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.ToolStripStatusLabel slbl1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLearnWithDataList;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button GetDataList;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Button btnBegin;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ContextMenuStrip cmsLearnDataList;
        private System.Windows.Forms.ToolStripMenuItem tsmiClear;
        private System.Windows.Forms.ToolStripMenuItem tsmiReloadDataList;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.RichTextBox rTxtLog;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ToolStripMenuItem tsmiLoadHIstroyDataList;
        private System.Windows.Forms.ToolStripMenuItem tsmiSaveHistroyDataList;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnGetPackageDataList;
    }
}

