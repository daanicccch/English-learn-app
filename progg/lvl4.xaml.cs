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
        private int currentStage = AppVariables.GlobalValue;
        System.Windows.Controls.Image[] imageArray;
        public lvl4()
        {
            InitializeComponent();
            imageArray = new System.Windows.Controls.Image[] { i1, i2, i3, i4, i5, i6, i7, i8, i9, i10 };
            InitializeBar();
            mediaPlayer = new MediaPlayer();
        }
        private void InitializeBar()
        {
            for (int i = 0; i < AppVariables.IsRight.Length; i++)
            {
                if (AppVariables.IsRight[i] == 0)
                {
                    imageArray[i].Source = BitmapFrame.Create(new Uri("./resourse/greenBar.png", UriKind.Relative));
                }
                else if (AppVariables.IsRight[i] == 1)
                {
                    imageArray[i].Source = BitmapFrame.Create(new Uri("./resourse/redBar.png", UriKind.Relative));
                }
                else
                {
                    imageArray[i].Source = BitmapFrame.Create(new Uri("./resourse/greyBar.png", UriKind.Relative));
                }
            }
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
            mediaPlayer.Open(new Uri(".\\resourse\\lvl3\\" + currentStage + ".wav", UriKind.Relative));
            mediaPlayer.Play();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Open(new Uri(".\\resourse\\lvl3\\" + currentStage + "slow.wav", UriKind.Relative));
            mediaPlayer.Play();
        }

        private void checkButton_Click(object sender, RoutedEventArgs e)
        {
                double porog = 0.9;
                textBox2.IsReadOnly = true;
                if (CalculateSimilarity(textBox2.Text, sentArray[currentStage, 1]) >= porog)
                {
                    textBox2.Foreground = Brushes.Green;
                    textBox2.Background = new SolidColorBrush(Color.FromRgb(150, 181, 151));
                    textBox2.BorderBrush = new SolidColorBrush(Color.FromRgb(47, 107, 10));
                    imageArray[AppVariables.GlobalIndex - 1].Source = BitmapFrame.Create(new Uri("./resourse/greenBar.png", UriKind.Relative));
                    AppVariables.IsRight[AppVariables.GlobalIndex - 1] = 0;
                    checkButton.Visibility = Visibility.Collapsed;
                    nextButton.Visibility = Visibility.Visible;
      
                }
                else if (CalculateSimilarity(textBox2.Text, sentArray[currentStage, 1]) >= 0.8)
                {
                    textBox2.Foreground = Brushes.Yellow;
                    textBox2.Background = new SolidColorBrush(Color.FromRgb(130, 133, 102));
                    textBox2.BorderBrush = new SolidColorBrush(Color.FromRgb(90, 97, 19));
                    imageArray[AppVariables.GlobalIndex - 1].Source = BitmapFrame.Create(new Uri("./resourse/greenBar.png", UriKind.Relative));
                    AppVariables.IsRight[AppVariables.GlobalIndex - 1] = 0;
                    checkButton.Visibility = Visibility.Collapsed;
                    nextButton.Visibility = Visibility.Visible;
                    

                }
                else
                {
                    textBox2.Foreground = Brushes.Red;
                    textBox2.Background = new SolidColorBrush(Color.FromRgb(173, 111, 126));
                    textBox2.BorderBrush = new SolidColorBrush(Color.FromRgb(79, 13, 28));
                    imageArray[AppVariables.GlobalIndex - 1].Source = BitmapFrame.Create(new Uri("./resourse/redBar.png", UriKind.Relative));
                    AppVariables.IsRight[AppVariables.GlobalIndex - 1] = 1;
                    checkButton.Visibility = Visibility.Collapsed;
                    nextButton.Visibility = Visibility.Visible;
                }
        }

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
             NavigationService.Navigate(new level1());
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AboutPage());
        }
    }
}
