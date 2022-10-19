using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Prog3_Practis1._2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            window.MouseLeftButtonDown += MyBubbleEvent;
            window.PreviewMouseLeftButtonDown += MyBubbleEvent;
            window.MouseLeftButtonDown += MyTunnelingEvent;
            window.PreviewMouseLeftButtonDown += MyTunnelingEvent;

            grid.MouseLeftButtonDown += MyBubbleEvent;
            grid.PreviewMouseLeftButtonDown += MyBubbleEvent;
            grid.MouseLeftButtonDown += MyTunnelingEvent;
            grid.PreviewMouseLeftButtonDown += MyTunnelingEvent;

            elli.MouseLeftButtonDown += MyBubbleEvent;
            elli.PreviewMouseLeftButtonDown += MyBubbleEvent;
            elli.MouseLeftButtonDown += MyTunnelingEvent;
            elli.PreviewMouseLeftButtonDown += MyTunnelingEvent;

            rect.MouseLeftButtonDown += MyBubbleEvent;
            rect.PreviewMouseLeftButtonDown += MyBubbleEvent;
            rect.MouseLeftButtonDown += MyTunnelingEvent;
            rect.PreviewMouseLeftButtonDown += MyTunnelingEvent;
        }

        void MyTunnelingEvent(object sender, MouseEventArgs e)
        {
            Debug.WriteLine($"Tunnel orignal source: {e.OriginalSource}");
            Debug.WriteLine($"Tunnel source: {e.Source}");
            Debug.WriteLine($"Tunnel sender: {sender}");
        }

        void MyBubbleEvent(object sender, MouseEventArgs e)
        {
            Debug.WriteLine($"Bubble orignal source: {e.OriginalSource}");
            Debug.WriteLine($"Bubble source: {e.Source}");
            Debug.WriteLine($"Bubble sender: {sender}");
        }
    }
}
