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

namespace Prog3Practis1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Slider slider;
        Button button;
        Label text;

        public MainWindow()
        {
            InitializeComponent();

            StackPanel stackPanel = new StackPanel();

            slider = new Slider();

            Binding bind = new Binding(nameof(slider.Value));
            bind.Source = slider;

            button = new Button();
            button.Content = "Reset";
            button.Click += ResetSlider;

            text = new Label();
            text.Content = "50";
            text.SetBinding(Label.ContentProperty, bind);

            AddChild(stackPanel);
            stackPanel.Children.Add(text);
            stackPanel.Children.Add(slider);
            stackPanel.Children.Add(button);

        }

        private void ResetSlider(object sender, EventArgs e)
        {
            slider.Value = 0;

            // Call the feedback method
            Feedback(sender, (RoutedEventArgs)e);
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
