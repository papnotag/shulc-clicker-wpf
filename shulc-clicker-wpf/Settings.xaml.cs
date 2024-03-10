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
    /// Logika interakcji dla klasy Settings.xaml
    /// </summary>
    public partial class Settings : Page
    {
        bool[] options = { true, false };

        public Settings()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new MainMenu());
        }

        private void Option_Clicked(object sender, MouseButtonEventArgs e)
        {
            Border border = sender as Border;
            Label label = border.Child as Label;
            int id = Convert.ToInt32(border.Tag.ToString());
            options[id] = !options[id];
            if (options[id] == true)
            {
                label.Foreground = new SolidColorBrush(Colors.LightGreen);
            } else
            {
                label.Foreground = new SolidColorBrush(Colors.IndianRed);
            }
            if(label.Tag.ToString() == "fullscreen")
            {
                if (options[0] == true)
                {
                    Application.Current.MainWindow.Dispatcher.Invoke(() =>
                    {
                        Application.Current.MainWindow.WindowState = WindowState.Maximized;
                        Application.Current.MainWindow.WindowStyle = WindowStyle.None;

                    });
                }
                else
                {
                    Application.Current.MainWindow.Dispatcher.Invoke(() =>
                    {
                        Application.Current.MainWindow.WindowState = WindowState.Normal;
                        Application.Current.MainWindow.WindowStyle = WindowStyle.ToolWindow;
                    });
                }
            }
        }
    }
}
