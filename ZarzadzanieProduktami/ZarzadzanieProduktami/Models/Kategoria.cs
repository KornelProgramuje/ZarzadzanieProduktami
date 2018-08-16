using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZarzadzanieProduktami.Models
{
    public class Kategoria
    {
        public int Id { get; set; }

        [Display(Name = "Nazwa kategorii")]
        [Required(ErrorMessage = "Wypełnij pole nazwa kategorii!")]
        public string NazwaKategorii { get; set; }


        public virtual ICollection<Produkt> Produkty { get; set; }
    }
}