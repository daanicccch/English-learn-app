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
    /// Логика взаимодействия для level1.xaml
    /// </summary>
    public partial class level1 : Page
    {
        public level1()
        {
            InitializeComponent();
            
            switch (AppVariables.GlobalIndex)
            {
                case 0:
                    AppVariables.GlobalIndex++;
                    mainFrame.Navigate(new lvl1());
                    AppVariables.GlobalValue = 1;
                    break;
                case 1:
                    AppVariables.GlobalIndex++;
                    mainFrame.Navigate(new lvl1());
                    AppVariables.GlobalValue = 0;
                    break;
                case 2:
                    AppVariables.GlobalIndex++;
                    mainFrame.Navigate(new lvl5());
                    break;
                case 3:
                    AppVariables.GlobalIndex++;
                    mainFrame.Navigate(new lvl2());
                    break;
                case 4:
                    AppVariables.GlobalIndex++;
                    mainFrame.Navigate(new lvl3());
                    AppVariables.GlobalValue = 1;
                    break;
                case 5:
                    AppVariables.GlobalIndex++; 
                    mainFrame.Navigate(new lvl5());
                    AppVariables.GlobalValue = 0;
                    break;
                case 6:
                    AppVariables.GlobalIndex++;
                    mainFrame.Navigate(new lvl4());
                    AppVariables.GlobalValue = 2;
                    break;
                case 7:
                    AppVariables.GlobalIndex++;
                    mainFrame.Navigate(new lvl5());
                    AppVariables.GlobalValue = 1;
                    break;
                case 8:
                    AppVariables.GlobalIndex++;
                    mainFrame.Navigate(new lvl2());
                    break;
                case 9:
                    AppVariables.GlobalIndex++;
                    mainFrame.Navigate(new lvl3());
                    break;
                default:
                    mainFrame.Navigate(new levels());
                    break;
            }
            
        }

    }
}
