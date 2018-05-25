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
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        private DAL _dal = new DAL();
        private Przedmioty _przedmioty = new Przedmioty();
        private Prise _prise = new Prise();

        private void FillCombobox()
        {
            cbKat.DataContext = _dal.FillCombo();
        }
        public Window2(Przedmioty przedmioty) :this()
        {
            _przedmioty = przedmioty;
            fillTb();
        }

        public Window2()
        {
            InitializeComponent();
            FillCombobox();
            
        }

        private void btnZapisz_Click(object sender, RoutedEventArgs e)
        {
            int isPrise = _prise.IsPrise(tbCena);
            _dal.ChangeItemProp(_przedmioty.Id, tbNazwa.Text, Convert.ToDecimal(tbKaucja.Text),cbKat.SelectedValue, Convert.ToDecimal(tbDoba.Text), Convert.ToDecimal(tbGodz.Text), Convert.ToDecimal(tbCena.Text), Convert.ToInt32(tbWartosc.Text), isPrise);
            Close();
        }

        public void fillTb()
        {
            tbNazwa.Text = _przedmioty.Nazwa;
            tbKaucja.Text = (_przedmioty.Kaucja).ToString();
            tbWartosc.Text = (_przedmioty.Wartosc).ToString();
            tbGodz.Text = (_przedmioty.StawkaGodzinowa).ToString();
            tbDoba.Text = (_przedmioty.StawkaDzien).ToString();
            tbCena.Text = (_przedmioty.Cena).ToString();
            cbKat.SelectedValue = _przedmioty.IdKategorii;
        }
    }
}
