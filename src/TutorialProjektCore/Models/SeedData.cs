using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutorialProjektCore.Data;

namespace TutorialProjektCore.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using(var context=new ApplicationDbContext(
               serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.Movie.Any())
                {
                    return;
                }
                context.Movie.AddRange(
                    new Movie
                    {
                        Tytul="Chlopaki nie placza",
                        DataWydania= DateTime.Parse("1994-10-25"),
                        gatunek="Komedia",
                        ocena="A+",
                        cena=10.99M
                    },
                      new Movie
                      {
                          Tytul = "Pokachontas",
                          DataWydania = DateTime.Parse("1994-10-25"),
                          gatunek = "Komedia",
                          ocena="B-",
                          cena = 10.99M
                      }
                    );
                context.SaveChanges();
            }
        }
    }
}
