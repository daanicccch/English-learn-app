using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
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
    /// Логика взаимодействия для lvl2.xaml
    /// </summary>
    public partial class lvl2 : Page
    {
        System.Windows.Controls.Image[] imageArray;
        private Button[] answerButtons;
        private Random random = new Random();
        private int currentStage = AppVariables.GlobalValue;
        public lvl2()
        {
            InitializeComponent();
            imageArray = new System.Windows.Controls.Image[] { i1, i2, i3, i4, i5, i6, i7, i8, i9, i10 };
            InitializeBar();
            answerButtons = new Button[] { button1, button2, button4 };
            UpdateUIForCurrentStage();
            removeTrueButton();
            
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
       

        private string[,] wordArray = new string[,]
       {
            { "a cup", "a car", "a table", "a window" },
            { "a fir", "a dog", "a carpet", "a bicycle" },
            { "a book", "a chair", "a lamp", "a door" },
            { "a mountain", "a cat", "a milk", "a skateboard" },
            { "a smartphone", "a tree", "a plate", "a mirror" },
            { "a pen", "a bus", "a desk", "a curtain" },
            { "a laptop", "a river", "a fork", "a painting" },
            { "a hat", "a airplane", "a bed", "a garden" },
            { "a frige", "a train", "a shelf", "a vase" }
       };

        private string[,] qimageArray = new string[,]
       {
            {"cup.png", "car.png","table.png","window.png"},
            { "fir.png", "dog.png", "carpet.png", "bicycle.png" },
            { "book.png", "chair.png", "lamp.png", "door.png" },
            { "mountain.png", "cat.png", "milk.png", "skateboard.png" },
            { "smartphone.png", "tree.png", "plate.png", "mirror.png" },
            { "pen.png", "bus.png", "desk.png", "curtain.png" },
            { "laptop.png", "river.png", "fork.png", "painting.png" },
            { "hat.png", "airplane.png", "bed.png", "garden.png" },
            { "fridge.png", "train.png", "shelf.png", "vase.png" }
       };

        private string[] qwaordArray = new string[] {"Кружка", "Елка","Книга", "Гора", "Смартфон", "Ручка", "Ноутбук", "Шляпа", "Холодильник" };
        private void button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            button1.IsEnabled = false;
            button2.IsEnabled = false;
            button4.IsEnabled = false;
            trueButton.IsEnabled = false;
            if (button.Name == "trueButton")
            {
                button.Foreground = Brushes.Green;
                button.Background = new SolidColorBrush(Color.FromRgb(150, 181, 151));
                button.BorderBrush = new SolidColorBrush(Color.FromRgb(47, 107, 10));
                nextButton.Visibility = Visibility.Visible;
                imageArray[AppVariables.GlobalIndex - 1].Source = BitmapFrame.Create(new Uri("./resourse/greenBar.png", UriKind.Relative));
                AppVariables.IsRight[AppVariables.GlobalIndex - 1] = 0;
            }
            else
            {
                button.Foreground = Brushes.Red;
                button.Background = new SolidColorBrush(Color.FromRgb(173, 111, 126));
                button.BorderBrush = new SolidColorBrush(Color.FromRgb(79, 13, 28));
                imageArray[AppVariables.GlobalIndex - 1].Source = BitmapFrame.Create(new Uri("./resourse/redBar.png", UriKind.Relative));
                AppVariables.IsRight[AppVariables.GlobalIndex - 1] = 0;
                nextButton.Visibility = Visibility.Visible;

            }
        }

        private void UpdateUIForCurrentStage()
        {
            tblocktrue.Text = wordArray[currentStage, 0];
            tblock1.Text = wordArray[currentStage, 1];
            tblock2.Text = wordArray[currentStage, 2];
            tblock4.Text = wordArray[currentStage, 3];

            button1.IsEnabled = true;
            button2.IsEnabled = true;
            button4.IsEnabled = true;
            trueButton.IsEnabled = true;

            RestoreButton(trueButton);
            RestoreButton(button1);
            RestoreButton(button2);
            RestoreButton(button4);
        }

        private void UpdateImages()
        {
            vtrue.Source = BitmapFrame.Create(new Uri("./resourse/lvl2/" + qimageArray[currentStage, 0], UriKind.Relative));
            v1.Source = BitmapFrame.Create(new Uri("./resourse/lvl2/" + qimageArray[currentStage, 1], UriKind.Relative));
            v2.Source = BitmapFrame.Create(new Uri("./resourse/lvl2/" + qimageArray[currentStage, 2], UriKind.Relative));
            v4.Source = BitmapFrame.Create(new Uri("./resourse/lvl2/" + qimageArray[currentStage, 3], UriKind.Relative));
        }

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new level1());
        }
        private void removeTrueButton()
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

            txt.Text = "Отметьте \"" + qwaordArray[currentStage] + "\"";
            UpdateUIForCurrentStage();
            UpdateImages();
            
        }
        private void RestoreButton(Button button) // очистка кнопок
        {
            button.Foreground = new SolidColorBrush(Color.FromRgb(171, 171, 171));
            button.Background = new SolidColorBrush(Color.FromRgb(46, 46, 46));
            button.BorderBrush = new SolidColorBrush(Color.FromRgb(33, 33, 33));
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
    }
}
