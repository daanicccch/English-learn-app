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
    /// Логика взаимодействия для lvl4.xaml
    /// </summary>
    public partial class lvl4 : Page
    {
        private MediaPlayer mediaPlayer;
        private int currentStage = 0;
        public lvl4()
        {
            InitializeComponent();
            mediaPlayer = new MediaPlayer();
        }
        private string[,] sentArray = new string[,]
        {
            {"Птицы щебечут по утрам", "Birds chirp in the morning"},
            {"Дождь капает на окно", "Rain drops on the window"},
            {"Дети смеются и играют в парке", "Children laugh and play in the park"},
            {"Ветер шепчет в листьях", "Wind whispers through the leaves"},
            {"Часы тикают на стене", "A clock ticks on the wall"},
            {"Дверь медленно скрипит, открываясь", "A door creaks open slowly"},
            {"Младенец весело хихикает", "A baby giggles happily"},
            {"Гроза румблит вдалеке", "Thunder rumbles in the distance"},
            {"Солнце светит ярко на небе", "The sun shines brightly in the sky"},
            {"Листья шуршат под ногами", "Leaves rustle underfoot"}   
        };
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new HomeUserControl());

        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new levels());
        }

        private double CalculateSimilarity(string str1, string str2)
        {
            int editDistance = CalculateEditDistance(str1, str2);
            return 1.0 - (double)editDistance / Math.Max(str1.Length, str2.Length);
        }

        private int CalculateEditDistance(string str1, string str2)
        {
            int[,] distance = new int[str1.Length + 1, str2.Length + 1];

            for (int i = 0; i <= str1.Length; i++)
            {
                for (int j = 0; j <= str2.Length; j++)
                {
                    if (i == 0)
                        distance[i, j] = j;
                    else if (j == 0)
                        distance[i, j] = i;
                    else
                        distance[i, j] = Math.Min(Math.Min(
                            distance[i - 1, j] + 1,
                            distance[i, j - 1] + 1),
                            distance[i - 1, j - 1] + (str1[i - 1] == str2[j - 1] ? 0 : 1));
                }
            }

            return distance[str1.Length, str2.Length];
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Open(new Uri("D:\\c#\\progg\\progg\\resourse\\lvl3\\" + currentStage + ".wav", UriKind.Relative));
            mediaPlayer.Play();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Open(new Uri("D:\\c#\\progg\\progg\\resourse\\lvl3\\" + currentStage + "slow.wav", UriKind.Relative));
            mediaPlayer.Play();
        }

        private void checkButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentStage <  sentArray.Length)
            {
                double porog = 0.9;
                textBox2.IsReadOnly = true;
                if (CalculateSimilarity(textBox2.Text, sentArray[currentStage, 1]) >= porog)
                {
                    nextButton.Content = "Next";
                    textBox2.Foreground = Brushes.Green;
                    textBox2.Background = new SolidColorBrush(Color.FromRgb(150, 181, 151));
                    textBox2.BorderBrush = new SolidColorBrush(Color.FromRgb(47, 107, 10));
                    checkButton.Visibility = Visibility.Collapsed;
                    nextButton.Visibility = Visibility.Visible;
      
                }
                else if (CalculateSimilarity(textBox2.Text, sentArray[currentStage, 1]) >= 0.8)
                {
                    nextButton.Content = "Next";
                    textBox2.Foreground = Brushes.Yellow;
                    textBox2.Background = new SolidColorBrush(Color.FromRgb(130, 133, 102));
                    textBox2.BorderBrush = new SolidColorBrush(Color.FromRgb(90, 97, 19));
                    checkButton.Visibility = Visibility.Collapsed;
                    nextButton.Visibility = Visibility.Visible;
                    

                }
                else
                {
                    textBox2.Foreground = Brushes.Red;
                    textBox2.Background = new SolidColorBrush(Color.FromRgb(173, 111, 126));
                    textBox2.BorderBrush = new SolidColorBrush(Color.FromRgb(79, 13, 28));
                    checkButton.Visibility = Visibility.Collapsed;
                    nextButton.Visibility = Visibility.Visible;
                    nextButton.Content = "Заново";
                    helpButton.Visibility = Visibility.Visible;
                }
            }
            else
            {
                NavigationService.Navigate(new levels());
            }
        }

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentStage <  sentArray.Length/2-1)
            {
                if(nextButton.Content == "Next")
                    currentStage++;
                textBox2.Text = string.Empty;
                textBox2.IsReadOnly = false;
                textBox2.Foreground = new SolidColorBrush(Color.FromRgb(171, 171, 171));
                textBox2.Background = new SolidColorBrush(Color.FromRgb(46, 46, 46));
                textBox2.BorderBrush = new SolidColorBrush(Color.FromRgb(33, 33, 33));
                checkButton.Visibility = Visibility.Visible;
                nextButton.Visibility = Visibility.Collapsed;
                helpButton.Visibility = Visibility.Collapsed;
            }
            else
            {
                NavigationService.Navigate(new levels());
            }
        }

        private void helpButton_Click(object sender, RoutedEventArgs e)
        {
            textBox2.Text = sentArray[currentStage, 1];
        }
    }
}
