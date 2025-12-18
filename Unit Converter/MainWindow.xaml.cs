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

namespace Unit_Converter
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private bool isInitializing = true;

        private Dictionary<string, double> Metri = new Dictionary<string, double>
        {
            { "Метр", 1.0 },
            { "Километр", 1000.0 },
            { "Сантиметр", 0.01 },
            { "Миллиметр", 0.001 },
            { "Дюйм", 0.0254 },
            { "Фут", 0.3048 }
        };

        private Dictionary<string, string> Tempa = new Dictionary<string, string>
        {
            { "Цельсий", "C" },
            { "Фаренгейт", "F" },
            { "Кельвин", "K" }
        };

        public MainWindow()
        {
            InitializeComponent();
        }
        private void RButton1_Selected(object sender, RoutedEventArgs e)
        {

        }
        private void RButton2_Selected(object sender, RoutedEventArgs e)
        {

        }
        private void Value_TextChenged(object sender, RoutedEventArgs e)
        {

        }

        private void From_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void To_Selected(object sender, RoutedEventArgs e)
        {

        }
    }
}
