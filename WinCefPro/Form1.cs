using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using CefSharp;
using CefSharp.WinForms;
using System.Threading;

namespace WinCefPro
{
    public partial class Form1 : Form
    {
        #region 配置信息
        /// <summary>
        /// 用户信息 用户名 密码
        /// </summary>
        string UserInfo = "UserInfo";
        /// <summary>
        /// 最后课程列表
        /// </summary>
        string LastHistroyDataList = "LastHistroyDataList";
        #endregion
        
        public Form1()
        {
            InitializeComponent();
            //必须进行初始化，否则出不来页面啦。
            CefSharp.Cef.Initialize();

            //实例化控件 即课程列表页查看和获取具体学习页面路径
            browser = new CefSharp.WinForms.ChromiumWebBrowser("http://hongyangsoft.yunxuetang.cn");
            //设置停靠方式
            browser.Dock = DockStyle.Fill;
            //加入到当前窗体中
            this.tabControl1.TabPages[0].Controls.Add(browser);
            //绑定新窗口打开事件
            browser.LifeSpanHandler = new NewWindowCreatedEventHandler();
            //browser.LoadHandler = new NewLoadHandler();
            //browser.FrameLoadEnd += Browser_FrameLoadEnd;

            //实例化子控件 即学习页面
            browserChild = new CefSharp.WinForms.ChromiumWebBrowser("about:blank");
            //设置停靠方式
            browserChild.Dock = DockStyle.Fill;
            //加入到当前窗体中
            this.tabControl1.TabPages[1].Controls.Add(browserChild);
            Control.CheckForIllegalCrossThreadCalls = false;//防止出现  线程间操作无效:
        }

        private void Browser_FrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        {
            //throw new NotImplementedException();
            if (browser != null && browser.Address == "http://hongyangsoft.yunxuetang.cn/login.htm")
            {
                btnLogin_Click(sender, e);
            }
        }

        /// <summary>
        /// 打开新窗口事件处理(在当前浏览器窗口打开)
        /// </summary>
        internal class NewWindowCreatedEventHandler : ILifeSpanHandler
        {
            public bool DoClose(IWebBrowser browserControl, IBrowser browser)
            {
                return false;
            }

            public void OnAfterCreated(IWebBrowser browserControl, IBrowser browser)
            {

            }

            public void OnBeforeClose(IWebBrowser browserControl, IBrowser browser)
            {

            }

            public bool OnBeforePopup(IWebBrowser browserControl, IBrowser browser, IFrame frame, string targetUrl,
    string targetFrameName, WindowOpenDisposition targetDisposition, bool userGesture, IPopupFeatures popupFeatures,
    IWindowInfo windowInfo, IBrowserSettings browserSettings, ref bool noJavascriptAccess, out IWebBrowser newBrowser)
            {
                newBrowser = null;
                var chromiumWebBrowser = (ChromiumWebBrowser)browserControl;
                chromiumWebBrowser.Load(targetUrl);
                //MessageBox.Show(targetUrl);

                //if (targetUrl.IndexOf("knowledge/package") > -1)
                //{
                //    chromiumWebBrowser.Load(targetUrl);
                //}
                //else
                //{
                //    TabControl tcObj =((TabControl)(chromiumWebBrowser.Parent.Parent));
                //    if (tcObj.TabPages[1].Controls.Count > 0)
                //    {
                //        ChromiumWebBrowser cwObj = (ChromiumWebBrowser)(tcObj.TabPages[1].Controls[0]);
                //        cwObj.Load(targetUrl);
                //        //tcObj.SelectedIndex = 1;
                //    }
                //    else
                //    {
                //    }
                //}
                return true; //Return true to cancel the popup creation copyright by codebye.com.
            }
        }
        //页面加载事件
        internal class NewLoadHandler : ILoadHandler
        {
            public void OnFrameLoadEnd(IWebBrowser browserControl, FrameLoadEndEventArgs frameLoadEndArgs)
            {
                //throw new NotImplementedException();
                //MessageBox.Show("OnFrameLoadEnd");
                //var chromiumWebBrowser = (ChromiumWebBrowser)browserControl;
                //MessageBox.Show(chromiumWebBrowser);
            }

