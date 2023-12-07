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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Button[] answerButtons;
        private Random random = new Random();
        public MainWindow()
        {
            InitializeComponent();
            answerButtons = new Button[] { button1, button2, button4 };
        }
        private int currentStage = -1;
        
        private string[,] wordArray = new string[,]
        {
            { "Picture", "Pucture", "Pictur", "Pecture" },
            { "Mouse", "Muose", "Mous", "Mause" },
            { "Pencil", "Pensil", "Pancil", "Pencel" },
        };
      
    private void button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if(button.Name == "trueButton")
            {
                button.Foreground = Brushes.Green;
                button.Background = new SolidColorBrush(Color.FromRgb(150, 181, 151));
                button.BorderBrush = new SolidColorBrush(Color.FromRgb(47, 107, 10));
                nextButton.Visibility = Visibility.Visible;
            }
            else
            {
                button.Foreground = Brushes.Red;
                button.Background = new SolidColorBrush(Color.FromRgb(173, 111, 126));
                button.BorderBrush = new SolidColorBrush(Color.FromRgb(79, 13, 28));
            } 
        }
        private void UpdateUIForCurrentStage()
        {
            
            if (currentStage < wordArray.Length)
            {
               
                trueButton.Content = wordArray[currentStage, 0];
                button1.Content = wordArray[currentStage, 1];
                button2.Content = wordArray[currentStage, 2];
                button4.Content = wordArray[currentStage, 3];

                RestoreButton(trueButton);
                RestoreButton(button1);
                RestoreButton(button2);
                RestoreButton(button4);
            }
            else
            {
                MessageBox.Show("Вы завершили все этапы!");
            }
        }
        private void RestoreButton(Button button) // очистка кнопок
        {
            button.Foreground = Brushes.Black;
            button.Background = new SolidColorBrush(Color.FromRgb(184, 215, 245)); 
            button.BorderBrush = new SolidColorBrush(Color.FromRgb(74, 131, 217)); 
        }
        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            Button randomButton = answerButtons[random.Next(answerButtons.Length)];
            int tempColumn = Grid.GetColumn(trueButton);
            int tempRow = Grid.GetRow(trueButton);

            Grid.SetColumn(trueButton, Grid.GetColumn(randomButton));
            Grid.SetRow(trueButton, Grid.GetRow(randomButton));

            Thickness tempp = (trueButton.Margin);
            trueButton.Margin = randomButton.Margin;
            randomButton.Margin = tempp;

            Grid.SetColumn(randomButton, tempColumn);
            Grid.SetRow(randomButton, tempRow);
            currentStage++;
            UpdateUIForCurrentStage();
        }
    }
}
