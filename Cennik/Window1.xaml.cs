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
using Cennik.Connection;

namespace Cennik
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private Prise _prise = new Prise();
        private DAL _dal = new DAL();

        private void FillCombobox()
        {
            cbKat.DataContext = _dal.FillCombo();
        }

        public Window1()
        {
            InitializeComponent();
            FillCombobox();
        }

        private void btnZapisz_Click(object sender, RoutedEventArgs e)
        {
            int isPrise = _prise.IsPrise(tbCena);
            _dal.DodajPrzedmiot(tbNazwa.Text, Convert.ToDecimal(tbKaucja.Text), cbKat.SelectedValue, Convert.ToDecimal(tbDoba.Text), Convert.ToDecimal(tbGodz.Text), Convert.ToDecimal(tbCena.Text), Convert.ToInt32(tbWartosc.Text), isPrise, 0);
        }
    }
}
