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

namespace Prog3_Practis2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            //Binding b2 = new Binding(nameof(textBox1.Text));
            //b2.Mode = BindingMode.OneWay;
            //b2.Source = textBox1;
            //textBox2.SetBinding(TextBox.TextProperty, b2);

            //Binding b3 = new Binding(nameof(textBox2.Text));
            //b3.Mode = BindingMode.OneWay;
            //b3.Source = textBox2;
            //textBox3.SetBinding(TextBox.TextProperty, b3);

            //Binding b4 = new Binding(nameof(textBox3.Text));
            //b4.Mode = BindingMode.OneWay;
            //b4.Source = textBox3;
            //textBox4.SetBinding (TextBox.TextProperty, b4);
        }

        private void Changed_Box(object sender, TextChangedEventArgs e)
        {
            if(sender is TextBox box)
                if(sender.Equals(textBox1))
                    textBox2.Text = box.Text;
                else if (sender.Equals(textBox2))
                    textBox3.Text = box.Text;
                else if (sender.Equals(textBox3))
                    textBox4.Text = box.Text;
        }
    }
}
