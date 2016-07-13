using System;
using System.ComponentModel.DataAnnotations;

namespace TutorialProjektCore.Models
{
    public class Movie
    {
        public int ID { get; set; }
        public string Tytul { get; set; }
        [Display(Name ="Wydanie")]
        [DataType(DataType.Date)]
        public DateTime DataWydania { get; set; }
        public string gatunek { get; set; }
        public decimal cena { get; set; }
    }
}
