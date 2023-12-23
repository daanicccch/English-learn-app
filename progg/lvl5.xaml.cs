using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
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
using System.Windows.Shell;
using static System.Windows.Forms.LinkLabel;
using System.Collections.Generic;
using System.Windows.Controls;
using System.ComponentModel;

namespace progg
{
    /// <summary>
    /// Логика взаимодействия для lvl5.xaml
    /// </summary>
    public partial class lvl5 : Page
    {
        public lvl5()
        {
            InitializeComponent();
            InitializaButtons();
        }
        private string[,] wordArray = new string[,]
        {
            
            {"We","I", "drink", "eat", "bread", "help", "want","water", "You", "I eat bread ", "Я ем хлеб"},
            {"She", "reads", "to", "books", "listens", "sometimes", "music", "studies", "French", "She listens to music sometimes reads books studies French", "Она слушает музыку, иногда читает книги, изучает французский"},
            {"She","plays", "football", "likes", "with", "banana", "doesn't", "apple","games", "She likes games with apple ", "Ей нравятся игры с яблоком"},
            {"They", "listen", "to", "music", "study", "play", "not", "sometimes", "games", "They study music sometimes play ", "Они занимаются музыкой, а иногда играют"},
            {"Cats", "sings", "dance", "never", "rain", "in", "the", "like", "They", "Cats never dance in the rain ", "Кошки никогда не танцуют под дождем"},
            
            {"He", "watches", "TV", "cooks", "plays", "basketball", "rarely", "often", "he", "He often watches TV rarely cooks plays basketball ", "Он часто смотрит телевизор, редко готовит, играет в баскетбол"},
            {"The", "beach", "on", "love", "sand", "sun", "I", "and", "sea", "I love the beach sand sun and sea ", "Я люблю пляж, песок, солнце и море"},
            {"They", "swim", "like", "skateboard", "play", "hockey", "never", "water", "in", "They never play hockey in the water swim like skateboard ", "Они никогда не играют в хоккей в воде, плавают, любят кататься на скейтборде"},
            {"I", "chocolate", "hate", "but", "love", "I", "ice", "cream", "eat", "I hate chocolate but I love ice cream", "Я ненавижу шоколад, но люблю мороженое"},
            {"We", "homework", "have", "weekend", "do", "on", "like", "not", "housework", "We do not like to have homework on the weekend", "Нам не нравится делать домашнее задание на выходных"}
          };
        Button[] buttons = new Button[9];
        TextBlock[] textBlock = new TextBlock[9];
        List<string> result = new List<string>();
        int currentStage = 0; 
        private void InitializaButtons()
        {
                
            double leftOffset = 0;
            double topOffset = 0;

            for (int i = 0; i < 9; i++)
                {
                    int index = i;  

                    textBlock[i] = new TextBlock
                    {
                        Margin = new Thickness(10, 10, 10, 10),
                        Text = wordArray[currentStage, i],


                    };
                    buttons[i] = new Button
                    {
                        Content = textBlock[i],
                        Style = FindResource("SwitchButton") as Style,
                        Width = double.NaN,
                        Height = double.NaN,
                        HorizontalAlignment = HorizontalAlignment.Left,
                        VerticalAlignment = VerticalAlignment.Top,
                        Foreground = new System.Windows.Media.SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#ABABAB")),
                        FontSize = 20,
                        Margin = new Thickness(40, 170, 0, 0),

                    };
                    buttons[i].Click += buttonWord_Click;
                    buttons[i].Loaded += (sender, e) =>
                    {
                        Canvas.SetLeft(buttons[index], leftOffset);
                        Canvas.SetTop(buttons[index], topOffset);
                        leftOffset += buttons[index].ActualWidth+10;
                        if (leftOffset + buttons[index].ActualWidth > buttonsCanvas.ActualWidth)
                        {
                            leftOffset = 0;
                            topOffset += buttons[index].ActualHeight + 10;
                        }

                    };

                    buttonsCanvas.Children.Add(buttons[i]);
                }
            
        }
        private Dictionary<Button, bool> buttonStates = new Dictionary<Button, bool>();
        private Dictionary<Button, double> originalLeftOffsets = new Dictionary<Button, double>();
        private Dictionary<Button, double> originalTopOffsets = new Dictionary<Button, double>();
        private void InitializeButtonState(Button button)
        {
            // Инициализация состояния для каждой кнопки
            buttonStates[button] = true;
        }
        double leftOffset = 0;
    
