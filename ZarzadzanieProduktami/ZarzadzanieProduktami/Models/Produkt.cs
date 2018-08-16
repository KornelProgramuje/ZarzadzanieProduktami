using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZarzadzanieProduktami.Models
{
    public class Produkt
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public int KategoriaId { get; set; }
        public string Cena { get; set; }
        public string Opis { get; set; }


        public virtual Kategoria Kategorie { get; set; }
    }
}