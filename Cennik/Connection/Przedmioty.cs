namespace Cennik.Connection
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Przedmioty")]
    public partial class Przedmioty
    {
        public int Id { get; set; }

        public string Nazwa { get; set; }

        public int? IdKategorii { get; set; }

        public decimal? Kaucja { get; set; }

        public decimal? StawkaDzien { get; set; }

        public decimal? StawkaGodzinowa { get; set; }

        public decimal? Cena { get; set; }

        public int? IsPrice { get; set; }

        public int? Wartosc { get; set; }

        public int? IsSki { get; set; }

        public virtual Kategorie Kategorie { get; set; }
    }
}
