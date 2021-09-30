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
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace OGFrpCore
{
    /// <summary>
    /// WelcomeScreen.xaml 的交互逻辑
    /// </summary>
    public partial class WelcomeScreen : UserControl
    {

        void MainGrid_Load()
        {
            this.lb_Welcome.Content = Assets
        }

        public WelcomeScreen()
        {
            InitializeComponent();
        }

        private void bt_Letsgo_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
