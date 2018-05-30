﻿using Cennik.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Commands;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace Cennik.ViewModel
{
    public class ViewModelWindow1 : BindableBase
    {        
        private Prise _prise = new Prise();
        private DAL _dal = new DAL();

        public ICommand ClickCommand
        {
            get;
            private set;

        }

        public ViewModelWindow1()
        {
            Kategorie = _dal.FillCombo();
            ClickCommand = new DelegateCommand(ClickedMethod);
            Przedmioty = new Przedmioty();
            

        }

        private ObservableCollection<Kategorie> _kategorie;
        public ObservableCollection<Kategorie> Kategorie
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

        private Przedmioty _przedmioty;
        public Przedmioty Przedmioty
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
        }


    }
}