using System.Collections.ObjectModel;
using System.Linq;

namespace Cennik.Connection
{
    class DAL
    {
        public ObservableCollection<Kategoria> FillCombo()
        {
            using (EntityModel context = new EntityModel())
            {
                var kategorie = (from oKategorie in context.Kategorie
                                 orderby oKategorie.Nazwa
                                 select oKategorie).ToList();

                ObservableCollection<Kategoria>myCollection = new ObservableCollection<Kategoria>(kategorie);
                return myCollection;
            }
        }

        public ObservableCollection<Przedmiot> FillDataGridById(object idKat)
        {
            using (EntityModel context = new EntityModel())
            {
                var przedmioty = context.Przedmioty.Where(oPrzedmioty => oPrzedmioty.IdKategorii == (int)idKat).ToList();
                ObservableCollection<Przedmiot> myCollection = new ObservableCollection<Przedmiot>(przedmioty);
                return myCollection;
            }
        }

        public ObservableCollection<Przedmiot> FillDataGrid()
        {
            using (EntityModel context = new EntityModel())
            {
                var przedmioty = (from oPrzedmioty in context.Przedmioty
                                  orderby oPrzedmioty.IdKategorii
                                  select oPrzedmioty).ToList();
                ObservableCollection<Przedmiot> myCollection = new ObservableCollection<Przedmiot>(przedmioty);
                return myCollection;
            }
        }

        public void AddNewItem(Przedmiot item,int sKategoria, int isPrise, int isSki)
        {
            using (EntityModel context = new EntityModel())
            {
                var przedmiot = new Przedmiot();

                przedmiot.Nazwa = item.Nazwa;
                przedmiot.IdKategorii = sKategoria;
                przedmiot.Kaucja = item.Kaucja;
                przedmiot.StawkaDzien = item.StawkaDzien;
                przedmiot.StawkaGodzinowa = item.StawkaGodzinowa;
                przedmiot.Wartosc = item.Wartosc;
                przedmiot.Cena = item.Cena;
                przedmiot.IsPrice = isPrise;
                przedmiot.IsSki = isSki;

                context.Przedmioty.Add(przedmiot);
                context.SaveChanges();
            }
        }

        public void ChangeItemProp(Przedmiot przedmiot, int isPrise)
        {
            using (EntityModel context = new EntityModel())
            {
                var item = context.Przedmioty.Where(oItem => oItem.Id == przedmiot.Id).First();

                item.Nazwa = przedmiot.Nazwa;
                item.Kaucja = przedmiot.Kaucja;
                item.StawkaDzien = przedmiot.StawkaDzien;
                item.StawkaGodzinowa = przedmiot.StawkaGodzinowa;
                item.Wartosc = przedmiot.Wartosc;
                item.Cena = przedmiot.Cena;
                item.IdKategorii = przedmiot.IdKategorii;
                item.IsPrice = isPrise;

                context.SaveChanges();
            }
        }

        public void DeleteItem(Przedmiot przedmioty)
        {
            using (EntityModel context = new EntityModel())
            {
                var item = context.Przedmioty.Where(oItem => oItem.Id == przedmioty.Id).First();

                context.Przedmioty.Remove(item);
                context.SaveChanges();
            }
        }

        public Przedmiot SelectedItem(int id, object idKat)
        {
            using (EntityModel context = new EntityModel())
            {
                var item = context.Przedmioty.Where(oItem => oItem.Id == id).FirstOrDefault();
                var kat = context.Kategorie.Where(oKat => oKat.Id == (int)idKat).FirstOrDefault();

                var przedmiot = new Przedmiot();

                przedmiot.Nazwa = item.Nazwa;
                przedmiot.Kaucja = item.Kaucja;
                przedmiot.Wartosc = item.Wartosc;
                przedmiot.StawkaDzien = item.StawkaDzien;
                przedmiot.StawkaGodzinowa = item.StawkaGodzinowa;
                przedmiot.Cena = item.Cena;
                przedmiot.IdKategorii = kat.Id;

                return przedmiot;
            }
        }
    }
}
