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

namespace Cennik
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DAL _dal = new DAL();
        private BookmarkService _bookmark = new BookmarkService();

        private void FillCombobox()
        {
            CbKat.DataContext = _dal.FillCombo();
        }

        public MainWindow()
        {
            InitializeComponent();
            FillCombobox();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var kat = CbKat.SelectedItem as Kategorie;
            _bookmark.GenerateDoc(_dal.FillDataGrid(kat.Id), kat.Nazwa.ToString());
        }

        private void CbKat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var idKat = CbKat.SelectedValue;
            
           dtGrid.DataContext = _dal.FillDataGrid(idKat);
        }

        private void btnDodaj_Click_1(object sender, RoutedEventArgs e)
        {
            Window1 win1 = new Window1();
            win1.Show();
        }

        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selected = ((DataGridRow)sender).Item as Przedmioty;

            Window2 win2 = new Window2(selected);
            win2.Show();
        }

        private void btnUsun_Click(object sender, RoutedEventArgs e)
        {
            var selected = dtGrid.SelectedItem as Przedmioty;

            _dal.DeleteItem(selected.Id);
            var idKat = CbKat.SelectedValue;
            dtGrid.DataContext = _dal.FillDataGrid(idKat);
            
        }
    }
}
