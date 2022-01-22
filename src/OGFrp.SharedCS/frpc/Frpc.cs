using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.ComponentModel;
using System.Diagnostics;

namespace OGFrp.UI
{
    public class Frpc
    {

        string frpcLoca = "";
        string iniLoca = "";

        /// <summary>
        /// 创建一个frpc实例对象
        /// </summary>
        public Frpc() { }

        /// <summary>
        /// 创建一个frpc实例对象
        /// </summary>
        /// <param name="frpcLoca">frpc.exe的位置</param>
        public Frpc(string frpcLoca)
        {
            this.frpcLoca = frpcLoca;
        }

        /// <summary>
        /// 创建一个frpc实例对象
        /// </summary>
        /// <param name="frpcLoca">frpc.exe的位置</param>
        /// <param name="iniLoca">frpc.ini的位置</param>
        public Frpc(string frpcLoca, string iniLoca)
        {
            this.frpcLoca = frpcLoca;
            this.iniLoca = iniLoca;
        }

        /// <summary>
        /// 设置frpc.exe的路径
        /// </summary>
        /// <param name="frpcLoca"></param>
        public void setFrpcLoca(string frpcLoca)
        {
            this.frpcLoca = frpcLoca;
        }

        /// <summary>
        /// 设置frpc.ini文件的路径
        /// </summary>
        /// <param name="iniLoca"></param>
        public void setIniLoca(string iniLoca)
        {
            this.iniLoca = iniLoca;
        }

        LogForm LogForm = new LogForm();

        /// <summary>
        /// Frpc进程
        /// </summary>
        Process p_frpc = new Process();

        /// <summary>
        /// fprc是否已启动
        /// </summary>
        public bool isOn = false;

        System.Windows.Forms.Form invoker = new System.Windows.Forms.Form
        {
            Width = 0,
            Height = 0,
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None,
            ShowInTaskbar = false
        };

        /// <summary>
        /// 获取日志的thread
        /// </summary>
        Thread LogTd;

        public int Start()
        {
            if (isOn)
                return -1;
            try
            {
                invoker.Show();
                invoker.Hide();
                p_frpc.StartInfo.FileName = this.frpcLoca;
                p_frpc.StartInfo.Arguments = "-c " + this.iniLoca;
                p_frpc.StartInfo.CreateNoWindow = true;
                p_frpc.StartInfo.UseShellExecute = false;
                p_frpc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                p_frpc.StartInfo.RedirectStandardOutput = true;
                p_frpc.Start();
                isOn = true;
                this.LogForm = new LogForm();
                Thread we = new Thread(delegate ()
                {
                    p_frpc.WaitForExit();
                    this.isOn = false;
                    LogTd.Abort();
                    try
                    {
                        LogForm.Invoke(new EventHandler(delegate
                        {
                            LogForm.Dispose();
                        }));
                    }
                    catch (Exception ex)
                    {
                        if (!(ex.GetType().ToString() == "System.InvalidOperationException"))
                        {

                        }
                    }
                });
                we.Start();
                LogTd = new Thread(delegate ()
                {
                    while (true)
                    {
                        try
                        {
                            this.LogForm.textBox1.Text += (char)p_frpc.StandardOutput.Read();
                        }
                        finally { }
                    }
                });
                LogTd.Start();
                return 0;
            }
            catch
            {
                return -1;
            }
        }

        public int Kill()
        {
            if (!isOn)
                return -1;
            try
            {
                p_frpc.Kill();
                isOn = false;
                return 0;
            }
            catch
            {
                return -1;
            }
        }

        public void ShowLog()
        {
            this.LogForm.Show();
        }
    }
}