            public void OnFrameLoadStart(IWebBrowser browserControl, FrameLoadStartEventArgs frameLoadStartArgs)
            {
                //throw new NotImplementedException();
            }

            public void OnLoadError(IWebBrowser browserControl, LoadErrorEventArgs loadErrorArgs)
            {
                //throw new NotImplementedException();
            }

            public void OnLoadingStateChange(IWebBrowser browserControl, LoadingStateChangedEventArgs loadingStateChangedArgs)
            {
                //throw new NotImplementedException();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string url = textBox1.Text.Trim();
            SetBrowserUrl(url);
            #region 读取用户名密码配置信息
            string userInfoConfig = GetConfig(UserInfo);
            if (!string.IsNullOrEmpty(userInfoConfig) && userInfoConfig.IndexOf("$") > -1)
            {
                string[] userInfoArr = userInfoConfig.Split('$');
                if (userInfoArr.Length == 2)
                {
                    txtUser.Text = userInfoArr[0];
                    txtPassword.Text = userInfoArr[1];
                }
            }
            #endregion
        }
        
        /// <summary>
        /// 转到连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGo_Click(object sender, EventArgs e)
        {
            string url = textBox1.Text.Trim();
            SetBrowserUrl(url);
        }

        CefSharp.WinForms.ChromiumWebBrowser browser = null;
        void SetBrowserUrl(string url)
        {
            if (browser == null)
            {
                browser = new CefSharp.WinForms.ChromiumWebBrowser("about:blank");
                browser.Dock = DockStyle.Fill;//充满窗口  
                this.tabControl1.TabPages[0].Controls.Add(browser);//添加到窗口  
                
                browser.Load(url);
            }
            else
            {
                browser.Load(url);
            }
        }
        string GetBrowserHtml()
        {
            return BrowserEvaluateScriptAsync("return document.body.innerHTML;");
        }
        string BrowserEvaluateScriptAsync(string scriptStr)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("function tempFunction() {");
            sb.AppendLine(scriptStr);
            sb.AppendLine("}");
            sb.AppendLine("tempFunction();");
            string resultStr = "";
            try
            {
                var task = browser.GetBrowser().GetFrame(browser.GetBrowser().GetFrameNames()[0]).EvaluateScriptAsync(sb.ToString());
                task.ContinueWith(t =>
                {
                    if (!t.IsFaulted)
                    {
                        var response = t.Result;
                        if (response.Success == true)
                        {
                            if (response.Result != null)
                            {
                                resultStr = response.Result.ToString();
                            }
                        }
                    }
                }, TaskScheduler.FromCurrentSynchronizationContext());
                return resultStr;
            }
            catch (Exception ex)
            {
                return resultStr;
            }
        }
        string BrowserChildEvaluateScriptAsync(string scriptStr)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("function tempFunction() {");
            sb.AppendLine(scriptStr);
            sb.AppendLine("}");
            sb.AppendLine("tempFunction();");
            string resultStr = "";
            try
            {
                var task = browserChild.GetBrowser().GetFrame(browserChild.GetBrowser().GetFrameNames()[0]).EvaluateScriptAsync(sb.ToString());
                task.ContinueWith(t =>
                {
                    if (!t.IsFaulted)
                    {
                        var response = t.Result;
                        if (response.Success == true)
                        {
                            if (response.Result != null)
                            {
                                resultStr = response.Result.ToString();
                            }
                        }
                    }
                }, TaskScheduler.FromCurrentSynchronizationContext());
            }
            catch (Exception ex)
            {
            }
            return resultStr;
        }

