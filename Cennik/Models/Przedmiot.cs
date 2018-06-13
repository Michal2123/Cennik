using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cennik.Models
{
    public class Przedmiot
    {
        public int Id { get; set; }

        public string Nazwa { get; set; }

        public int? IdKategorii { get; set; }

        public decimal? Kaucja { get; set; }

        public decimal? StawkaDzien { get; set; }

        public decimal? StawkaGodzinowa { get; set; }

        public decimal? Cena { get; set; }

        public int? Wartosc { get; set; }
    }
}
