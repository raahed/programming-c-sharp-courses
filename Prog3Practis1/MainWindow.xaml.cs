using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Prog3Practis3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ResetSlider(object sender, EventArgs e)
        {
            slider.Value = 0;

            // Call the feedback method
            Feedback(sender, (RoutedEventArgs)e);
        }

        private void ApplySliderChange(object sender, RoutedEventArgs e)
        {
            if (sender is Slider slider)
                text.Text = $"{slider.Value}";
        }

        private void Feedback(object sender, RoutedEventArgs e)
        {
            string controlName = "unknown";
            if (sender is Control && ((Control)sender).Name != null)
            {
                controlName = ((Control)sender).Name;
            }
            MessageBox.Show(controlName + " pressed!", "Feedback");
        }
    }
}
