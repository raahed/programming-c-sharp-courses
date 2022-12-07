using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace Prog3_Practis8_A02
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public uint Zahl { get; set; }

        public string Zeichenkette { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            DataContext = this;
        }
    }
    public class TextValidaionRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string text = (string)value;

            if (text.All(c => char.IsLetter(c)))
                return new ValidationResult(false, "The String contains Digits!");

            return new ValidationResult(true, "All fine!");

                        
        }
    }
}
