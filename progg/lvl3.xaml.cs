using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace progg
{
    /// <summary>
    /// Логика взаимодействия для lvl3.xaml
    /// </summary>
    public partial class lvl3 : Page
    {
        public lvl3()
        {
            InitializeComponent();
            textBox1.IsReadOnly = true;
        }
        private string[,] sentArray = new string[,]
        {
            { "Дети играли в парке весь день", "The children played in the park all day" },
            {"Мы готовили вкусный обед вместе с друзьями", "We cooked a delicious lunch together with friends"},
            {"Он читал интересную книгу в тени дерева", "He was reading an interesting book in the shade of the tree"},
            {"Моя сестра училась играть на гитаре много лет", "My sister has been learning to play the guitar for many years"},
            {"Вчера мы посетили музей искусств", "Yesterday, we visited the art museum"},
            {"Она занимается йогой каждое утро для поддержания здоровья", "She practices yoga every morning to maintain her health"},
            {"Котенок спрятался в коробке и играл с лентой", "The kitten hid in the box and played with the ribbon"},
            {"Вечер был теплым, и мы собрались на пикник в парке", "The evening was warm, and we gathered for a picnic in the park"},
            {"Они отправились в поход и провели ночь под звездами", "They went on a hike and spent the night under the stars"},
            {"Закат отразился в водах океана", "The sunset reflected in the waters of the ocean"}
         };

        private int currentStage = 0;
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
            try
            {
                if (currentStage <  sentArray.Length/2-1)
                {
                    double porog = 0.9;
                    textBox2.IsReadOnly = true;
                    textBox1.Text = sentArray[currentStage, 1];
                    if (CalculateSimilarity(textBox2.Text, sentArray[currentStage, 1]) >= porog)
                    {
                        nextButton.Content = "Next";
                        textBox2.Foreground = Brushes.Green;
                        textBox2.Background = new SolidColorBrush(Color.FromRgb(150, 181, 151));
                        textBox2.BorderBrush = new SolidColorBrush(Color.FromRgb(47, 107, 10));
                        checkButton.Visibility = Visibility.Collapsed;
                        nextButton.Visibility = Visibility.Visible;
                        currentStage++;
                    }
                    else if (CalculateSimilarity(textBox2.Text, sentArray[currentStage, 1]) >= 0.8)
                    {
                        nextButton.Content = "Next";
                        textBox2.Foreground = Brushes.Yellow;
                        textBox2.Background = new SolidColorBrush(Color.FromRgb(130, 133, 102));
                        textBox2.BorderBrush = new SolidColorBrush(Color.FromRgb(90, 97, 19));
                        checkButton.Visibility = Visibility.Collapsed;
                        nextButton.Visibility = Visibility.Visible;
                        currentStage++;
                    }
                    else
                    {
                        textBox2.Foreground = Brushes.Red;
                        textBox2.Background = new SolidColorBrush(Color.FromRgb(173, 111, 126));
                        textBox2.BorderBrush = new SolidColorBrush(Color.FromRgb(79, 13, 28));
                        checkButton.Visibility = Visibility.Collapsed;
                        nextButton.Visibility = Visibility.Visible;
                        nextButton.Content = "Заново";
                    }
                }
                else
                {
                    NavigationService.Navigate(new levels());
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            try { 
            if (currentStage <  sentArray.Length-1)
            {
                textBox2.Text = string.Empty;
                textBox2.IsReadOnly = false;
                textBox2.Foreground = new SolidColorBrush(Color.FromRgb(171, 171, 171));
                textBox2.Background = new SolidColorBrush(Color.FromRgb(46, 46, 46));
                textBox2.BorderBrush = new SolidColorBrush(Color.FromRgb(33, 33, 33));
                textBox1.Text = sentArray[currentStage,0];
                checkButton.Visibility = Visibility.Visible;
                nextButton.Visibility = Visibility.Collapsed;
            }
            else
            {
                NavigationService.Navigate(new levels());
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
