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
        MainWindow m;
        public MainMenu(MainWindow m)
        {
            InitializeComponent();
            this.m = m;
        }

        private void pvc_Click(object sender, RoutedEventArgs e)
        {
            m.setComputer(true);
            NavigationService.Navigate(m);
        }

        private void pvp_Click(object sender, RoutedEventArgs e)
        {
            m.setComputer(false);
            NavigationService.Navigate(m);
        }
    }
}
