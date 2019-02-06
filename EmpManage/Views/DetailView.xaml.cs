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
    /// Interaction logic for DetailView.xaml
    /// </summary>
    public partial class DetailView : Window
    {
        public DetailView()
        {
            InitializeComponent();
            DataContext = new UIService();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
