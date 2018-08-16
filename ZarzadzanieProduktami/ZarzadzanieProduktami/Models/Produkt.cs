using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZarzadzanieProduktami.Models
{
    public class Produkt
    {
        public int Id { get; set; }

        [Display(Name = "Nazwa produktu")]
        [Required(ErrorMessage = "Wypełnij pole nazwa produktu!")]
        public string Nazwa { get; set; }

        public int KategoriaId { get; set; }

        [Display(Name = "Cena produktu")]
        [Range(0.01, 1000, ErrorMessage = "Niewłaściwa cena, podaj cenę z przedziału 0.01 - 1000zł")]
        public string Cena { get; set; }

        [Display(Name = "Opis produktu")]
        [Required(ErrorMessage = "Wypełnij pole opis produktu!")]
        [StringLength(100, ErrorMessage = "Maxymalna długość opisu wynosi 100 znaków")]
        public string Opis { get; set; }


        public virtual Kategoria Kategorie { get; set; }
    }
}