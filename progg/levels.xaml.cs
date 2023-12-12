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

namespace progg
{
    /// <summary>
    /// Логика взаимодействия для levels.xaml
    /// </summary>
    public partial class levels : Page
    {
        int i = 1;
        public levels()
        {
            InitializeComponent();
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
 
           NavigationService.Navigate(new HomeUserControl());
        }
        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new levels());
        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            if (i>1)
            {
                i--;
                txt1.Text = "Level " + i.ToString();
            }
            else
            {
                txt1.Text = "Level " + i.ToString();
            }
        }

        private void GoNext(object sender, RoutedEventArgs e)
        {
            if (i<10)
            {
                i++;
                txt1.Text = "Level " + i.ToString();
            }
            else
            {
                txt1.Text = "Level " + i.ToString();
            }
        }

        private void lvl1_Click(object sender, RoutedEventArgs e)
        {
            if (txt1.Text == "Level 1")
            {
                NavigationService.Navigate(new lvl1());
            }
            if (txt1.Text == "Level 2")
            {
                NavigationService.Navigate(new lvl2());
            }
            if (txt1.Text == "Level 3")
            {
                NavigationService.Navigate(new lvl3());
            }
            if (txt1.Text == "Level 4")
            {
                NavigationService.Navigate(new lvl4());
            }
        }
    }
}
