using Newtonsoft.Json;
using SpeechLib;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Speech.Synthesis;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace 复制粘贴plus
{
    public partial class Form1 : Form
    {
        private KeyboardHook k_hook;
        private Dictionary<int, List<Keys>> keyhookHeaderitem = new Dictionary<int, List<Keys>>()
        {
         { 0,new List<Keys>(){ Keys.Control} },
         { 1,new List<Keys>(){ Keys.Alt} },
         { 2,new List<Keys>(){ Keys.Control,Keys.Alt} }
        };
        private Keys keyhookbody = Keys.Q;
        private List<Keys> keyhookHeaderlist = null;

        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            k_hook = new KeyboardHook();
            k_hook.KeyDownEvent += new KeyEventHandler(hook_KeyDown);
            k_hook.Start();
            InitializekeyhookHeader(keyhookHeaderitem);
            keyhookHeaderlist = new List<Keys>(keyhookHeaderitem[0]);
        }
        private void hook_KeyDown(object sender, KeyEventArgs e)
        {
            if ((Keys)e.KeyValue == keyhookbody && DetermineTheKey(Control.ModifierKeys, keyhookHeaderlist))// 
            {
                if (string.IsNullOrEmpty(this.oldstr.Text))
                {
                    MessageBox.Show("请提供替换的字符！");
                    return;
                }
                rp(
                    this.oldstrcbxESC.Checked ? Regex.Unescape(this.oldstr.Text) : this.oldstr.Text,
                    this.newstrcbxESC.Checked ? Regex.Unescape(this.newstr.Text) : this.newstr.Text,
                    () => {
                        this.shearWall.Text = "时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "内容：" + Clipboard.GetText();
                    }
                    );
            }
        }
        static void rp(string oldstr, string newstr, Action action = null)
        {

            nrClipboardset(() => { Clipboard.SetText(Clipboard.GetText().Replace(oldstr, newstr)); if (action != null) action(); });
        }
        static void nrClipboardset(Action func)
        {
            Thread th = new Thread(() =>
            {
                func();
            });
            th.IsBackground = true;
            th.TrySetApartmentState(ApartmentState.STA);
            th.Start();
            th.Join();
        }

        private void keyhook_KeyDown(object sender, KeyEventArgs e)
        {
            this.keyhookbody = (Keys)e.KeyValue;
            Showkeyhook();
        }

        private void keyhookHeader_SelectedIndexChanged(object sender, EventArgs e)
        {
            keyhookHeaderlist = new List<Keys>(keyhookHeaderitem[((KeyValuePair<int, string>)this.keyhookHeader.SelectedItem).Key]);
            Showkeyhook();
        }

        private void InitializekeyhookHeader(Dictionary<int, List<Keys>> data)
        {
            Dictionary<int, string> list = new Dictionary<int, string>();
            foreach (var item in data)
            {
                list.Add(item.Key, string.Join("+", item.Value.Select<Keys, string>((i, b) => (i).ToString())));
            }
            BindingSource bs = new BindingSource();
            bs.DataSource = list;
            this.keyhookHeader.DataSource = bs;
            this.keyhookHeader.ValueMember = "Key";
            this.keyhookHeader.DisplayMember = "Value";
        }
        private void Showkeyhook()
        {
            //var obj=this.keyhookHeader.SelectedItem.ObjCast(new { Key = 0, Value = "str" });
            this.keyhook.Text = $@"{((KeyValuePair<int, string>)this.keyhookHeader.SelectedItem).Value}+{keyhookbody}";
        }

        private bool DetermineTheKey(Keys key, List<Keys> keys)
        {
            Keys newkeys = Keys.None;
            keys.ForEach(item =>
            {
                newkeys |= item;
            });
            return newkeys == key;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //取消关闭窗口
            e.Cancel = true;
            //最小化主窗口
            this.WindowState = FormWindowState.Minimized;
            //不在系统任务栏显示主窗口图标
            this.ShowInTaskbar = false;
            //提示气泡
            notifyIcon1.ShowBalloonTip(2000, "最小化到托盘", "程序已经缩小到托盘，单击打开程序。", ToolTipIcon.Info);
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.WindowState == FormWindowState.Minimized)
                {
                    //还原窗体
                    this.WindowState = FormWindowState.Normal;
                    //系统任务栏显示图标
                    this.ShowInTaskbar = true;
                }
                //激活窗体并获取焦点
                this.Activate();
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Task t1 = new Task(() =>
            {
                Thread.CurrentThread.IsBackground = false;
                //实例化

                SpVoice vo = new SpVoice();
                //速度 值范围（-10到10速度递增）
                vo.Rate = trackBar2.Value;
                //音量 值范围（0到100音量递增）
                vo.Volume = trackBar1.Value * 10;

                
                //声音
                vo.Voice = vo.GetVoices().Item(0);//china
                vo.Speak(this.textBox1.Text, SpeechVoiceSpeakFlags.SVSFlagsAsync);
                Thread.Sleep(1000);
                vo.Voice = vo.GetVoices().Item(1);//english
                vo.Speak(ZhToEn(this.textBox1.Text), SpeechVoiceSpeakFlags.SVSFlagsAsync);
                //播放
                //SpeechVoiceSpeakFlags.SVSFPurgeBeforeSpeak 打断前面的声音播放当前声音
                //SpeechVoiceSpeakFlags.SVSFlagsAsync 异步播放
                //vo.Speak(this.textBox1.Text, SpeechVoiceSpeakFlags.SVSFlagsAsync);
                //立即停止可以用
                //vo.Speak(string.Empty, SpeechVoiceSpeakFlags.SVSFPurgeBeforeSpeak);
                //暂停
                //vo.Pause();
                //继续
                //vo.Resume();
                //判断播放完毕
                //vo.Status.RunningState = DotNetSpeech.SpeechRunState.SRSEDone;

                //using (SpeechSynthesizer speech = new SpeechSynthesizer())
                //{
                //    speech.Rate = trackBar2.Value;  //语速
                //    speech.Volume = trackBar1.Value*10;  //音量
                //    speech.Speak(this.textBox1.Text);
                //}
            });
            t1.Start();
        }

        // 计算MD5值
        public string EncryptString(string str)
        {
            MD5 md5 = MD5.Create();
            // 将字符串转换成字节数组
            byte[] byteOld = Encoding.UTF8.GetBytes(str);
            // 调用加密方法
            byte[] byteNew = md5.ComputeHash(byteOld);
            // 将加密结果转换为字符串
            StringBuilder sb = new StringBuilder();
            foreach (byte b in byteNew)
            {
                // 将字节转换成16进制表示的字符串，
                sb.Append(b.ToString("x2"));
            }
            // 返回加密的字符串
            return sb.ToString();
        }

        public void GetNameValueCollection<T>(T Obj,ref NameValueCollection nameValue)
        {
            Type type = typeof(T);
            foreach (var prop in type.GetProperties())
            {
                var key = prop.Name;
                var keyvalue = type.GetProperty(key).GetValue(Obj);
                nameValue.Add(key, keyvalue as string);
            }
        }

        static readonly Uri _baseAddress = new Uri("https://fanyi-api.baidu.com/");
        static readonly Uri _address = new Uri(_baseAddress, "/api/trans/vip/translate");
        private string ZhToEn(string query)
        {
            #region 定义参数
            string secretKey = "hAE5szu8kNyWkMGIbP_o",
            appid = "20220824001317649",
            q = query,
            from = "zh",
            to = "en",
            salt = new Random().Next(100000).ToString(),
            sign = EncryptString(appid + q + salt + secretKey);

            var data = new
            {
                q,
                from,
                to,
                appid,
                salt,
                sign,
            };
            var valuesout = new NameValueCollection();// 所加参数
            GetNameValueCollection(data,ref valuesout);

            #endregion

            WebClient webClient = new WebClient();
            webClient.Headers.Add(HttpRequestHeader.ContentType, "application/x-www-form-urlencoded");
            webClient.Encoding = Encoding.UTF8;
            //webClient.UploadValuesCompleted += (send, es) =>
            //{
            //    if (es.Result != null)
            //    {
            //        string str = Encoding.UTF8.GetString(es.Result);
            //        var test = JsonConvert.DeserializeObject<BaiduTranslate>(str);
            //        if (test!=null)
            //        {
            //            shearWall.Text = test.trans_result[0].dst;
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show(es.Error.Message);
            //    }
            //};
            string result = Encoding.UTF8.GetString(webClient.UploadValues(_address, "POST", valuesout));
            return JsonConvert.DeserializeObject<BaiduTranslate>(result).trans_result[0].dst;
        }
    }
}
