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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace progg
{
    /// <summary>
    /// Логика взаимодействия для HomeUserControl.xaml
    /// </summary>
    public partial class HomeUserControl : Page
    {
        public HomeUserControl()
        {
            InitializeComponent();
        }

        private void Button_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Button enterButton = (Button)sender;
            DoubleAnimation animation = new DoubleAnimation
            {
                To = 0.2,
                Duration = TimeSpan.FromSeconds(0.3)
            };

            enterButton.BeginAnimation(Button.OpacityProperty, animation);
        }

        private void Button_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Button enterButton = (Button)sender;
            DoubleAnimation animation = new DoubleAnimation
            {
                To = 0.05,
                Duration = TimeSpan.FromSeconds(0.3)
            };

            enterButton.BeginAnimation(Button.OpacityProperty, animation);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new HomeUserControl());

        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new levels());

        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AboutPage());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new levels());
        }

    }
}
