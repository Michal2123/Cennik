using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using Cennik.Connection;
using Cennik.Bookmark;
using Cennik.ViewModel;
using Cennik.View;
using System.Collections.ObjectModel;

namespace Cennik
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DAL _dal = new DAL();

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new ViewModelMainWindow();
        }

        private void CbKat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var idKat = CbKat.SelectedValue;
            dtGrid.ItemsSource = _dal.FillDataGridById(idKat);
            
        }

        private void btnDodaj_Click_1(object sender, RoutedEventArgs e)
        {
            Window1 win1 = new Window1();
            win1.Show();
        }

        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selected = ((DataGridRow)sender).Item as Przedmioty;
            var idKat = CbKat.SelectedValue;

            Window2 win2 = new Window2(selected, (int)idKat);
            win2.Show();
        }
    }
}
