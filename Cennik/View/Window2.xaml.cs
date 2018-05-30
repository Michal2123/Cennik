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
using Cennik.ViewModel;

namespace Cennik.View
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        private Przedmioty _przedmioty = new Przedmioty();
        private int _idKat;
        private DAL _dal = new DAL();
        private Prise _prise = new Prise();

        public Window2(Przedmioty przedmioty, int idKat)
        {
            _przedmioty = przedmioty;
            _idKat = idKat;
            InitializeComponent();
            this.DataContext = new ViewModelWindow2();
            FillText();
            
        }

        public void FillText()
        {
            tbCena.Text = _przedmioty.Cena.ToString();
            tbDoba.Text = _przedmioty.StawkaDzien.ToString();
            tbGodz.Text = _przedmioty.StawkaGodzinowa.ToString();
            tbKaucja.Text = _przedmioty.Cena.ToString();
            tbNazwa.Text = _przedmioty.Nazwa.ToString();
            tbWartosc.Text = _przedmioty.Wartosc.ToString();
            cbKat.SelectedValue = _idKat;
        }

        private void btnZapisz_Click(object sender, RoutedEventArgs e)
        {
            int isPrise = _prise.IsPrise(Convert.ToDecimal(tbCena.Text));
            _dal.ChangeItemProp(_przedmioty.Id, tbNazwa.Text, Convert.ToDecimal(tbKaucja.Text), cbKat.SelectedValue, Convert.ToDecimal(tbDoba.Text), Convert.ToDecimal(tbGodz.Text), Convert.ToDecimal(tbCena.Text), Convert.ToInt32(tbWartosc.Text), isPrise);
            this.Close();
        }
    }
}
