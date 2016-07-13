using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TutorialProjektCore.Models
{
    public class Movie
    {
        public int ID { get; set; }
        public string Tytul { get; set; }
        [DisplayFormat(DataFormatString="{0:yyyy-MM-dd}",ApplyFormatInEditMode =true)]
        public DateTime DataWydania { get; set; }
        public string gatunek { get; set; }
        public decimal cena { get; set; }
    }
}
