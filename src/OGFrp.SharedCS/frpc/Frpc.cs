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
        /// <param name="frpcLoca">frpc.exe的位置</param>
        public Frpc(string frpcLoca)
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

        Process p_frpc = new Process();

        /// <summary>
        /// fprc是否已启动
        /// </summary>
        bool isOn = false;

        public int Start()
        {
            if (isOn)
                return -1;
            try
            {
                p_frpc.StartInfo.FileName = this.frpcLoca;
                p_frpc.StartInfo.Arguments = "-c " + this.iniLoca;
                p_frpc.StartInfo.CreateNoWindow = false;
                p_frpc.StartInfo.UseShellExecute = false;
                p_frpc.Start();
                isOn = true;
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

        public string getLog()
        {
            return p_frpc.StandardOutput.ReadToEnd();
        }
    };
}