        private void buttonWord_Click(object sender, RoutedEventArgs e)
        {
                Button clickedButton = sender as Button;

                if (!buttonStates.ContainsKey(clickedButton))
                {
                    InitializeButtonState(clickedButton);
                }

                if (buttonStates[clickedButton])
                {
                    if (clickedButton.Content is TextBlock textBlock)
                    {
                        result.Add(textBlock.Text);
                    }
                    originalLeftOffsets[clickedButton] = (double)clickedButton.GetValue(Canvas.LeftProperty);
                    originalTopOffsets[clickedButton] = (double)clickedButton.GetValue(Canvas.TopProperty);
                    DoubleAnimation animationX = new DoubleAnimation();
                    animationX.From = originalLeftOffsets[clickedButton];
                    animationX.To = leftOffset;
                    animationX.Duration = TimeSpan.FromSeconds(0.2);

                    DoubleAnimation animationY = new DoubleAnimation();
                    animationY.From = Canvas.GetTop(clickedButton);
                    animationY.To = -170;
                    animationY.Duration = TimeSpan.FromSeconds(0.2);

                    leftOffset += clickedButton.ActualWidth + 10;

                    clickedButton.BeginAnimation(Canvas.LeftProperty, animationX);
                    clickedButton.BeginAnimation(Canvas.TopProperty, animationY);

                    buttonStates[clickedButton] = false;
                }
                else
                {
                    double currentRight = Canvas.GetLeft(clickedButton)-1;
                    double currentButtonLeft = Canvas.GetLeft(clickedButton);
                    foreach (Button otherButton in buttons)
                    {

                        double otherButtonLeft = Canvas.GetLeft(otherButton);
                        if (otherButtonLeft>currentRight)
                        {
                            if (otherButton.Content is TextBlock otherTextBlock)
                            {
                                result.Remove(otherTextBlock.Text);
                            }
                            if (!originalLeftOffsets.ContainsKey(otherButton))
                            {
                                originalLeftOffsets.Add(otherButton, (double)otherButton.GetValue(Canvas.LeftProperty));

                            }
                            if (!originalTopOffsets.ContainsKey(otherButton))
                            {
                                originalTopOffsets.Add(otherButton, (double)otherButton.GetValue(Canvas.TopProperty));

                            }

                            DoubleAnimation animationXo = new DoubleAnimation();
                            animationXo.From = Canvas.GetLeft(otherButton);
                            animationXo.To = originalLeftOffsets[otherButton];
                            animationXo.Duration = TimeSpan.FromSeconds(0.2);

                            DoubleAnimation animationYo = new DoubleAnimation();
                            animationYo.From = Canvas.GetTop(otherButton);
                            animationYo.To = originalTopOffsets[otherButton];
                            animationYo.Duration = TimeSpan.FromSeconds(0.2);


                            otherButton.BeginAnimation(Canvas.LeftProperty, animationXo);
                            otherButton.BeginAnimation(Canvas.TopProperty, animationYo);

                            buttonStates[otherButton] = true;
                        }
                        if (!HasButtonsToTheLeft(clickedButton))
                        {
                            leftOffset = 0;
                        }
                        else
                        {
                            leftOffset = Canvas.GetLeft(clickedButton);

                        }

                    }
                }

        }

