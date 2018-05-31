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
        private DAL _dal = new DAL();
        private Prise _prise = new Prise();
        private int idKat;

        public ViewModelWindow2 ViewModelWindow2 { get; set; }


        public Window2(Przedmioty selected, int idKat)
        {
            ViewModelWindow2 = new ViewModelWindow2(selected, idKat);
            InitializeComponent();
        }

   

        public void FillText()
        {
            //tbCena.Text = przedmiot.Cena.ToString();
            //tbDoba.Text = przedmiot.StawkaDzien.ToString();
            //tbGodz.Text = przedmiot.StawkaGodzinowa.ToString();
            //tbKaucja.Text = przedmiot.Cena.ToString();
            //tbNazwa.Text = przedmiot.Nazwa.ToString();
            //tbWartosc.Text = przedmiot.Wartosc.ToString();
            //cbKat.SelectedValue = _idKat;
        }

        private void btnZapisz_Click(object sender, RoutedEventArgs e)
        {
            //int isPrise = _prise.IsPrise(Convert.ToDecimal(tbCena.Text));
            //_dal.ChangeItemProp(przedmiot.Id, tbNazwa.Text, Convert.ToDecimal(tbKaucja.Text), cbKat.SelectedValue, Convert.ToDecimal(tbDoba.Text), Convert.ToDecimal(tbGodz.Text), Convert.ToDecimal(tbCena.Text), Convert.ToInt32(tbWartosc.Text), isPrise);
            //this.Close();
        }
    }
}
