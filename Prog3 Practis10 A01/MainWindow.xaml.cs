using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace WpfDataTemplate
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Student> Students { get; set; } = new();    

        public MainWindow()
        {
            InitializeComponent();

            Students.Add(new Student(123456, "John Doe", 23, "IN"));
            Students.Add(new Student(654321, "Graf Zahl", 17, "MIN"));
        }
    }

    public class CheckAge : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if((int)value > 18)
                return new SolidColorBrush(Colors.Green);
            else
                return new SolidColorBrush(Colors.Orange);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
