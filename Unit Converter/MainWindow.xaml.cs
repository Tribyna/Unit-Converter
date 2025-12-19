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

            LoadMetri();

            RButton1.Checked += Category;
            RButton2.Checked += Category;
        }

        private void LoadMetri()
        {
            foreach (var unit in Metri.Keys)
            {
                From.Items.Add(unit);
                To.Items.Add(unit);
            }

            if (From.Items.Count > 0)
            {
                From.SelectedIndex = 0;
            }

            if (To.Items.Count > 1)
            {
                To.SelectedIndex = 1;
            }
        }

        private void LoadTempa()
        {
            foreach (var unit in Tempa.Keys)
            {
                From.Items.Add(unit);
                To.Items.Add(unit);
            }

            if (From.Items.Count > 0)
            {
                From.SelectedIndex = 0;
            }

            if (To.Items.Count > 1)
            {
                To.SelectedIndex = 1;
            }
        }

        private void Category(object sender, RoutedEventArgs e)
        {
            if(RButton1.IsChecked == true)
            {
                LoadMetri();
            }
            else if (RButton2.IsChecked == true)
            {
                LoadTempa();
            }
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

        private void Start_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
