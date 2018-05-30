using Cennik.Bookmark;
using Cennik.Connection;
using Cennik.View;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Cennik.ViewModel
{
    public class ViewModelMainWindow
    {
        private DAL _dal = new DAL();
        private BookmarkService _bookmark = new BookmarkService();
        public ObservableCollection<Przedmioty> Przedmioty { get; set; }
        public ObservableCollection<Kategorie> Kategorie { get; set; }

        public ICommand ClickCommandDelete { get; private set; }
        public ICommand ClickCommandBookmark { get; private set; }
        public ICommand ClickCommandWindow2 { get; private set; }


        Przedmioty _SelectedItem;
        public Przedmioty SelectedItem
        {
            get
            {
                return _SelectedItem;
            }
            set
            {
                _SelectedItem = value;
            }
        }

        Kategorie _SelectedKat;
        public Kategorie SelectedKat
        {
            get
            {
                return _SelectedKat;
            }
            set
            {
                _SelectedKat = value;
            }
        }

        public ViewModelMainWindow()
        {
            Kategorie = _dal.FillCombo();
            Przedmioty = _dal.FillDataGrid();
            ClickCommandDelete = new DelegateCommand(DeleteClickedMethod);
            ClickCommandBookmark = new DelegateCommand(BookmarkClickedMethod);
            ClickCommandWindow2 = new DelegateCommand(Window2ClickedMethod);
        }

        public void DeleteClickedMethod()
        {
            var item = SelectedItem;
            _dal.DeleteItem(item);
        }

        public void BookmarkClickedMethod()
        {
            var kat = SelectedKat;
            _bookmark.GenerateDoc(_dal.FillDataGridById(kat.Id), kat.Nazwa.ToString());
        }

        public void Window2ClickedMethod()
        {

            //Window2 win2 = new Window2();
            //win2.Show();
        }
    }
}
