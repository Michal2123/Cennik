using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Cennik.Connection;
using Cennik.ViewModel;
using Cennik.View;

namespace Cennik
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DAL _dal = new DAL();

        public ViewModelMainWindow ViewModelMainWindow { get; set; }

        public MainWindow()
        {
            ViewModelMainWindow = new ViewModelMainWindow(this);
            InitializeComponent();
            CbKat.SelectedIndex = 0;
            
        }

        private void CbKat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            Refresh();
        }

        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selected = ((DataGridRow)sender).Item as Przedmiot;
            var idKat = CbKat.SelectedValue;

            Window2 win2 = new Window2(selected, (int)idKat);
            win2.Show();
        }

        public void Refresh()
        {
            var idKat = CbKat.SelectedValue;
            dtGrid.ItemsSource = _dal.FillDataGridById(idKat);
        }
    }
}
