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

namespace Prog3_Practis3._1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ModelStundent myStudent = new ModelStundent(2345, "Yannes");

        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = myStudent; // TODO hää

            EditorStudent es = new EditorStudent(myStudent);
            es.Show();

        }
    }
}
