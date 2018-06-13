using Cennik.Connection;
using Prism.Mvvm;
using Prism.Commands;
using System.Windows.Input;
using System.Collections.ObjectModel;
using Cennik.View;

namespace Cennik.ViewModel
{
    public class ViewModelWindow1 : BindableBase
    {        
        private Prise _prise = new Prise();
        private DAL _dal = new DAL();
        private MainWindow MainWindow { get; set; }
        private Window1 Window { get; set; }

        public ICommand ClickCommand
        {
            get;
            private set;

        }

        public ViewModelWindow1(Window1 window, MainWindow mainWindow)
        {
            Window = window;
            MainWindow = mainWindow;
            Kategorie = _dal.FillCombo();
            ClickCommand = new DelegateCommand(ClickedMethod);
            Przedmioty = new Przedmiot();
        }

        private ObservableCollection<Kategoria> _kategorie;
        public ObservableCollection<Kategoria> Kategorie
        {
            get
            {
                return _kategorie;
            }
            set
            {
                SetProperty(ref _kategorie, value);
            }
        }

        private Przedmiot _przedmioty;
        public Przedmiot Przedmioty
        {
            get
            {
                return _przedmioty;
            }
            set
            {
                _przedmioty = value;
            }
        }

        private int _sKategoria;
        public  int SKategoria
        {
            get
            {
                return _sKategoria;
            }
            set
            {
                _sKategoria = value;
            }
        }

        public void ClickedMethod()
        {           
            int isPrise = _prise.IsPrise(_przedmioty.Cena);
            _dal.AddNewItem(_przedmioty,_sKategoria,isPrise, 0);
            Window.Close();
            MainWindow.Refresh();
        }
    }
}
