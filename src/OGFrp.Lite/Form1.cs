using System;
using System.Activities.Statements;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualBasic;
using OGFrp.UI;

namespace OGFrp.Lite
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Net Net = new Net();
        Config Config = new Config();

        string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\OGFrp";

        void DownloadFrpc()
        {
            try
            {
                Net.Download("https://api.ogfrp.cn/win/frpc.exe", path + "\\frpc.exe");
            }
            catch (Exception)
            {
                this.Invoke(new EventHandler(delegate
                {
                    if (!(MessageBox.Show("下载frpc.exe失败，确定要继续吗？（可能会导致一些未知错误）", "OGFrp", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK))
                    {
                        Environment.Exit(0);
                    }
                }));
            }
            this.Invoke(new EventHandler(delegate
            {
                this.Button1.Text = "启动隧道";
                this.Button1.Enabled = true;
                this.Button2.Enabled = true;
            }));
            return;
        }

        void reDownloadFrpc()
        {
            try
            {
                Net.Download("https://api.ogfrp.cn/win/frpc.exe", path + "\\frpc.exe", true);
            }
            catch (Exception ex)
            {
                this.Invoke(new EventHandler(delegate
                {
                    if (MessageBox.Show("下载frpc.exe失败！\nDetail:" + ex.ToString(), "OGFrp", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        Environment.Exit(0);
                    }
                }));
            }
            this.Invoke(new EventHandler(delegate
            {
                this.Button2.Text = "重新下载frpc.exe";
                this.Button1.Enabled = true;
                this.Button2.Enabled = true;
            }));
            return;
        }

        private int serverToId(string server)
        {
            switch (server)
            {
                case "hk1.ogfrp.cn":
                    return 1;
                case "sh1.ogfrp.cn":
                    return 2;
                default:
                    return 0;
            }
        }

        private int launchFrpc(string token, string server)
        {
            try
            {
                File.WriteAllText(Config.Path + "\\frpc.ini", Net.Get("https://ogfrp.cn/api/?action=getconf&token=" + this.TextBox1.Text + "&node=" + serverToId(server)));
                Interaction.Shell(Config.Path + "\\frpc.exe -c \"" + Config.Path + "\\frpc.ini\"", AppWinStyle.NormalFocus);
                this.Hide();
                Interaction.MsgBox("隧道启动成功！", MsgBoxStyle.Information, "OGFrp");
                Environment.Exit(0);
            }
            catch (Exception ex)
            {
                Interaction.MsgBox("启动失败！\r\nDetail:" + ex.ToString(), MsgBoxStyle.Critical, "OGFrp");
                return -1;
            }
            return 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Config.CreateFolder();
            Config.loadAccessToken(this.TextBox1);
            this.ComboBox1.Text = "hk1.ogfrp.cn";
            this.Button1.Enabled = false;
            this.Button2.Enabled = false;
            this.Button1.Text = "正在下载frpc.exe";
            var downloadfrpc = new Thread(DownloadFrpc);
            downloadfrpc.Start();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Config.writeAccessToken(this.TextBox1.Text);
            launchFrpc(this.TextBox1.Text, this.ComboBox1.Text);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Button1.Enabled = false;
            this.Button2.Enabled = false;
            this.Button2.Text = "正在下载";
            var downloadfrpc = new Thread(reDownloadFrpc);
            downloadfrpc.Start();
        }
    }
}
