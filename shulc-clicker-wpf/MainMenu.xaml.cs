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
    /// Logika interakcji dla klasy MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page
    {
        public MainMenu()
        {
            InitializeComponent();
            Border[] borders = gMiddleMenu.Children.OfType<Border>().ToArray();
            foreach(Border border in borders)
            {
                border.MouseLeftButtonDown += changeScene;
            }
        }

        private void changeScene(object sender, RoutedEventArgs e)
        {
            Border b = sender as Border;
            Label l = b.Child as Label;
            string content = l.Content.ToString();

            switch(content)
            {
                case "PLAY":
                    NavigationService.Navigate(new Game());
                    break;
                case "SETTINGS":
                    NavigationService.Navigate(new Settings());
                    break;
                case "CREDITS":
                    NavigationService.Navigate(new Credits());
                    break;
            }
        }

        private void Exit_Click(object sender, MouseButtonEventArgs e)
        {

            Application.Current.MainWindow.Dispatcher.Invoke(() =>
                {
                    Application.Current.MainWindow.Close();
                });
            
        }
    }
}
