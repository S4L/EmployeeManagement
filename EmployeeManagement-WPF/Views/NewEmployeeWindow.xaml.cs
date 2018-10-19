﻿using EmMana.WPF.ViewModels;
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
using System.Windows.Shapes;

namespace EmMana.WPF.Views
{
    /// <summary>
    /// Interaction logic for CreateNewEmployee.xaml
    /// </summary>
    public partial class NewEmployee : Window
    {
        public NewEmployee()
        {
            InitializeComponent();
            DataContext = new NewEmployeeViewModel();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