        CefSharp.WinForms.ChromiumWebBrowser browserChild = null;
        //判断页面是否显示 “已经完成学习”
        string PanDuanWanCheng()
        {
            if (browserChild != null)
            {
                try
                {
                    ////string strScript = "function GetSpanFinishContent(){return document.getElementById('spanFinishContent').innerHTML}GetSpanFinishContent();";
                    //string strScript = "function GetSpanFinishContent(){return document.getElementById('ScheduleText').innerText}GetSpanFinishContent();";

                    //string result = "";
                    ////string result = browserChild.StringByEvaluatingJavaScriptFromString(strScript);
                    //browserChild.GetBrowser().GetFrame(0).ExecuteJavaScriptAsync("", "", 0);

                    ////MessageBox.Show(result);
                    ////if (result == "恭喜您已完成本文档的学习。")
                    //if (result == "100%")
                    //{
                    //    return "1";
                    //}
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("function tempFunction() {");
                    sb.AppendLine("return document.getElementById('ScheduleText').innerText;");
                    sb.AppendLine("}");
                    sb.AppendLine("tempFunction();");
                    string resultStr = "";
                    var task = browserChild.GetBrowser().GetFrame(browserChild.GetBrowser().GetFrameNames()[0]).EvaluateScriptAsync(sb.ToString());
                    task.ContinueWith(t =>
                    {
                        if (!t.IsFaulted)
                        {
                            var response = t.Result;
                            if (response.Success == true)
                            {
                                if (response.Result != null)
                                {
                                    resultStr = response.Result.ToString();
                                    if (resultStr == "100%")
                                    {
                                        string nowLearnTitle = GetNowLearnTitle();
                                        //Log("课程已完成！" + browserChild.Url.ToString() + "(" + nowLearnTitle + ")");
                                        //完成操作
                                        if (learnWithDataList)
                                        {
                                            BroserChildStarWithDataList();
                                        }
                                        return "1";
                                    }
                                }
                            }
                        }
                        return "0";
                    }, TaskScheduler.FromCurrentSynchronizationContext());
                }
                catch (Exception ex)
                { }
            }
            return "0";
        }
        //开始自动点击 “我在学习”按钮
        private void btnBegin_Click(object sender, EventArgs e)
        {
            if (!timer1.Enabled)
            {
                timer1.Interval = 10000;
                timer1.Enabled = true;
                slbl1.Text = "自动学习：启动";
            }
            else
            {
                timer1.Enabled = false;
                slbl1.Text = "自动学习：未启动";
            }
        }
        //定时执行事件  1：点击“我在学习”按钮 2：已完成当前课程则转至下一课程
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (browserChild != null)
            {
                #region 1：点击“我在学习”按钮
                ////暂时获取不到“我在学习”提示框（后面添加的html元素 ）注释
                ////if (browserChild.DocumentText.IndexOf("RemoveWarningHtml()") > -1) 
                //{
                //新版云学堂没有我在学习按钮了注释相关代码
                //try
                //{
                //    string strScript = "RemoveWarningHtml();";
                //    //browserChild.StringByEvaluatingJavaScriptFromString(strScript);
                //    BrowserChildEvaluateScriptAsync(strScript);
                //}
                //catch (Exception ex)
                //{
                //}
                //} 
                #endregion 1：点击“我在学习”按钮
                #region 2：已完成当前课程则转至下一课程
                if (PanDuanWanCheng() == "1")
                {
                    string nowLearnTitle = GetNowLearnTitle();
                    //Log("课程已完成！" + browserChild.Url.ToString() + "(" + nowLearnTitle + ")");
                    //完成操作
                    if (learnWithDataList)
                    {
                        BroserChildStarWithDataList();
                    }
                }
                #endregion 2：已完成当前课程则转至下一课程
            }
        }
        //下拉框选择跳转网页
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (comboBox1.Text == "主页")
            //{
            //    SetBrowserUrl("http://hongyangsoft.yunxuetang.cn");
            //}
            //else if (comboBox1.Text == "最新知识页")
            //{
            //    SetBrowserUrl("http://hongyangsoft.yunxuetang.cn/knowledgecatalogsearch.htm?sf=UploadDate&s=dc&pi=3");
            //}
            if (comboBox1.Text != "")
            {
                SetBrowserUrl("http://hongyangsoft.yunxuetang.cn/knowledgecatalogsearch.htm?sf=UploadDate&s=dc&pi=" + comboBox1.Text);
            }
            textBox1.Focus();
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void label3_DoubleClick(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                SetBrowserUrl("http://hongyangsoft.yunxuetang.cn/knowledgecatalogsearch.htm?sf=UploadDate&s=dc&pi=" + comboBox1.Text);
            }
            textBox1.Focus();
        }
        //获取课程列表
        private void GetDataList_Click(object sender, EventArgs e)
        {
            Log("获取课程列表");
            if (browser != null)
            {
                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("function tempFunction() {");
                    sb.AppendLine(" return document.body.innerHTML; ");
                    sb.AppendLine("}");
                    sb.AppendLine("tempFunction();");
                    var task = browser.GetBrowser().GetFrame(browser.GetBrowser().GetFrameNames()[0]).EvaluateScriptAsync(sb.ToString());
                    task.ContinueWith(t =>
                    {
                        if (!t.IsFaulted)
                        {
                            var response = t.Result;
                            if (response.Success == true)
                            {
                                if (response.Result != null)
                                {
                                    string resultStr = response.Result.ToString();
                                    Regex r = new Regex("(/knowledge/document/[\\S]*.html)|(/knowledge/video/[\\S]*.html)|(/package/video/[\\S]*.html)|(/package/document/[\\S]*.html)|(/knowledge/scorm/[\\S]*.html)|(/package/scorm/[\\S]*.html)|(/package/ebook/[\\S]*.html)");//构造表达式package/scorm
                                        MatchCollection matches = r.Matches(resultStr);
                                    foreach (Match match in matches)
                                    {
                                        string word = match.Groups["word"].Value;
                                        int index = match.Index;
                                        richTextBox1.AppendText(match.Value.Replace("\"", ""));
                                        richTextBox1.AppendText("\r\n");
                                    }
                                    SetConfig(LastHistroyDataList, richTextBox1.Text);
                                    Log("获取课程列表成功！(添加" + matches.Count.ToString() + "列数据)");
                                    tabControl1.SelectedIndex = 2;
                                }
                            }
                        }
                    }, TaskScheduler.FromCurrentSynchronizationContext());
                }
                catch (Exception ex)
                {
                    Log("获取课程列表失败！(js执行失败)");
                }
            }
            else
            {
                Log("获取课程列表失败！(浏览器获取失败)");
            }
        }
        //登录
        private void btnLogin_Click(object sender, EventArgs e)
        {
            Log("开始登录操作");
            try
            {
                if (browser != null)
                {
                    string strScript = "document.getElementById('txtUserName2').value='" + txtUser.Text.Trim() + "';document.getElementById('txtPassword2').value='" + txtPassword.Text.Trim() + "';document.getElementById('btnLogin2').click();";
                    BrowserEvaluateScriptAsync(strScript);
                    Log("登录操作完成！");
                    SetConfig(UserInfo, txtUser.Text.Trim() + "$" + txtPassword.Text.Trim());
                }
            }
            catch (Exception ex)
            {
                Log("登录失败！");
            }
        }
        bool learnWithDataList = false;
        //开始按列表学习
        private void btnLearnWithDataList_Click(object sender, EventArgs e)
        {
            Log("开始按列表学习！");
            learnWithDataList = !learnWithDataList;
            if (learnWithDataList)
            {
                BroserChildStarWithDataList();
            }
            slbl2.Text = learnWithDataList ? "按课程列表学习状态：启动" : "按课程列表学习状态：未启动";
        }
        //按列表学习
        void BroserChildStarWithDataList()
        {
            if (browserChild == null)
            {
                browserChild = new CefSharp.WinForms.ChromiumWebBrowser("about:blank");
                browserChild.Dock = DockStyle.Fill;//充满窗口  
                this.tabControl1.TabPages[1].Controls.Add(browserChild);//添加到窗口
                string url = GetUrl();
                if (url != null)
                {
                    if (url.StartsWith("/"))
                        url = "http://hongyangsoft.yunxuetang.cn" + url;
                    browserChild.Load(url);
                    tabControl1.SelectedIndex = 1;
                    Log("开始课程" + url);
                }
            }
            else
            {
                string url = GetUrl();
                if (url != null)
                {
                    if (url.StartsWith("/"))
                        url = "http://hongyangsoft.yunxuetang.cn" + url;
                    browserChild.Load(url);
                    tabControl1.SelectedIndex = 1;
                    Log("开始课程" + url);
                }
            }
        }
        void SetBrowserChildUrl(string url)
        {
            if (browserChild == null)
            {
                browserChild = new CefSharp.WinForms.ChromiumWebBrowser("about:blank");
                browserChild.Dock = DockStyle.Fill;//充满窗口  
                this.tabControl1.TabPages[1].Controls.Add(browserChild);//添加到窗口
                if (url != null)
                {
                    url = "http://hongyangsoft.yunxuetang.cn" + url;
                    browserChild.Load(url);
                    tabControl1.SelectedIndex = 1;
                }
            }
            else
            {
                if (url != null)
                {
                    url = "http://hongyangsoft.yunxuetang.cn" + url;
                    browserChild.Load(url);
                    tabControl1.SelectedIndex = 1;
                }
            }
        }
        /// <summary>
        /// 学习Url的列表
        /// </summary>
        List<string> urlList = new List<string>();
        /// <summary>
        /// 获取一个 列表学习的Url
        /// </summary>
        /// <returns></returns>
        string GetUrl()
        {
            string rTxtStr = richTextBox1.Text;
            string[] urlArr = rTxtStr.Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            AppendUrlList(urlArr);
            if (urlList != null && urlList.Count > 0)
            {
                string rValue = urlList[0];
                urlList.RemoveAt(0);
                richTextBox1.Text = richTextBox1.Text.Replace(rValue + "\r\n", "");
                richTextBox1.Text = richTextBox1.Text.Replace(rValue + "\n", "");
                richTextBox1.Text = richTextBox1.Text.Replace(rValue + "\r", "");
                richTextBox1.Text = richTextBox1.Text.Replace(rValue + "\r\n\r\n", "");
                richTextBox1.Text = richTextBox1.Text.Replace(rValue + "\r\r", "");
                richTextBox1.Text = richTextBox1.Text.Replace(rValue + "\n\n", "");
                return rValue;
            }
            else
            {
                //没有要学习的内容了
                if (learnWithDataList)
                {
                    learnWithDataList = false;
                    Log("停止按列表学习！(没有可用的学习列表)");
                    slbl2.Text = learnWithDataList ? "按课程列表学习状态：启动" : "按课程列表学习状态：未启动";
                }
                if (timer1.Enabled)
                {
                    timer1.Enabled = false;
                    Log("自动点击我在学习：停止！(没有可用的学习列表)");
                    slbl1.Text = "自动点击我在学习：未启动";
                }
                MessageBox.Show("没有可用的学习列表！");
            }
            return null;
        }
        /// <summary>
        /// 把richTextBox1获取到的url添加到urlList
        /// </summary>
        /// <param name="strArr"></param>
        /// <returns></returns>
        bool AppendUrlList(string[] strArr)
        {
            foreach (string str in strArr)
            {
                if (!urlList.Contains(str))
                {
                    urlList.Add(str);
                }
            }
            return true;
        }
        /// <summary>
        /// 添加日志
        /// </summary>
        /// <param name="log"></param>
        void Log(string log)
        {
            rTxtLog.AppendText(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "：" + log);
            rTxtLog.AppendText("\r\n");
            //写日志
            try
            {
                File.AppendAllText(("" + DateTime.Now.ToString("yyyyMMdd") + ".log"), DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "：" + log);
            }
            catch (Exception err)
            {
                File.AppendAllText(("" + DateTime.Now.ToString("yyyyMMdd") + ".log"), DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "：" + log);
            }
        }
        /// <summary>
        /// 读取配置文件
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        string GetConfig(string fileName)
        {
            string rValue = "";
            try
            {
                rValue = File.ReadAllText(fileName, Encoding.Default);
            }
            catch (Exception err)
            {
            }
            return rValue;
        }
        /// <summary>
        /// 设置配置文件
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="writeValue"></param>
        /// <returns></returns>
        bool SetConfig(string fileName, string writeValue)
        {
            bool rResult = false;
            try
            {
                File.WriteAllText(fileName, writeValue);
                rResult = true;
            }
            catch (Exception err)
            {
            }
            return rResult;
        }
        /// <summary>
        /// 获取正在学习的标题
        /// </summary>
        /// <returns></returns>
        string GetNowLearnTitle()
        {
            string nowLearnTitle = "";
            try
            {
                string strScript = "function GetNowLearnTitle(){return document.getElementById('lblTitle').innerText}GetNowLearnTitle();";
                //nowLearnTitle = browserChild.StringByEvaluatingJavaScriptFromString(strScript);
                BrowserChildEvaluateScriptAsync(strScript);
            }
            catch (Exception ex)
            {
            }
            if (nowLearnTitle != "")
            {
                slbl3.Text = nowLearnTitle;
            }
            return nowLearnTitle;
        }

        private void txtUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                txtPassword.Select();
                txtPassword.Focus();
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                btnLogin_Click(null, null);
            }
        }
        /// <summary>
        /// 清空学习列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiClear_Click(object sender, EventArgs e)
        {
            urlList.Clear();
            richTextBox1.Text = "";
        }
        /// <summary>
        /// 重载学习列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiReloadDataList_Click(object sender, EventArgs e)
        {
            string rTxtStr = richTextBox1.Text;
            string[] urlArr = rTxtStr.Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            AppendUrlList(urlArr);
        }

        private void tsmiLoadHIstroyDataList_Click(object sender, EventArgs e)
        {
            richTextBox1.AppendText(GetConfig(LastHistroyDataList));
        }
        //保存学习列表
        private void tsmiSaveHistroyDataList_Click(object sender, EventArgs e)
        {
            string lastHistroyDataStr = richTextBox1.Text;
            if (browserChild != null && !string.IsNullOrEmpty(browserChild.Address)) { lastHistroyDataStr = browserChild.Address + "\r\n" + lastHistroyDataStr; }
            SetConfig(LastHistroyDataList, lastHistroyDataStr);
        }
        //音量修改
        private void btnVolume_Click(object sender, EventArgs e)
        {
            uint _savedVolume;
            APIControl.VolumeControl.waveOutGetVolume(IntPtr.Zero, out _savedVolume);
            if (_savedVolume == 0)
            {
                APIControl.VolumeControl.waveOutSetVolume(IntPtr.Zero, 0xFFFFFFFF);
            }
            else
            {
                APIControl.VolumeControl.waveOutSetVolume(IntPtr.Zero, 0);
            }
        }

        private void btnLearnThis_Click(object sender, EventArgs e)
        {

        }

        bool thisFormOnShow = true;
        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (thisFormOnShow)
            {
                //this.ShowInTaskbar = false;
                //this.Hide();
                //this.WindowState = FormWindowState.Minimized;
                //this.TopMost = false;
                this.TopLevel = false;
                thisFormOnShow = false;
            }
            else
            {
                //this.ShowInTaskbar = true;
                //this.Show();
                //this.WindowState = FormWindowState.Normal;
                //this.TopMost = true;
                this.TopLevel = true;
                this.TopMost = true;
                this.TopMost = false;
                thisFormOnShow = true;
            }
        }
        //刷新按钮
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                if (browser != null)
                {
                    browser.Load(browser.Address);
                }
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                if (browserChild != null)
                {
                    browserChild.Load(browserChild.Address);
                }
            }
            else if (tabControl1.SelectedIndex == 4)
            {
                if (cwbPackage != null)
                {
                    cwbPackage.Load(cwbPackage.Address);
                }
            }
        }
        /// <summary>
        /// 课程包学习列表
        /// </summary>
        List<string> PackageUrlList = new List<string>();
        //获取课程包学习列表
        private void btnGetPackageDataList_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
            Log("获取课程包学习列表");
            if (browser != null)
            {
                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("function tempFunction() {");
                    sb.AppendLine(" return document.body.innerHTML; ");
                    sb.AppendLine("}");
                    sb.AppendLine("tempFunction();");
                    var task = browser.GetBrowser().GetFrame(browser.GetBrowser().GetFrameNames()[0]).EvaluateScriptAsync(sb.ToString());
                    task.ContinueWith(t =>
                    {
                        if (!t.IsFaulted)
                        {
                            var response = t.Result;
                            if (response.Success == true)
                            {
                                if (response.Result != null)
                                {
                                    string resultStr = response.Result.ToString();
                                    Regex r = new Regex("(/knowledge/package/[\\S]*.html)");//构造表达式package/scorm
                                    MatchCollection matches = r.Matches(resultStr);
                                    foreach (Match match in matches)
                                    {
                                        string word = match.Groups["word"].Value;
                                        int index = match.Index;
                                        //richTextBox1.AppendText(match.Value.Replace("\"", ""));
                                        //richTextBox1.AppendText("\r\n");
                                        if (!PackageUrlList.Contains(match.Value.Replace("\"", "")))
                                        {
                                            PackageUrlList.Add(match.Value.Replace("\"", ""));
                                        }
                                    }
                                    SetConfig(LastHistroyDataList, richTextBox1.Text);
                                    Log("获取课程包学习列表成功！(添加" + matches.Count.ToString() + "列数据)");

                                    tabControl1.SelectedIndex = 4;
                                    GetPackageDataList();
                                }
                            }
                        }
                    }, TaskScheduler.FromCurrentSynchronizationContext());
                }
                catch (Exception ex)
                {
                    Log("获取课程包学习列表失败！(js执行失败)");
                }
            }
            else
            {
                Log("获取课程包学习列表失败！(浏览器获取失败)");
            }
        }
        ChromiumWebBrowser cwbPackage = null;
        void GetPackageDataList()
        {
            if (PackageUrlList != null && PackageUrlList.Count > 0)
            {
                //for (int i = 0; i < PackageUrlList.Count; i++)
                {
                    string url = PackageUrlList[0];
                    PackageUrlList.RemoveAt(0);
                    if (!string.IsNullOrEmpty(url))
                    {
                        if (url.StartsWith("/"))
                            url = "http://hongyangsoft.yunxuetang.cn" + url;
                        if (cwbPackage == null)
                        {
                            //实例化控件
                            cwbPackage = new CefSharp.WinForms.ChromiumWebBrowser(url);
                            //设置停靠方式
                            cwbPackage.Dock = DockStyle.Fill;
                            //加入到当前窗体中
                            this.tabControl1.TabPages[4].Controls.Add(cwbPackage);
                            cwbPackage.FrameLoadEnd += CwbPackage_FrameLoadEnd;
                        }
                        else
                        {
                            cwbPackage.Load(url);
                        }
                    }
                }
            }
            else
            {
                this.tabControl1.TabPages[4].Controls.Remove(cwbPackage);
                cwbPackage.Dispose();
                cwbPackage = null;
                MessageBox.Show("已完成获取课程包学习列表！");
            }
        }

        private void CwbPackage_FrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        {
            Log("获取课程包学习列表内容");
            if (browser != null)
            {
                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("function tempFunction() {");
                    sb.AppendLine(" return document.body.innerHTML; ");
                    sb.AppendLine("}");
                    sb.AppendLine("tempFunction();");
                    var task = cwbPackage.GetBrowser().GetFrame(cwbPackage.GetBrowser().GetFrameNames()[0]).EvaluateScriptAsync(sb.ToString());
                    task.ContinueWith(t =>
                    {
                        if (!t.IsFaulted)
                        {
                            var response = t.Result;
                            if (response.Success == true)
                            {
                                if (response.Result != null)
                                {
                                    string resultStr = response.Result.ToString();
                                    Regex r = new Regex("(/knowledge/document/[\\S]*.html)|(/knowledge/video/[\\S]*.html)|(/package/video/[\\S]*.html)|(/package/document/[\\S]*.html)|(/knowledge/scorm/[\\S]*.html)|(/package/scorm/[\\S]*.html)|(/package/ebook/[\\S]*.html)");//构造表达式package/scorm
                                    MatchCollection matches = r.Matches(resultStr);
                                    foreach (Match match in matches)
                                    {
                                        string word = match.Groups["word"].Value;
                                        int index = match.Index;
                                        richTextBox1.AppendText(match.Value.Replace("\"", ""));
                                        richTextBox1.AppendText("\r\n");
                                    }
                                    SetConfig(LastHistroyDataList, richTextBox1.Text);
                                    Log("获取课程包学习列表内容成功！(添加" + matches.Count.ToString() + "列数据)");
                                    tabControl1.SelectedIndex = 4;
                                    var ta = Task.Run(async delegate
                                    {
                                        await Task.Delay(500);
                                        GetPackageDataList();
                                        //Console.WriteLine("5秒后会执行此输出语句");
                                        //return 42;
                                    });
                                }
                            }
                        }
                    }
                    //, TaskScheduler.FromCurrentSynchronizationContext());
                , CancellationToken.None
                , TaskContinuationOptions.None
                , TaskScheduler.Current);
                }
                catch (Exception ex)
                {
                    Log("获取课程包学习列表内容失败！(js执行失败)");
                }
            }
            else
            {
                Log("获取课程包学习列表内容失败！(浏览器获取失败)");
            }
            //throw new NotImplementedException();
        }
    }
}
