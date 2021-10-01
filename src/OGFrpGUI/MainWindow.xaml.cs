using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OGFrpCore
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {

        /// <summary>
        /// 多语言资源
        /// </summary>
        private Assets Assets = new Assets();

        /// <summary>
        /// 当前设置的语言
        /// </summary>
        string lang = "zh-cn";

        private int WindowInitialize()
        {
            try
            {
                switch (lang)
                {
                    case "zh-cn":
                        var CrtAsset = Assets.zh_cn;
                        
                        break;
                    default:
                        break;
                }
            }
            catch (Exception)
            {
                return -1;
            }
            return 0;
        }

        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
