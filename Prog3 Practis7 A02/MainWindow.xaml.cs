﻿using System;
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

namespace Prog3_Practis7_A02
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<Student> students = new List<Student>();

        public List<Student> Students { get { return students; } }

        public MainWindow()
        {
            InitializeComponent();

            DataContext = this;

            students.Add(new("Hans", 34987, "IN", 18));

            students.Add(new("Günter", 3565677, "MIN", 25));
        }
    }
}
