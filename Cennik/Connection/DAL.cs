using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cennik.Connection
{
    class DAL
    {
        public List<Kategorie> FillCombo()
        {
            using (EntityModel context = new EntityModel())
            {
                var kategorie = (from okategorie in context.Kategorie
                                 orderby okategorie.Nazwa
                                 select okategorie).ToList();
                return kategorie;
            }
        }

        public List<Przedmioty> FillDataGrid(object idKat)
        {
            using (EntityModel context = new EntityModel())
            {
                var przedmioty = context.Przedmioty.Where(oPrzedmioty => oPrzedmioty.IdKategorii == (int)idKat).ToList();

                return przedmioty;
            }
        }

        public void DodajPrzedmiot(string nazwa, decimal kaucja, object idKategorii, decimal stawkaDoba, decimal stawkaGodz, decimal cena, int wartosc, int isPrise, int isSki)
        {
            using (EntityModel context = new EntityModel())
            {
                var przedmiot = new Przedmioty();

                przedmiot.Nazwa = nazwa;
                przedmiot.IdKategorii = (int)idKategorii;
                przedmiot.Kaucja = kaucja;
                przedmiot.StawkaDzien = stawkaDoba;
                przedmiot.StawkaGodzinowa = stawkaGodz;
                przedmiot.Wartosc = wartosc;
                przedmiot.Cena = cena;
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

        public void DeleteItem(int id)
        {
            using (EntityModel context = new EntityModel())
            {
                var item = context.Przedmioty.Where(oItem => oItem.Id == id).First();

                context.Przedmioty.Remove(item);
                context.SaveChanges();
            }
        }
    }
}
