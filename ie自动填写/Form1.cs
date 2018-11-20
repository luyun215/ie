using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ie自动填写
{
    public partial class Form1 : Form
    {
        private string[] s;
        private string webaddr;
        private string webuserid;
        private string webpassword;
        private string userid;
        private string password;
        private string webclick;
        public Form1(string[] p)
        {
            InitializeComponent();
            s = p;                        
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.textBox1.Text=(s[0]);
           webaddr=s[0].Substring(0, s[0].IndexOf("="));
            s[0] = s[0].Remove(0, s[0].IndexOf("=")+1);
            webuserid= s[0].Substring(0, s[0].IndexOf("="));
            s[0] = s[0].Remove(0, s[0].IndexOf("=") + 1);
            userid = s[0].Substring(0, s[0].IndexOf("="));
            s[0] = s[0].Remove(0, s[0].IndexOf("=") + 1);
            webpassword = s[0].Substring(0, s[0].IndexOf("="));
            s[0] = s[0].Remove(0, s[0].IndexOf("=") + 1);
            password = s[0].Substring(0, s[0].IndexOf("="));
            s[0] = s[0].Remove(0, s[0].IndexOf("=") + 1);
            webclick = s[0];
            SHDocVw.InternetExplorer ie = new SHDocVw.InternetExplorer();
            ie.DocumentComplete += ie_DocomentComplete;
            ie.Navigate(webaddr);
            ie.Visible = true;
            compWait();
            mshtml.HTMLDocument doc = ie.Document;
            doc.getElementById(webuserid).innerText = userid;
            doc.getElementById(webpassword).innerText = password;
            System.Threading.Thread.Sleep(1000);
            doc.getElementById(webclick).click();
            System.Environment.Exit(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SHDocVw.InternetExplorer ie = new SHDocVw.InternetExplorer();
            ie.DocumentComplete += ie_DocomentComplete;
            ie.Navigate("http://192.168.32.121/");
            ie.Visible = true;
            compWait();
            mshtml.HTMLDocument doc = ie.Document;
            doc.getElementById("username").innerText = "admin";
            doc.getElementById("password").innerText = "wo123456";
            System.Threading.Thread.Sleep(1000);
            doc.getElementById("ulgin").click();
        }

        private bool ie_read = false;
        private void ie_DocomentComplete(object pDisp, ref object URL) //加载完成事件
        {
            ie_read = true;
        }

        private void compWait() //等待，直到加载完成
        {
            while (ie_read != true)
            {
                Application.DoEvents();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            SHDocVw.InternetExplorer ie = new SHDocVw.InternetExplorer();
            ie.DocumentComplete += ie_DocomentComplete;
            ie.Navigate("http://192.168.32.121/");
            ie.Visible = true;
            compWait();
            mshtml.HTMLDocument doc = ie.Document;
            mshtml.IHTMLElementCollection userids = doc.getElementsByName("username");
            foreach (mshtml.IHTMLElement userid in userids)
            {
                userid.innerText = "admin";
            }
            mshtml.IHTMLElementCollection passwords = doc.getElementsByName("password");
            foreach (mshtml.IHTMLElement password in passwords)
            {
                password.innerText = "wo123456";
            }
            mshtml.IHTMLElementCollection syaincds = doc.getElementsByName("syaincd");
            foreach (mshtml.IHTMLElement syaincd in syaincds)
            {
                syaincd.innerText = "0";
            }
            mshtml.IHTMLElementCollection logins = doc.getElementsByName("ulgin");
            foreach (mshtml.IHTMLElement login in logins)
            {
                login.click();
            }

            System.Threading.Thread.Sleep(3000);
            mshtml.IHTMLElementCollection tencds = doc.getElementsByName("ulgin");
            foreach (mshtml.IHTMLElement tencd in tencds)
            {
                tencd.click();
            }
        }
    }
}
