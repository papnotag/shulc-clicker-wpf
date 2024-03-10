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

namespace shulc_clicker_wpf
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            fMain.Content = new MainMenu();
            WindowState = WindowState.Maximized;
            WindowStyle = WindowStyle.None;
        }

        private void wMainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if(fMain.Content is Game)
            {
                Game game = fMain.Content as Game;
                game.addScs();
            }
        }
    }
}
