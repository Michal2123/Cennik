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

        public ViewModelWindow2 ViewModelWindow2 { get; set; }


        public Window2(Przedmiot selected, int idKat)
        {
            ViewModelWindow2 = new ViewModelWindow2(selected, idKat);
            InitializeComponent();
        }

        public Window2()
        {

        }
    }
}
