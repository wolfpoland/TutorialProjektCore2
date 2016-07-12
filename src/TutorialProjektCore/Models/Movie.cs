using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TutorialProjektCore.Models
{
    public class Movie
    {
        public int ID { get; set; }
        public string Tytul { get; set; }
        public DateTime DataWydania { get; set; }
        public string gatunek { get; set; }
        public decimal cena { get; set; }
    }
}
