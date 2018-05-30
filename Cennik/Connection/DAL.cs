using Cennik.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cennik.Connection
{
    class DAL
    {
        public ObservableCollection<Kategorie> FillCombo()
        {
            using (EntityModel context = new EntityModel())
            {
                var kategorie = (from oKategorie in context.Kategorie
                                 orderby oKategorie.Nazwa
                                 select oKategorie).ToList();

                ObservableCollection<Kategorie>myCollection = new ObservableCollection<Kategorie>(kategorie);
                return myCollection;
            }
        }

        public ObservableCollection<Przedmioty> FillDataGridById(object idKat)
        {
            using (EntityModel context = new EntityModel())
            {
                var przedmioty = context.Przedmioty.Where(oPrzedmioty => oPrzedmioty.IdKategorii == (int)idKat).ToList();
                ObservableCollection<Przedmioty> myCollection = new ObservableCollection<Przedmioty>(przedmioty);
                return myCollection;
            }
        }

        public ObservableCollection<Przedmioty> FillDataGrid()
        {
            using (EntityModel context = new EntityModel())
            {
                var przedmioty = (from oPrzedmioty in context.Przedmioty
                                  orderby oPrzedmioty.IdKategorii
                                  select oPrzedmioty).ToList();
                ObservableCollection<Przedmioty> myCollection = new ObservableCollection<Przedmioty>(przedmioty);
                return myCollection;
            }
        }

        public void AddNewItem(Przedmioty item,int sKategoria, int isPrise, int isSki)
        {
            using (EntityModel context = new EntityModel())
            {
                var przedmiot = new Przedmioty();

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

        public void ChangeItemProp(int id, string nazwa, decimal kaucja, object idKategorii, decimal stawkaDoba, decimal stawkaGodz, decimal cena, int wartosc, int isPrise)
        {
            using (EntityModel context = new EntityModel())
            {
                var item = context.Przedmioty.Where(oItem => oItem.Id == id).First();

                item.Nazwa = nazwa;
                item.Kaucja = kaucja;
                item.StawkaDzien = stawkaDoba;
                item.StawkaGodzinowa = stawkaGodz;
                item.Wartosc = wartosc;
                item.Cena = cena;
                item.IdKategorii = (int)idKategorii;
                item.IsPrice = isPrise;

                context.SaveChanges();
            }
        }

        public void DeleteItem(Przedmioty przedmioty)
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

                przedmiot.Name = item.Nazwa;
                przedmiot.Kaucja = item.Kaucja.ToString();
                przedmiot.Wartosc = item.Wartosc.ToString();
                przedmiot.Doba = item.StawkaDzien.ToString();
                przedmiot.Godz = item.StawkaGodzinowa.ToString();
                przedmiot.Cena = item.Cena.ToString();
                przedmiot.Kategoria = kat.Nazwa;

                return przedmiot;
            }
        }
    }
}
