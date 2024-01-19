using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace tictactoe
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page
    {
        Board m;
        MainWindow mw;
        public MainMenu(Board m, MainWindow mw)
        {
            InitializeComponent();
            this.m = m;
            this.mw = mw;
        }

        private void pvc_Click(object sender, RoutedEventArgs e)
        {
            m.setComputer(true);
            mw.Main.Content = m;
        }

        private void pvp_Click(object sender, RoutedEventArgs e)
        {
            m.setComputer(false);
            mw.Main.Content= m;
        }
    }
}
