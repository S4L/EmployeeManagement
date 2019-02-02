﻿using EMS.UI.ViewModels;
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

namespace EMS.UI.Views
{
    /// <summary>
    /// Interaction logic for NewEmployeeView.xaml
    /// </summary>
    public partial class NewEmployeeView : Window
    {
        public NewEmployeeView()
        {
            InitializeComponent();
            DataContext = new NewEmployeeVM();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
