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
        public ObservableCollection<Przedmiot> Przedmiot { get; set; }
        public ObservableCollection<Kategoria> Kategoria { get; set; }

        public ICommand ClickCommandDelete { get; private set; }
        public ICommand ClickCommandBookmark { get; private set; }
        public ICommand ClickCommandWindow1 { get; private set; }


        Przedmiot _SelectedItem;
        public Przedmiot SelectedItem
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

        Kategoria _SelectedKat;
        public Kategoria SelectedKat
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
            Kategoria = _dal.FillCombo();
            Przedmiot = _dal.FillDataGrid();
            ClickCommandDelete = new DelegateCommand(DeleteClickedMethod);
            ClickCommandBookmark = new DelegateCommand(BookmarkClickedMethod);
            ClickCommandWindow1 = new DelegateCommand(Window1ClickedMethod);
        }

        public void DeleteClickedMethod()
        {
            var item = SelectedItem;
            _dal.DeleteItem(item);
        }

        public void BookmarkClickedMethod()
        {
            var kat = SelectedKat;
            var table = _dal.FillDataGridById(kat.Id);
            _bookmark.GenerateDoc(table, kat.Nazwa);
        }

        public void Window1ClickedMethod()
        {
            Window1 win1 = new Window1();
            win1.Show();
        }
    }
}
