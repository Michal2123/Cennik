using Cennik.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Commands;
using System.Windows.Input;
using System.Collections.ObjectModel;
using Cennik.View;

namespace Cennik.ViewModel
{
    public class ViewModelWindow2 : BindableBase
    {
        private DAL _dal = new DAL();
        private Prise _prise = new Prise();
        
        public ICommand ClickCommand
        {
            get;
            private set;

        }
        
        public ViewModelWindow2(Przedmiot przedmiot, int idKat) 
        {
            Kategorie = _dal.FillCombo();
            ClickCommand = new DelegateCommand(ClickedMethodSave);
            Przedmiot = przedmiot;
            SKategoria = idKat;
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

        private Przedmiot _przedmiot;
        public Przedmiot Przedmiot
        {
            get
            {
                return _przedmiot;
            }
            set
            {
                _przedmiot = value;
            }
        }

        private int _sKategoria;

        public int SKategoria
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

        public void ClickedMethodSave()
        {
            var toSave = Przedmiot;
            int isPrise = _prise.IsPrise(toSave.Cena);
            _dal.ChangeItemProp(toSave, isPrise);          
        }
    }
}
