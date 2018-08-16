using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZarzadzanieProduktami.Models
{
    public class Kategoria
    {
        public int Id { get; set; }
        public string NazwaKategorii { get; set; }


        public virtual ICollection<Produkt> Produkty { get; set; }
    }
}