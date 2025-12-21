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
        private bool Auto = false;

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

            isInitializing = false;

            RButton1.Checked += Category;
            RButton2.Checked += Category;
        }

        private void LoadMetri()
        {
            To.Items.Clear();
            From.Items.Clear();

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
            To.Items.Clear();
            From.Items.Clear();

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
            if (isInitializing) return;

            if(RButton1.IsChecked == true)
            {
                LoadMetri();
            }
            else if (RButton2.IsChecked == true)
            {
                LoadTempa();
            }

            if (Auto)
            {
                convert();
            }
        }

        private void convert()
        {

            Message.Text = " ";
            if(From.SelectedItem != null || To.SelectedItem != null)
            {
                Result.Text = " ";
                Message.Text = "Выбирете единицу измерения!";
                return;
            }

            if (string.IsNullOrWhiteSpace(Value.Text))
            {
                Result.Text = "";
                Message.Text = "Введите значение!";
                return;
            }

            try
            {
                string inputText = Value.Text.Replace('.', ',');
                if (!double.TryParse(inputText, out double inputValue))
                {
                    inputText = Value.Text.Replace('.', ',');
                    if (!double.TryParse(inputText, out inputValue))
                    {
                        Result.Text = "";
                        Message.Text = "Введите корректное число!";
                        return;
                    }
                }
                string fromUnit = From.SelectedItem.ToString();
                string toUnit = From.SelectedItem.ToString();

                double result;

                if (RButton1.IsChecked == true)
                {
                    result = ConMetri(inputValue, fromUnit, toUnit);
                }
                else
                {
                    result = ConTempa(inputValue, fromUnit, toUnit);
                }

                Result.Text = $"{inputValue} {fromUnit} = {result:F4} {toUnit}";
                }
            catch(Exception ex)
            {
                Result.Text = "";
                Message.Text = $"Ошибка: {ex.Message}";
            }
        }
        

        private double ConMetri(double value, string fromUnit, string toUnit)
        {
            if (!Metri.ContainsKey(fromUnit) || !Metri.ContainsKey(toUnit))
                throw new ArgumentException("Неизвестная единица измерения");

            double valueInMeters = value * Metri[fromUnit];

            double result = valueInMeters / Metri[toUnit];
            return result;
        }
        private double ConTempa(double value, string fromUnit, string toUnit)
        {
            string fromSymbol = Tempa[fromUnit];
            string toSymbol = Tempa[toUnit];

            double valueInCelsius;

            switch (fromSymbol)
            {
                case "C":
                    valueInCelsius = value;
                    break;
                case "F":
                    valueInCelsius = (value - 32) * 5 / 9;
                    break;
                case "K":
                    valueInCelsius = value - 273.15;
                    break;
                default:
                    throw new ArgumentException("Неизвестная единица измерения");
            }

            switch (toSymbol)
            {
                case "C":
                    return valueInCelsius;
                case "F":
                    return valueInCelsius * 9 / 5 + 32;
                case "K":
                    return valueInCelsius + 273.15;
                default:
                    throw new ArgumentException("Неизвестная единица измерения");

            
            }
        }

        private void AutoMode()
        {
            if (!Auto)
            {
                Auto = true;

                Value.TextChanged += Value_TextChenged;
                From.SelectionChanged += ComboBox_Changed;
                To.SelectionChanged += ComboBox_Changed;

                convert();
            }
        }
        private void Value_TextChenged(object sender, RoutedEventArgs e)
        {
            if (!Auto || isInitializing) return;
        }

        private void ComboBox_Changed(object sender, SelectionChangedEventArgs e)
        {
            if (!Auto || isInitializing) return;
            convert();
        }

        private void From_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void To_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            if (!Auto)
            {
                AutoMode();
            }

            convert();
        }
    }
}