        private void goBack()
        {
            foreach (Button otherButton in buttons)
            {


                if (otherButton.Content is TextBlock otherTextBlock)
                {
                    result.Remove(otherTextBlock.Text);
                }
                if (!originalLeftOffsets.ContainsKey(otherButton))
                {
                    originalLeftOffsets.Add(otherButton, (double)otherButton.GetValue(Canvas.LeftProperty));
                }
                DoubleAnimation animationXo = new DoubleAnimation();
                animationXo.From = Canvas.GetLeft(otherButton);
                animationXo.To = originalLeftOffsets[otherButton];
                animationXo.Duration = TimeSpan.FromSeconds(0.2);

                DoubleAnimation animationYo = new DoubleAnimation();
                animationYo.From = Canvas.GetTop(otherButton);
                animationYo.To = 0;
                animationYo.Duration = TimeSpan.FromSeconds(0.2);


                otherButton.BeginAnimation(Canvas.LeftProperty, animationXo);
                otherButton.BeginAnimation(Canvas.TopProperty, animationYo);

                buttonStates[otherButton] = true;
                leftOffset = 0;
            }
        }
        private bool HasButtonsToTheLeft(Button currentButton)
        {
            double currentButtonLeft = Canvas.GetLeft(currentButton);

            foreach (Button otherButton in buttons)
            {
                if (otherButton != currentButton)
                {
                    double otherButtonRight = Canvas.GetLeft(otherButton) + otherButton.ActualWidth;

                    if (otherButtonRight < currentButtonLeft)
                    {
                        return true;
                    }
                }
            }

            return false;
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
                string res = "";
                foreach (var item in result)
                {
                    res += item + " ";
                }
               
                if (currentStage < wordArray.Length)
                {
                    double porog = 0.9;
                    txt1.Text = wordArray[currentStage, 10];
                    if (CalculateSimilarity(res, wordArray[currentStage, 9]) >= porog)
                    {
                        for (int i = 0; i<buttons.Length; i++)
                        {
                            buttons[i].IsEnabled = false;
                            if (Canvas.GetTop(buttons[i]) == -170)
                            {
                                buttons[i].Foreground = System.Windows.Media.Brushes.Green;
                                buttons[i].Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(150, 181, 151));
                                buttons[i].BorderBrush = new SolidColorBrush(System.Windows.Media.Color.FromRgb(47, 107, 10));
                                
                            }
                        }
                        nextButton.Content = "Next";
                        checkButton.Visibility = Visibility.Collapsed;
                        nextButton.Visibility = Visibility.Visible;
                        currentStage++;
                    }
                    else if (CalculateSimilarity(res, wordArray[currentStage, 6]) >= 0.8)
                    {
                        nextButton.Content = "Next";
                        for (int i = 0; i<buttons.Length; i++)
                        {
                            buttons[i].IsEnabled = false;
                            if (Canvas.GetTop(buttons[i]) == -170)
                            {
                                buttons[i].Foreground = System.Windows.Media.Brushes.Yellow;
                                buttons[i].Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(130, 133, 102));
                                buttons[i].BorderBrush = new SolidColorBrush(System.Windows.Media.Color.FromRgb(90, 97, 19));

                            }
                        }
                        checkButton.Visibility = Visibility.Collapsed;
                        nextButton.Visibility = Visibility.Visible;
                        currentStage++;
                    }
                    else
                    {
                        
                        for (int i = 0; i<buttons.Length; i++)
                        {
                            buttons[i].IsEnabled = false;
                            if (Canvas.GetTop(buttons[i]) == -170)
                            {
                                buttons[i].Foreground = System.Windows.Media.Brushes.Red;
                                buttons[i].Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(173, 111, 126));
                                buttons[i].BorderBrush = new SolidColorBrush(System.Windows.Media.Color.FromRgb(79, 13, 28));
                            }
                        }
                        checkButton.Visibility = Visibility.Collapsed;
                        nextButton.Visibility = Visibility.Visible;
                        nextButton.Content = "Заново";

                    }
                }
                else
                {
                    NavigationService.Navigate(new levels());
                }
            }catch(Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new HomeUserControl());

        }
        
        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new levels());

        }

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            if (nextButton.Content == "Заново")
                goBack(); 
            if (currentStage <  wordArray.Length)
            {
                txt1.Text = wordArray[currentStage, 10];
      
                    goBack();
                foreach (Button button in buttons)
                {
                    if (button.Parent != null)
                    {
                        (button.Parent as Panel)?.Children.Remove(button);
                    }
                    button.Click -= buttonWord_Click;
                    button.Content = null;
                }
                Array.Clear(buttons, 0, buttons.Length);

                InitializaButtons();
                checkButton.Visibility = Visibility.Visible;
                nextButton.Visibility = Visibility.Collapsed;
            }
            else
            {
                NavigationService.Navigate(new levels());
            }
        }
    }
}
