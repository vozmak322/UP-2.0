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
using System.Windows.Shapes;
using UPractice.Dbcontext;

namespace UPractice.View
{
    /// <summary>
    /// Логика взаимодействия для FindByCypherWindow.xaml
    /// </summary>
    public partial class FindByCypherWindow : Window
    {
        public FindByCypherWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }
    }
}
