using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
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
    /// Logika interakcji dla klasy Game.xaml
    /// </summary>
    public partial class Game : Page
    {
        bool epileptic = false;
        ulong objective = 2137000;
        ulong scoin = 0;
        ulong kremowkas = 0;
        ulong ppc = 1;
        Color[] colors = {Colors.Gray, Colors.Orange, Colors.Yellow, Colors.Aqua, Colors.Brown, Colors.Indigo, Colors.Aquamarine, Colors.Blue, Colors.LightBlue };
        int color_index = 0;
        public Game()
        {
            InitializeComponent();
        }

        private void Menu_Button_Click(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new MainMenu());
        }

        public void addScs()
        {
            scoin += ppc;
            if(!epileptic)
            {
                color_index++;
                if (color_index >= colors.Length) color_index = 0;
                this.Background = new SolidColorBrush(colors[color_index]);
            }

            refresh_counters();
        }

        private void Next_Level(object sender, MouseButtonEventArgs e)
        {
            if (kremowkas < objective) return; 
        }

        private void refresh_counters()
        {
            scoin_counter.Content = scoin;
            kremowkas_counter.Content = kremowkas;
            ppc_text.Content = "PPC: "+ppc;
        }

        private void Reset(object sender, MouseButtonEventArgs e)
        {
            ppc = 1;
            scoin = 0;
            kremowkas = 0;
            refresh_counters();
            this.Background = new SolidColorBrush(Colors.Gray);
        }

        private void buyUpgrade(ulong value)
        {
            ulong cost = value * 100;
            if (scoin < cost) return;

            ppc += value;
            scoin -= cost;

            refresh_counters();
        }

        private void Buy(object sender, MouseButtonEventArgs e)
        {
            Border border = sender as Border;

            int int_value = Convert.ToInt32(border.Tag);
            ulong value = (ulong)int_value;
            buyUpgrade(value);
        }

        private void Buy_Kremowka(object sender, MouseButtonEventArgs e)
        {
            if (scoin < 2137000) return;
            kremowkas++;
            scoin -= 2137000;

            refresh_counters();
        }
    }
}
