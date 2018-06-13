using System.Windows;
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
            ViewModelWindow2 = new ViewModelWindow2(selected, idKat, this);
            InitializeComponent();
        }
    }
}
